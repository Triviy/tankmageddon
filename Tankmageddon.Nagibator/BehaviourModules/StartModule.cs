using System;
using Robocode;

namespace Tankmageddon.Nagibator.BehaviourModules
{

    public static class StartModule
    {
        public static void Action(NagibatorTank me)
        {
            Console.WriteLine("I'm started");
            me.IsAdjustGunForRobotTurn = true;
            me.IsAdjustRadarForRobotTurn = true;
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

            var triggerHitCondition = new Condition("too_close_to_walls", c =>
            {
                const int wallMargin = 100;
                return (
                    (me.X <= wallMargin ||
                     me.X >= me.BattleFieldWidth - wallMargin ||
                     me.Y <= wallMargin ||
                     me.Y >= me.BattleFieldHeight - wallMargin)
                );
            });
            me.AddCustomEvent(triggerHitCondition);
        }
    }
}
