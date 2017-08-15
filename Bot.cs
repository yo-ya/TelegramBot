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
        string startUrl = $"https://api.telegram.org/bot349767489:AAFH2i94VcV9bl3RgTILJugxv6mYNTSEip8";

        public string StartUrl { get => startUrl; set => startUrl = value; }

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

        public List<Msg> Get_msg()
        {
            int update_id = 0;
            List<Msg> msgList = new List<Msg>();
            while (true)
            {
                string url = $"{startUrl}/getUpdates?offset={update_id + 1}";
                string response = webClient.DownloadString(url);
                if ((response != $"{{\"ok\":true,\"result\":[]}}"))
                {
                    var col = JObject.Parse(response)["result"].ToArray();
                    foreach (var ans in col)
                    {
                        update_id = Convert.ToInt32(ans["update_id"]);
                        try
                        {
                            Msg msg = new Msg();
                            msg.UpdateId = Convert.ToInt32(update_id);
                            msg.FromId = ans["message"]["from"]["id"].ToString();
                            msg.Text = ans["message"]["text"].ToString();
                            msg.Type = ans["message"]["chat"]["type"].ToString();
                            msg.ChatId = ans["message"]["chat"]["id"].ToString();
                            msgList.Add(msg);
                        }
                        catch { }
                    }
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
