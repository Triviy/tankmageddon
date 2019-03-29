using System;
using Robocode;

namespace Tankmageddon.Nagibator.EventModules
{
    public static class OnMessageReceivedModule
    {
        public static void Action(NagibatorTank me, MessageEvent e)
        {
            Console.WriteLine($"I've got {e.Message}");
        }
    }
}
