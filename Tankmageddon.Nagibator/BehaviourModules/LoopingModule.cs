using System;

namespace Tankmageddon.Nagibator.BehaviourModules
{
    public static class LoopingModule
    {
        public static void Action(NagibatorTank me)
        {
            Console.WriteLine("Loop started");

            if (!string.IsNullOrWhiteSpace(me.Target))
            {
                AttackTargetModule.Action(me);
                return;
            }

            me.Ahead(5000);
            me.TurnRight(90);
        }
    }
}
