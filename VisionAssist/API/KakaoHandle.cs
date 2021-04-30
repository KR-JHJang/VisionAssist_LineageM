using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace VisionAssist.API
{
    class KakaoHandle
    {
        public const string API_KEY = "ea5236a88866b5ce7f6c8f365d23ed27"; //사용자 인증키
        public const string TEMPLATE_ID = "52175"; //메시지 템플릿 아이디
        public const string USER_ID = "571780"; //사용자 애플리케이션 아이디
        public const string REDIRECT_URL = "https://www.naver.com/oauth"; //Redirect URL
        
        //Login Request URL: https://kauth.kakao.com/oauth/authorize?response_type=code&client_id={REST_API_KEY}&redirect_uri={REDIRECT_URI}
        public const string LOGIN_URL = "https://kauth.kakao.com/oauth/authorize?response_type=code&client_id=" + API_KEY + "&redirect_uri=" + REDIRECT_URL;

        public const string HOST_OAUTH_URL = "https://kauth.kakao.com";
        public const string HOST_API_URL = "https://kapi.kakao.com";

        public static string USER_CODE;
        public static string ACCESS_TOKEN;

        public static void sendMessageToMyself(string message)
        {
            //JSON 구성
            JObject send = new JObject();
            JObject link = new JObject();
            send.Add("object_type", "text");
            send.Add("text", message);
            link.Add("web_url", "https://developers.kakao.com");
            link.Add("mobile_web_url", "https://developers.kakao.com");
            send.Add("link", link);
            send.Add("button_title", "링크 이동");

            //요청
            var client = new RestClient(HOST_API_URL);
            var request = new RestRequest("/v2/api/talk/memo/default/send", Method.POST);
            request.AddHeader("Authorization", "bearer " + ACCESS_TOKEN);
            request.AddParameter("template_object", send);

            if (client.Execute(request).IsSuccessful)
                MessageBox.Show("메시지 전송 성공!");
            else
                MessageBox.Show("메시지 전송 실패!");
        }

        public static void sendTemplateMessageToMyself()
        {
            var client = new RestClient(HOST_API_URL);

            var request = new RestRequest("/v2/api/talk/memo/send", Method.POST);
            request.AddHeader("Authorization", "bearer " + ACCESS_TOKEN);
            request.AddParameter("template_id", TEMPLATE_ID);

            if (client.Execute(request).IsSuccessful)
                MessageBox.Show("메시지 보내기 성공");
            else
                MessageBox.Show("메시지 보내기 실패");
        }
    }
}
