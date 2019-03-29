using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tankmageddon.Nagibator.EventModules
{
    public static class LoopingModule
    {
        public static void Action(NagibatorTank me)
        {
            Console.WriteLine("Loop started");
            me.Ahead(5000);
            me.TurnRight(90);
        }
    }
}
