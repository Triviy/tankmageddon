using System;
using Robocode;

namespace Tankmageddon.Nagibator.EventModules
{
    public static class OnScannedRobotModule
    {
        public static void Action(NagibatorTank me, ScannedRobotEvent e)
        {
            if (me.IsTeammate(e.Name))
                return;

            try
            {
                var angleToEnemy = e.Bearing;

                // Calculate the angle to the scanned robot
                var angle = ConvertToRadians(me.Heading + angleToEnemy % 360);

                // Calculate the coordinates of the robot
                var enemyX = (me.Status.X + Math.Sin(angle) * e.Distance);
                var enemyY = (me.Status.Y + Math.Cos(angle) * e.Distance);

                me.BroadcastMessage($"{enemyX}:{enemyY}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}: {ex.StackTrace}");
            }


            me.SetFire(3);
        }

        public static double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }
    }
}
