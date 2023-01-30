using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace VisionAssist.API.Telegram
{
    public class TelegramController
    {
        private static readonly string BaseUrl = "https://api.telegram.org/bot";
        private static readonly string token = "6025370945:AAH-lyI2JE_g7eGWxL7w0LMrggQzOxswWzw";
        private string chat_id = "";
        
        // Initilalize Telegram 
        public TelegramController()
        {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)768 | (SecurityProtocolType)3072;
        }

        public bool getUpdates()
        {
            chat_id = "";

            string url = string.Format(BaseUrl + @"{0}/getUpdates", token);
            WebClient weblient = new WebClient();

            try
            {
                string result = weblient.DownloadString(url);

                if (result.IndexOf("\"ok\":true") > 0)
                {
                    var JsonReult = JObject.Parse(result);

                    // 마지막 메시지에서 채팅아이디를 받음
                    chat_id = JsonReult["result"].Last["message"]["chat"]["id"].ToString();
                    return true;
                }
            }
            catch (Exception ex) 
            {
                System.Console.WriteLine(ex);
            }

            return false;
        }
        
        public void MessageSend(string msg)
        {
            if (chat_id == "")
            {
                if (getUpdates() == false)
                {
                    return;
                }
            }

            string url = string.Format(BaseUrl + @"{0}/sendMessage?chat_id={1}&text={2}", token, chat_id, msg);
            WebClient weblient = new WebClient();

            try
            {
                string result = weblient.DownloadString(url);

                if (result.IndexOf("\"ok\":true") > 0)
                {
                    //MessageBox.Show("전송 성공");
                }
                else
                {
                    //MessageBox.Show(result);
                }
            }
            catch (Exception ex) { /*MessageBox.Show(ex.Message);*/ }
        }
    }
}
