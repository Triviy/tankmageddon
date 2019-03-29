using System;
using Robocode;
using Tankmageddon.Nagibator.Entities;

namespace Tankmageddon.Nagibator.Helpers
{
    public static class FireHelper
    {
        public static double GetFirePower(ScannedRobotEvent e, Point oldTargetPosition, Point newTargetPosition)
        {
            double firePower = Math.Min(400 / e.Distance, 3);

            if (oldTargetPosition == null || newTargetPosition == null) return firePower;

            if (IsTheSamePosition(oldTargetPosition, newTargetPosition) || e.Energy == 0)
            {
                firePower = 3;
            }
            return firePower;
        }

        private static bool IsTheSamePosition(Point oldPosition, Point newPosition)
        {
            return (Math.Round(oldPosition.X) == Math.Round(newPosition.X)) &&
                   (Math.Round(oldPosition.Y) == Math.Round(newPosition.Y));
        }
    }
}
