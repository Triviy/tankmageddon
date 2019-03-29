using System;
using Robocode;
using Tankmageddon.Nagibator.EventModules;

namespace Tankmageddon.Nagibator
{
    public class NagibatorTank : TeamRobot
    {
        public RobotStatus Status { get; set; }

        public override void OnScannedRobot(ScannedRobotEvent e) => OnScannedRobotModule.Action(this, e);
        public override void OnStatus(StatusEvent e) => OnStatusModule.Action(this, e);
        public override void OnMessageReceived(MessageEvent e) => OnMessageReceivedModule.Action(this, e);

        public override void Run()
        {
            StartModule.Action(this);
            while (true)
                LoopingModule.Action(this);
        }
    }
}
