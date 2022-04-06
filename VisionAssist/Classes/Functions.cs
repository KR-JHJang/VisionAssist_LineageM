using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VisionAssist.Classes
{
    public class ManagedThread : IDisposable
    {
        private bool disposedValue;
        private List<WhileThread> managedThreads = new List<WhileThread>();

        public ManagedThread()
        {
            managedThreads = new List<WhileThread>();
        }

        public void Add(WhileThread obj)
        {
            managedThreads.Add(obj);
        }

        public void StartALL()
        {
            foreach (WhileThread obj in managedThreads)
            {
                if (obj.isRun() == false)
                {
                    obj.Start();
                }
            }
        }

        public void AllStop()
        {
            foreach (WhileThread obj in managedThreads)
            {
                if (obj.isRun() == true)
                {
                    obj.Pause();
                }
            }
        }

        public void Start(int idx)
        {
            managedThreads[idx].Start();
        }

        public void Stop(int idx)
        {
            managedThreads[idx].Pause();
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~ManagedThread()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }

    public class WhileThread : IDisposable
    {
        Task task;

        public delegate void UserWhileFunc();
        private UserWhileFunc WhileFunc;

        bool m_StopTask;
        bool m_StartTask;
        bool m_Disposed;
        int m_Cycle;

        public WhileThread(int millisecondCycle, UserWhileFunc UserFunc)
        {
            m_StopTask = false;
            m_StartTask = false;
            m_Disposed = false;
            m_Cycle = millisecondCycle;

            WhileFunc = UserFunc;

            task = Task.Run(() => Tasking());
        }

        ~WhileThread()
        {
            Dispose(false);
        }

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // 이미 Dispose 했다면 패스.
            if (m_Disposed == true)
                return;

            // Dispose 인터페이스가 구현되어 있는 경우.
            if (disposing == true)
            {
            }

            // 그렇지 않은경우.
            m_StopTask = true;
            task.Wait();

            m_Disposed = true;
        }

        #endregion

        private void Tasking()
        {
            while (m_StopTask == false)
            {
                if (m_StartTask == false)
                {
                    Thread.Sleep(m_Cycle);
                    continue;
                }

                WhileFunc();

                Thread.Sleep(m_Cycle);
            }
        }

        public bool isRun()
        {
            return m_StartTask;
        }

        public void Start()
        {
            m_StartTask = true;
        }

        public void Pause()
        {
            m_StartTask = false;
        }
    }
}
