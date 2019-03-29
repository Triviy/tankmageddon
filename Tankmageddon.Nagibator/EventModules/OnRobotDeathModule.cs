using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robocode;

namespace Tankmageddon.Nagibator.EventModules
{
    public static class OnRobotDeathModule
    {
        public static void Action(NagibatorTank me, RobotDeathEvent e)
        {
            Console.WriteLine($"{nameof(OnRobotDeathModule)}: {e.Name}");
            e.Priority = 0;
            if (me.Target?.Equals(e.Name) == true)
            {
                me.Target = null;
                Console.WriteLine($"{nameof(OnRobotDeathModule)}: Set target to NULL");
            }
        }
    }
}
