using System;
using Robocode;

namespace Tankmageddon.Nagibator.BehaviourModules
{
    public static class StartModule
    {
        public static void Action(NagibatorTank me)
        {
            Console.WriteLine("I'm started");

            foreach (var gameEvent in me.GetAllEvents())
            {
                switch (gameEvent)
                {
                    case DeathEvent deathEvent:
                        deathEvent.Priority = 0;
                        break;
                    case StatusEvent statusEvent:
                        statusEvent.Priority = 1;
                        break;
                    case ScannedRobotEvent scannedRobotEvent:
                        scannedRobotEvent.Priority = 2;
                        break;
                    case MessageEvent messageEvent:
                        messageEvent.Priority = 3;
                        break;
                }
            }
            me.TurnGunRight(90);
            me.TurnLeft(me.Heading - 15);
        }
    }
}
