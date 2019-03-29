using System;
using System.Linq;

namespace Tankmageddon.Nagibator.BehaviourModules
{
    public static class LoopingModule
    {
        public static void Action(NagibatorTank me)
        {
            Console.WriteLine("Loop started");

            me.SetTurnRadarRight(double.PositiveInfinity);

            if (me.CurrentEnemiesAlive != me.Others)
            {
                me.Target = null;
                me.CurrentEnemiesAlive = me.Others;
            }

            if (!string.IsNullOrWhiteSpace(me.Target))
            {
                ActionModule.Action(me);
            }

            me.Ahead(5000);
            me.TurnRight(90);
        }
    }
}
