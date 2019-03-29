using System;
using Robocode;
using Tankmageddon.Nagibator.Helpers;
using static Tankmageddon.Nagibator.Constants;

namespace Tankmageddon.Nagibator.EventModules
{
    public static class OnMessageReceivedModule
    {
        public static void Action(NagibatorTank me, MessageEvent e)
        {
            Console.WriteLine($"I've got {e.Message}");
            var message = MessageHelper.ReadMessage(e.Message.ToString());
            switch (message[MessageType])
            {
                case EnemyPositionMessage.Type:

                default:
                    return;
            }

        }
    }
}
