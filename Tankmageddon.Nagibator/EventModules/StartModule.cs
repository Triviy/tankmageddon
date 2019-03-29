using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tankmageddon.Nagibator.EventModules
{
    public static class StartModule
    {
        public static void Action(NagibatorTank me)
        {
            Console.WriteLine("I'm started");
            me.TurnLeft(me.Heading - 90);
            me.TurnGunRight(90);
        }
    }
}
