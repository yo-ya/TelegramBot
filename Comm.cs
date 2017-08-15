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
        Msg msg = new Msg();
        WebClient webClient = new WebClient();
        public string Udaff()
        {
            string g = webClient.DownloadString("http://udaff.com/view_listen/photo/random.html");
            //string g = "<img src='/image/111/11109.jpg' width='400' height='300' alt='2' border='0' />";
            Regex regex = new Regex(@"\/image\/\d*.*.jpg");
            Match match = regex.Match(g);
            return "http://udaff.com/" + match.ToString();
        }

        public void ComResp(Msg msg)
        {

            if (msg.Text == "удаф")
            {
                c.SendPhoto((msg.Type == "group" ? msg.ChatId : msg.FromId), Udaff());
            }
            if (msg.Text == "да")
            {
                c.SendMsg((msg.Type == "group" ? msg.ChatId : msg.FromId), "манда!");
            }
        }
    }
}
