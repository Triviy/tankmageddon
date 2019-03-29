using System;
using System.Collections.Generic;
using Robocode.Util;
using Tankmageddon.Nagibator.Entities;
using static Tankmageddon.Nagibator.Constants.EnemyPositionMessage;

namespace Tankmageddon.Nagibator.BehaviourModules
{
    public static class AttackTargetModule
    {
        public static void NewTargetAction(NagibatorTank me, Dictionary<string, string> message)
        {
            Console.WriteLine($"{nameof(AttackTargetModule)}: Got new target {message[Name]}");
            if (!string.IsNullOrWhiteSpace(me.Target))
                return;
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

            //me.SetTurnRightRadians(Utils.NormalRelativeAngle(angleToTarget - me.HeadingRadians));
            me.SetTurnGunRightRadians(Utils.NormalRelativeAngle(angleToTarget - me.GunHeadingRadians));
            me.Fire(3);
            //me.SetTurnRadarLeftRadians(Utils.NormalRelativeAngle(angleToTarget - me.RadarHeadingRadians));
        }
    }
}
