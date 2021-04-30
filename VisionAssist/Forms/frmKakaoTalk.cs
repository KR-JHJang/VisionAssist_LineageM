using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using RestSharp;
using VisionAssist.API;

namespace VisionAssist.Forms
{
    public partial class frmKakaoTalk : Form
    {
        public frmKakaoTalk()
        {
            InitializeComponent();

            webBrowser.Navigate(KakaoHandle.LOGIN_URL);
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string code = getCode();
            if (code != "")
            {
                KakaoHandle.USER_CODE = code;
                KakaoHandle.ACCESS_TOKEN = getToken();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        //인가 코드 요청하기
        public string getCode()
        {
            string url = webBrowser.Url.ToString();
            string token = url.Substring(url.IndexOf("=") + 1);

            //사용자가 '동의하고 계속하기' 선택, 로그인 진행 시 응답 형태:
            //{REDIRECT_URI}?code={AUTHORIZE_CODE}
            if (url.CompareTo(KakaoHandle.REDIRECT_URL + "?code=" + token) == 0)
            {
                return token;
            }
            else
            {
                return "";
            }
        }

        //토큰 요청하기
        public string getToken()
        {
            var client = new RestClient(KakaoHandle.HOST_OAUTH_URL);

            var request = new RestRequest("/oauth/token", Method.POST);
            request.AddParameter("grant_type", "authorization_code");
            request.AddParameter("client_id", KakaoHandle.API_KEY);
            request.AddParameter("redirect_uri", KakaoHandle.REDIRECT_URL);
            request.AddParameter("code", KakaoHandle.USER_CODE);

            var result = client.Execute(request);
            var json = JObject.Parse(result.Content);

            return json["access_token"].ToString();
        }
    }
}
