using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robocode;
using Tankmageddon.Nagibator.Entities;

namespace Tankmageddon.Nagibator.Helpers
{
    public static class CoordHelper
    {
        public static Point GetEnemyCoordinate(double heading, RobotStatus myStatus, ScannedRobotEvent e)
        {
            var angle = ConvertToRadians(heading + e.Bearing % 360);
            return new Point
            {
                X = (myStatus.X + Math.Sin(angle) * e.Distance),
                Y = (myStatus.Y + Math.Cos(angle) * e.Distance)
            };
        }

        public static double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }
    }
}
