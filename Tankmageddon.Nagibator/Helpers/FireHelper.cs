using System;
using Robocode;
using Tankmageddon.Nagibator.Entities;

namespace Tankmageddon.Nagibator.Helpers
{
    public static class FireHelper
    {
        public static double GetFirePower(NagibatorTank me, ScannedRobotEvent e, Point newTargetPosition)
        {
            double firePower = Math.Min(400 / e.Distance, 3);

            if (me.TargetPoint == null || newTargetPosition == null) return firePower;

            if (IsTheSamePosition(me.TargetPoint, newTargetPosition) || e.Energy < 3)
                return 3;
            if (Math.Abs(Math.Abs(e.Heading) - Math.Abs(me.GunHeading)) < 3)
                return firePower * 1.5;
            return firePower;
        }

        private static bool IsTheSamePosition(Point oldPosition, Point newPosition)
        {
            return (Math.Round(oldPosition.X) == Math.Round(newPosition.X)) &&
                   (Math.Round(oldPosition.Y) == Math.Round(newPosition.Y));
        }
    }
}
