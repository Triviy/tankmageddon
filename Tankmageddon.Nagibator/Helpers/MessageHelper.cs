using System.Collections.Generic;
using System.Linq;

namespace Tankmageddon.Nagibator.Helpers
{
    public static class MessageHelper
    {
        private const char Separator = '&';
        private const char KvpSeparator = '=';

        public static void SendMessage(NagibatorTank me, Dictionary<string, string> message)
        {
            var strMessage = string.Join(Separator.ToString(), message.Select(m => $"{m.Key}{KvpSeparator}{m.Value}"));
            foreach (var teammate in me.Teammates)
                me.SendMessage(teammate, strMessage);
        }

        public static Dictionary<string, string> ReadMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                return new Dictionary<string, string>();
            var list = message.Split(Separator);
            return list.ToDictionary(l => l.Split(KvpSeparator).First(), l => l.Split(KvpSeparator).Last());
        }
    }
}
