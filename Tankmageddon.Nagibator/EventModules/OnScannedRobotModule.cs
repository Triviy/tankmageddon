using System;
using Robocode;
using Tankmageddon.Nagibator.Helpers;

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
                foreach (var mate in me.Teammates)
                    me.SendMessage(mate, $"{enemyPos.X}:{enemyPos.Y}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            me.SetFire(3);
        }
    }
}
