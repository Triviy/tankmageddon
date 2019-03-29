using System;

namespace Tankmageddon.Nagibator.BehaviourModules
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
