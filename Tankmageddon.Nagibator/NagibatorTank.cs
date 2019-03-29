using Robocode;
using Tankmageddon.Nagibator.EventModules;

namespace Tankmageddon.Nagibator
{
    public class NagibatorTank : TeamRobot
    {
        public RobotStatus Status { get; set; }

        public override void OnScannedRobot(ScannedRobotEvent e) => OnScannedRobotModule.Action(this, e);
        public override void OnStatus(StatusEvent e) => OnStatusModule.Action(this, e);

        public override void Run()
        {
            TurnLeft(Heading - 90);
            TurnGunRight(90);

            while (true)
            {
                Ahead(5000);
                TurnRight(90);
            }
        }
    }
}
