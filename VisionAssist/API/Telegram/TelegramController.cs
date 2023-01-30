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

namespace VisionAssist.API.TelegramAPI
{
    public class TelegramController
    {
        private static readonly string BaseUrl = "https://api.telegram.org/bot";
        private static readonly string token = "6025370945:AAH-lyI2JE_g7eGWxL7w0LMrggQzOxswWzw";
        private string chat_id = "";

        private TelegramBotClient Bot;

        public bool isConnected = false;
        
        // Initilalize Telegram 
        public TelegramController()
        {
            try
            {
                Bot = new TelegramBotClient(token);
                isConnected = true;
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex);
                isConnected = false;
            }
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

        private async Task Bot_SendMessage(long chatId, string message)
        {
            await Bot.SendTextMessageAsync(chatId, message);
        }

        private async Task Bot_SendImage(long chatId, string FilePath, string Caption = "")
        {
            await Bot.SendPhotoAsync(chatId,
                new Telegram.Bot.Types.InputFiles.InputOnlineFile(FilePath), Caption);
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

            _ = Bot_SendMessage(long.Parse(chat_id), msg);
        }

        public void ImageSend(string FilePath, string Caption)
        {
            _ = Bot_SendImage(long.Parse(chat_id), FilePath, Caption);
        }
    }
}
