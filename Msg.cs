using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot
{
    class Msg
    {
        int updateId;
        string type;
        string text;
        string fromId;
        string chatId;

        public int UpdateId { get => updateId; set => updateId = value; }
        public string Type { get => type; set => type = value; }
        public string Text { get => text; set => text = value; }
        public string FromId { get => fromId; set => fromId = value; }
        public string ChatId { get => chatId; set => chatId = value; }
    }
}
