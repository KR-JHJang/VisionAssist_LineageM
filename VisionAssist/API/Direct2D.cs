using OpenCvSharp;
using SharpDX.Direct2D1;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using SharpDX.DXGI;
using SharpDX.Direct3D11;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using PixelFormat = SharpDX.Direct2D1.PixelFormat;
using AlphaMode = SharpDX.Direct2D1.AlphaMode;

namespace HPKR_VisionControl
{
    internal class RenderTarget2D : IDisposable
    {
        SharpDX.Direct3D11.Device _drawDevice;
        SwapChain _swapChain;
        Texture2D _backBuffer;
        RenderTargetView _backBufferView;
        public RenderTarget _renderTarget2D;
        SharpDX.Mathematics.Interop.RawViewportF _viewPort;

        int _width;
        public int Width
        {
            get { return _width; }
        }

        int _height;
        public int Height
        {
            get { return _height; }
        }

        public void Initialize(IntPtr windowHandle, int width, int height)
        {
            _width = width;
            _height = height;

            var desc = new SwapChainDescription()
            {
                BufferCount = 1,
                ModeDescription = new ModeDescription(width, height,
                                         new Rational(60, 1), Format.B8G8R8A8_UNorm),
                IsWindowed = true,
                OutputHandle = windowHandle,
                SampleDescription = new SampleDescription(1, 0),
                SwapEffect = SwapEffect.Discard,
                Usage = Usage.RenderTargetOutput,
            };

            _viewPort = new SharpDX.Mathematics.Interop.RawViewportF
            {
                X = 0,
                Y = 0,
                Width = width,
                Height = height,
            };

            SharpDX.Direct3D11.Device.CreateWithSwapChain(SharpDX.Direct3D.DriverType.Hardware,
                 SharpDX.Direct3D11.DeviceCreationFlags.BgraSupport,
                 new[] { SharpDX.Direct3D.FeatureLevel.Level_10_0 }, desc, out _drawDevice, out _swapChain);

            _backBuffer = Texture2D.FromSwapChain<Texture2D>(_swapChain, 0);
            _backBufferView = new RenderTargetView(_drawDevice, _backBuffer);

            using (SharpDX.Direct2D1.Factory factory = new SharpDX.Direct2D1.Factory())
            {
                using (var surface = _backBuffer.QueryInterface<Surface>())
                {
                    _renderTarget2D = new RenderTarget(factory, surface,
                        new RenderTargetProperties(new SharpDX.Direct2D1.PixelFormat(Format.Unknown, SharpDX.Direct2D1.AlphaMode.Premultiplied)));
                    _renderTarget2D.AntialiasMode = AntialiasMode.PerPrimitive;
                }
            }
        }

        public void Dispose()
        {
            ReleaseResource();
        }

        void ReleaseResource()
        {
            if (_renderTarget2D != null)
            {
                _renderTarget2D.Dispose();
                _renderTarget2D = null;
            }

            if (_backBufferView != null)
            {
                _backBufferView.Dispose();
                _backBufferView = null;
            }

            if (_backBuffer != null)
            {
                _backBuffer.Dispose();
                _backBuffer = null;
            }

            if (_swapChain != null)
            {
                _swapChain.Dispose();
                _swapChain = null;
            }

            if (_drawDevice != null)
            {
                _drawDevice.Dispose();
                _drawDevice = null;
            }
        }

        public void Render(Action<RenderTarget> render)
        {
            _drawDevice.ImmediateContext.Rasterizer.SetViewport(_viewPort);
            _drawDevice.ImmediateContext.OutputMerger.SetTargets(_backBufferView);

            _renderTarget2D.BeginDraw();

            render(_renderTarget2D);

            _renderTarget2D.EndDraw();

            _swapChain.Present(0, PresentFlags.None);
        }

        public Bitmap CreateBitmap(DataPointer dataPointer)
        {
            var bitmapProperties = new BitmapProperties(new SharpDX.Direct2D1.PixelFormat(Format.B8G8R8A8_UNorm,
                    SharpDX.Direct2D1.AlphaMode.Ignore));

            if (_renderTarget2D == null)
            {
                return null;
            }

            return new SharpDX.Direct2D1.Bitmap(_renderTarget2D, new Size2(_width, _height), dataPointer, _width * sizeof(int), bitmapProperties);
        }

        public void DrawBitmap(Bitmap Source)
        {
            Render(
                (renderer) =>
                {
                    renderer.DrawBitmap(Source, 1.0f, BitmapInterpolationMode.Linear);
                });
        }
    }

    public partial class Direct2dControl
    {
        RenderTarget2D _renderTarget;
        public RenderTarget RenderTarget2D { get; private set; }
        public Direct2dControl(IntPtr Handle, int Width, int Height)
        {
            _renderTarget = new RenderTarget2D();
            _renderTarget.Initialize(Handle, Width, Height);
        }     

        public void Initialize(IntPtr Handle, int Width, int Height)
        {
            _renderTarget.Initialize(Handle, Width, Height);
        }

