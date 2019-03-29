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
                MessageHelper.SendMessage(me, new Dictionary<string, string>
                {
                    [Constants.MessageType] = Constants.EnemyPositionMessage.Type,
                    [Name] = e.Name,
                    [X] = enemyPos.X.ToString(CultureInfo.InvariantCulture),
                    [Y] = enemyPos.Y.ToString(CultureInfo.InvariantCulture)
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            me.SetFire(3);
        }
    }
}
