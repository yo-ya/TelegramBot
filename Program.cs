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
            bot.StartUrl = "https://api.telegram.org/bot349767489:AAFH2i94VcV9bl3RgTILJugxv6mYNTSEip8";
            List<TelegramResponse> list = new List<TelegramResponse>();
            list = bot.Get_msg();
            while (true)
            {
                list = bot.Get_msg();
                foreach (var item in list)
                {
                    if (item.result.Count > 0)
                    {
                        Console.WriteLine(item.result.First().message.text);
                        Comm m = new Comm();
                        m.ComResp(item);
                    }
                }
                Thread.Sleep(100);
            }
        }
    }
}
