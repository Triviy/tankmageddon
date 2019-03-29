using System;
using System.Collections.Generic;
using System.Globalization;
using Robocode;
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
                var enemyPos = CoordHelper.GetEnemyCoordinate(me.Heading, me.Status, e);
                if (string.IsNullOrWhiteSpace(me.Target))
                {
                    Console.WriteLine($"{nameof(OnMessageReceivedModule)}: Setting team target {e.Name}");
                    me.Target = e.Name;

                    MessageHelper.SendMessage(me, new Dictionary<string, string>
                    {
                        [Constants.MessageType] = Constants.EnemyPositionMessage.Type,
                        [Name] = e.Name,
                        [X] = enemyPos.X.ToString(CultureInfo.InvariantCulture),
                        [Y] = enemyPos.Y.ToString(CultureInfo.InvariantCulture)
                    });
                }

                if (me.Target.Equals(e.Name))
                {
                    Console.WriteLine($"{nameof(OnMessageReceivedModule)}: Fire to {e.Name}");
                    me.SetFire(3);
                    me.TargetPoint = enemyPos;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{nameof(OnMessageReceivedModule)}: {ex}");
            }
        }
    }
}
