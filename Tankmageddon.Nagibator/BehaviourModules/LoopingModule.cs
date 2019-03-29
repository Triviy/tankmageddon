using System;
using System.Linq;

namespace Tankmageddon.Nagibator.BehaviourModules
{
    public static class LoopingModule
    {
        public static void Action(NagibatorTank me)
        {
            me.SetTurnRadarRight(double.PositiveInfinity);

            if (me.GetRobotDeathEvents()?.Any(e => e.Name.Equals(me.Target)) == true)
                me.Target = null;

            Console.WriteLine("Loop started");

            if (!string.IsNullOrWhiteSpace(me.Target))
            {
                GunModule.Action(me);
                return;
            }

            me.Ahead(5000);
            me.TurnRight(90);
        }
    }
}
