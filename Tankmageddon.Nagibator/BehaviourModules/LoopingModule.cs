using System;

namespace Tankmageddon.Nagibator.BehaviourModules
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
