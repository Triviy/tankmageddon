using System;
using System.Collections.Generic;
using Robocode.Util;
using static Tankmageddon.Nagibator.Constants.EnemyPositionMessage;

namespace Tankmageddon.Nagibator.BehaviourModules
{
    public static class AttackTargetModule
    {
        public static void Action(NagibatorTank me, Dictionary<string, string> message)
        {
            Console.WriteLine($"{nameof(AttackTargetModule)}: Got new target {message[Name]}");

            me.Target = message[Name];
            var x = double.Parse(message[X]);
            var y = double.Parse(message[Y]);

            var angleToTarget = Math.Atan2(x, y);
            var targetAngle = Utils.NormalRelativeAngle(angleToTarget - me.HeadingRadians);
            //me.SetTurnRightRadians(targetAngle);
        }
    }
}
