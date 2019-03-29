using System;
using System.Collections.Generic;
using Robocode.Util;
using Tankmageddon.Nagibator.Entities;
using static Tankmageddon.Nagibator.Constants.EnemyPositionMessage;

namespace Tankmageddon.Nagibator.BehaviourModules
{
    public static class AttackTargetModule
    {
        public static void Action(NagibatorTank me, Dictionary<string, string> message)
        {
            Console.WriteLine($"{nameof(AttackTargetModule)}: Got new target {message[Name]}");

            me.Target = message[Name];
            me.TargetPoint = new Point
            {
                X = double.Parse(message[X]),
                Y = double.Parse(message[Y])
            };
            Action(me);
        }

        public static void Action(NagibatorTank me)
        {
            if (me.TargetPoint == null)
                Console.WriteLine($"{nameof(AttackTargetModule)}: no target!");
            var angleToTarget = Math.Atan2(me.TargetPoint.X - me.X, me.TargetPoint.Y - me.Y);
            var targetAngle = Utils.NormalRelativeAngle(angleToTarget - me.HeadingRadians) - 90;
            Console.WriteLine($"{nameof(AttackTargetModule)}: turning to {targetAngle}");
            me.SetTurnRightRadians(targetAngle);
        }
    }
}
