using System;
using System.Collections.Generic;
using Robocode.Util;
using Tankmageddon.Nagibator.Entities;
using static Tankmageddon.Nagibator.Constants.EnemyPositionMessage;

namespace Tankmageddon.Nagibator.BehaviourModules
{
    public static class ActionModule
    {
        private static readonly Random Random = new Random();

        public static void NewTargetAction(NagibatorTank me, Dictionary<string, string> message)
        {
            Console.WriteLine($"{nameof(ActionModule)}: Got new target {message[Name]}");
            me.Target = message[Name];
            me.TargetPoint = new Point
            {
                X = double.Parse(message[X]),
                Y = double.Parse(message[Y])
            };
            me.TargetBearing = double.Parse(message[Bearing]);
            me.TargetDistance = double.Parse(message[Distance]);

            Action(me);
        }

        public static void Action(NagibatorTank me)
        {
            if (me.TargetPoint == null)
            {
                Console.WriteLine($"{nameof(ActionModule)}: no target!");
                return;
            }

            var angleToTarget = Math.Atan2(me.TargetPoint.X - me.X, me.TargetPoint.Y - me.Y);
            Console.WriteLine($"{nameof(ActionModule)}: angle to target {angleToTarget}");

            me.TurnGunRightRadians(Utils.NormalRelativeAngle(angleToTarget - me.GunHeadingRadians));

            if (me.IsMovingToEnemy)
            {
                me.IsMovingToEnemy = me.TargetDistance <= 300;
            }
            else
            {
                me.IsMovingToEnemy = me.TargetDistance >= 700;
            }

            if (me.IsMovingToEnemy)
            {
                var x = me.TargetPoint.X - me.X;
                var y = me.TargetPoint.Y - me.Y;
                var goAngle = Utils.NormalRelativeAngle(Math.Atan2(x, y) - me.HeadingRadians);
                me.SetTurnRightRadians(Math.Atan(Math.Tan(goAngle)));
                me.SetAhead(Math.Cos(goAngle) * Hypotenuse(x, y) - 500);
            }
            else
            {
                if (Random.Next(0, 100) > 98 || me.Velocity == 0)
                    me.MoveDirection *= -1;
                me.SetTurnRight(me.TargetBearing + 90);
                me.SetAhead(1000 * me.MoveDirection);
            }
        }

        public static double Hypotenuse(double x, double y)
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }

    }
}