        public SharpDX.Direct2D1.Bitmap ConvertMatToD2Bitmap(Mat Source)
        {
            DataPointer dataPointer = new DataPointer(Source.Data, (int)Source.Total() * Source.Channels());
            return _renderTarget.CreateBitmap(dataPointer); 
        }

        public Bitmap LoadFromFile(RenderTarget renderTarget, string file)
        {
            // Loads from file using System.Drawing.Image
            using (var bitmap = (System.Drawing.Bitmap)System.Drawing.Image.FromFile(file))
            {
                var sourceArea = new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height);
                var bitmapProperties = new BitmapProperties(new PixelFormat(Format.R8G8B8A8_UNorm, AlphaMode.Premultiplied));
                var size = new Size2(bitmap.Width, bitmap.Height);

                // Transform pixels from BGRA to RGBA
                int stride = bitmap.Width * sizeof(int);
                using (var tempStream = new DataStream(bitmap.Height * stride, true, true))
                {
                    // Lock System.Drawing.Bitmap
                    var bitmapData = bitmap.LockBits(sourceArea, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

                    // Convert all pixels 
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        int offset = bitmapData.Stride * y;
                        for (int x = 0; x < bitmap.Width; x++)
                        {
                            // Not optimized 
                            byte B = Marshal.ReadByte(bitmapData.Scan0, offset++);
                            byte G = Marshal.ReadByte(bitmapData.Scan0, offset++);
                            byte R = Marshal.ReadByte(bitmapData.Scan0, offset++);
                            byte A = Marshal.ReadByte(bitmapData.Scan0, offset++);
                            int rgba = R | (G << 8) | (B << 16) | (A << 24);
                            tempStream.Write(rgba);
                        }

                    }
                    bitmap.UnlockBits(bitmapData);
                    tempStream.Position = 0;

                    return new Bitmap(renderTarget, size, tempStream, stride, bitmapProperties);
                }
            }
        }

        public Bitmap ConvertBitmapToPArgb(RenderTarget renderTarget, System.Drawing.Bitmap bitmap)
        {
            // Loads from file using System.Drawing.Image
            var sourceArea = new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height);
            var bitmapProperties = new BitmapProperties(new PixelFormat(Format.R8G8B8A8_UNorm, AlphaMode.Premultiplied));
            var size = new Size2(bitmap.Width, bitmap.Height);

            // Transform pixels from BGRA to RGBA
            int stride = bitmap.Width * sizeof(int);
            using (var tempStream = new DataStream(bitmap.Height * stride, true, true))
            {
                // Lock System.Drawing.Bitmap
                var bitmapData = bitmap.LockBits(sourceArea, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

                // Convert all pixels 
                for (int y = 0; y < bitmap.Height; y++)
                {
                    int offset = bitmapData.Stride * y;
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        // Not optimized 
                        byte B = Marshal.ReadByte(bitmapData.Scan0, offset++);
                        byte G = Marshal.ReadByte(bitmapData.Scan0, offset++);
                        byte R = Marshal.ReadByte(bitmapData.Scan0, offset++);
                        byte A = Marshal.ReadByte(bitmapData.Scan0, offset++);
                        int rgba = R | (G << 8) | (B << 16) | (A << 24);
                        tempStream.Write(rgba);
                    }

                }
                bitmap.UnlockBits(bitmapData);
                tempStream.Position = 0;

                return new Bitmap(renderTarget, size, tempStream, stride, bitmapProperties);
            }
        }

        public void DrawImage(Mat Source)
        {
            //Source += 0;

            //using (var Conv = Source.CvtColor(ColorConversionCodes.BGR2RGBA))
            using (var Conv = Source.CvtColor(ColorConversionCodes.RGB2RGBA))
            {
                DataPointer dataPointer = new DataPointer(Conv.Data, (int)Conv.Total() * Conv.Channels());
                //var bitmapProperties = new BitmapProperties(new SharpDX.Direct2D1.PixelFormat(Format.B8G8R8A8_UNorm,
                //                    SharpDX.Direct2D1.AlphaMode.Ignore));
                var bitmapProperties = new BitmapProperties(new SharpDX.Direct2D1.PixelFormat(Format.B8G8R8A8_UNorm,
                                    SharpDX.Direct2D1.AlphaMode.Ignore));

                using (Bitmap Ret = new SharpDX.Direct2D1.Bitmap(_renderTarget._renderTarget2D,
                    new Size2(_renderTarget.Width, _renderTarget.Height), dataPointer,
                    _renderTarget.Width * sizeof(int), bitmapProperties))
                {
                    _renderTarget.DrawBitmap(Ret);
                }                
            }
        }

        public void DrawImage(System.Drawing.Bitmap Source)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            // Stopwatch 를 시작 합니다.
            sw.Start();
            Bitmap ret = ConvertBitmapToPArgb(_renderTarget._renderTarget2D, Source);
            sw.Stop();
            Console.WriteLine("CONVERT TIME  :: " + sw.ElapsedMilliseconds.ToString() + " msec");
            _renderTarget.DrawBitmap(ret);
        }
    }
}
