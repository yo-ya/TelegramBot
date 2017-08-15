using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TelegramBot
{
    class Program
    {

        static void Main(string[] args)
        {
            Bot bot = new Bot();
            List<Msg> list = new List<Msg>();
            list = bot.Get_msg(); //init
            while (true)
            {
                list = bot.Get_msg();
                foreach (var item in list)
                {
                    Comm m = new Comm();
                    m.ComResp(item);

                }
                Thread.Sleep(100);
            }
        }
    }
}
