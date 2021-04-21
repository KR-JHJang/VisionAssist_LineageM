using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionAssist.API
{
    class KakaoHandle
    {
        public const string API_KEY = "89d43f60892ee4b8ad1f3a8f1501da67"; //사용자 인증키
        public const string TEMPLATE_ID = "44556"; //메시지 템플릿 아이디
        public const string USER_ID = "528477"; //사용자 애플리케이션 아이디
        public const string REDIRECT_URL = "https://www.naver.com/oauth"; //Redirect URL

        //Login Request URL: https://kauth.kakao.com/oauth/authorize?response_type=code&client_id={REST_API_KEY}&redirect_uri={REDIRECT_URI}
        public const string LOGIN_URL = "https://kauth.kakao.com/oauth/authorize?response_type=code&client_id=" + API_KEY + "&redirect_uri=" + REDIRECT_URL;

        public const string HOST_OAUTH_URL = "https://kauth.kakao.com";
        public const string HOST_API_URL = "https://kapi.kakao.com";

        public static string USER_TOKEN;
        public static string ACCESS_TOKEN;
    }
}
}
