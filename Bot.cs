using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;


namespace TelegramBot
{
    class Bot
    {
        WebClient webClient = new WebClient();

        private static string startUrl;

        public  string StartUrl { get => startUrl; set => startUrl = value; }

        public void SendMsg(string messageFromId, string messageText)
        {
            string url = $"{startUrl}/sendMessage?chat_id={messageFromId}&text={messageText}";
            webClient.DownloadString(url);
        }

        public void SendPhoto(string messageFromId, string url)
        {
            string url1 = $"{startUrl}/sendPhoto?chat_id={messageFromId}&photo={url}";
            webClient.DownloadString(url1);
        }

        public List<TelegramResponse> Get_msg()
        {
            int update_id = 0;
            List<TelegramResponse> msgList = new List<TelegramResponse>();
            while (true)
            {
                string url = $"{startUrl}/getUpdates?offset={update_id + 1}";
                string response = webClient.DownloadString(url);
                var responseObject = JsonConvert.DeserializeObject<TelegramResponse>(response);
                var mes = responseObject.result;
                msgList.Add(responseObject);
                if (mes.Count > 0)
                {
                    update_id = mes.First().update_id;
                    foreach (var item in mes)
                    {
                        update_id = item.update_id;
                        webClient.DownloadString($"{startUrl}/getUpdates?offset={update_id}");
                    }
                    webClient.DownloadString($"{startUrl}/getUpdates?offset={update_id + 1}");
                }
                else
                {
                    break;
                }
            }
            return msgList;
        }
    }
}
