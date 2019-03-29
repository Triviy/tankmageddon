using System;
using System.Collections.Generic;
using System.Globalization;
using Robocode;
using Robocode.Util;
using Tankmageddon.Nagibator.BehaviourModules;
using Tankmageddon.Nagibator.Helpers;
using static Tankmageddon.Nagibator.Constants.EnemyPositionMessage;

namespace Tankmageddon.Nagibator.EventModules
{
    public static class OnScannedRobotModule
    {
        public static void Action(NagibatorTank me, ScannedRobotEvent e)
        {
            try
            {
                if (me.IsTeammate(e.Name))
                    return;
                Console.WriteLine($"{nameof(OnScannedRobotModule)}: spotted [{e.Name}]. My target is [{me.Target}]");

                var enemyPosition = CoordHelper.GetEnemyCoordinate(me.Heading, me.Status, e);
                if (string.IsNullOrWhiteSpace(me.Target))
                {
                    Console.WriteLine($"{nameof(OnScannedRobotModule)}: Setting team target {e.Name}");
                    me.Target = e.Name;
                }

                if (me.Target.Equals(e.Name))
                {
                    me.SetTurnRadarRight(2.0 * Utils.NormalRelativeAngleDegrees(me.Heading + e.Bearing - me.RadarHeading));
                    GunModule.Action(me);
                    Console.WriteLine($"{nameof(OnScannedRobotModule)}: Fire to {e.Name}");
                    me.Fire(FireHelper.GetFirePower(e, me.TargetPoint, enemyPosition));

                    MessageHelper.SendMessage(me, new Dictionary<string, string>
                    {
                        [Constants.MessageType] = Constants.EnemyPositionMessage.Type,
                        [Name] = e.Name,
                        [X] = enemyPosition.X.ToString(CultureInfo.InvariantCulture),
                        [Y] = enemyPosition.Y.ToString(CultureInfo.InvariantCulture)
                    });

                    me.TargetPoint = enemyPosition;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{nameof(OnScannedRobotModule)}: {ex}");
            }
        }
    }
}
