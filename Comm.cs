using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TelegramBot
{
    class Comm
    {
        Bot c = new Bot();
        TelegramResponse msg = new TelegramResponse();
        WebClient webClient = new WebClient();
        public string Udaff()
        {
            string g = webClient.DownloadString("http://udaff.com/view_listen/photo/random.html");
            //string g = "<img src='/image/111/11109.jpg' width='400' height='300' alt='2' border='0' />";
            Regex regex = new Regex(@"\/image\/\d*.*.jpg");
            Match match = regex.Match(g);
            return "http://udaff.com/" + match.ToString();
        }

        public void ComResp(TelegramResponse msg)
        {
            string word = msg.result.First().message.text;
            string messageType = msg.result.First().message.chat.type;
            int chatId = msg.result.First().message.chat.id;
            int fromId = msg.result.First().message.from.id;
            switch (word)
            {
                case "удаф":
                    {
                        c.SendPhoto((messageType == "group" ? chatId : fromId).ToString(), Udaff());
                        break;
                    }
                case "да":
                    {
                        c.SendMsg((messageType == "group" ? chatId : fromId).ToString(), "манда!");
                        break;
                    }
            }
            //if (msg.result.First().message.text == "удаф")
            //{
            //    c.SendPhoto((msg.result.First().message.chat.type == "group" ? msg.result.First().message.chat.id : msg.result.First().message.from.id).ToString(), Udaff());
            //}
            //if (msg.result.First().message.text == "да")
            //{
            //    c.SendMsg((msg.result.First().message.chat.type == "group" ? msg.result.First().message.chat.id : msg.result.First().message.from.id).ToString(), "манда!");
            //}
        }
    }
}
