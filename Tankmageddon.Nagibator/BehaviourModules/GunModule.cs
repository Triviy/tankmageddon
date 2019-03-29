using System;
using System.Collections.Generic;
using Robocode.Util;
using Tankmageddon.Nagibator.Entities;
using static Tankmageddon.Nagibator.Constants.EnemyPositionMessage;

namespace Tankmageddon.Nagibator.BehaviourModules
{
    public static class GunModule
    {
        private static readonly Random Random = new Random();

        public static void NewTargetAction(NagibatorTank me, Dictionary<string, string> message)
        {
            Console.WriteLine($"{nameof(GunModule)}: Got new target {message[Name]}");
            me.Target = message[Name];
            me.TargetPoint = new Point
            {
                X = double.Parse(message[X]),
                Y = double.Parse(message[Y])
            };
            me.TargetBearing = double.Parse(message[Bearing]);

            Action(me);
        }

        public static void Action(NagibatorTank me)
        {
            if (me.TargetPoint == null)
            {
                Console.WriteLine($"{nameof(GunModule)}: no target!");
                return;
            }

            var angleToTarget = Math.Atan2(me.TargetPoint.X - me.X, me.TargetPoint.Y - me.Y);
            Console.WriteLine($"{nameof(GunModule)}: angle to target {angleToTarget}");
            me.TurnGunRightRadians(Utils.NormalRelativeAngle(angleToTarget - me.GunHeadingRadians));

            if (Random.Next(0, 100) > 95 || me.Velocity == 0)
                me.MoveDirection *= -1;

            // circle our enemy

            me.SetTurnRight(me.TargetBearing + 90);
            me.SetAhead(1000 * me.MoveDirection);
        }
    }
}
