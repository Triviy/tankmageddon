using System;
using Robocode;

namespace Tankmageddon.Nagibator.EventModules
{
    public static class OnCustomEventModule
    {
        public static void Action(NagibatorTank me, CustomEvent e)
        {
            Console.WriteLine($"{nameof(OnCustomEventModule)}: {e.Condition.Name}");

            if (e.Condition.Name.Equals("too_close_to_walls"))
                me.MoveDirection *= -1;
        }
    }
}
