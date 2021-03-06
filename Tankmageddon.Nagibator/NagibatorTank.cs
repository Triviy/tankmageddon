﻿using System;
using Robocode;
using Tankmageddon.Nagibator.BehaviourModules;
using Tankmageddon.Nagibator.Entities;
using Tankmageddon.Nagibator.EventModules;

namespace Tankmageddon.Nagibator
{
    public class NagibatorTank : TeamRobot
    {
        public string Target { get; set; }
        public Point TargetPoint { get; set; }
        public double TargetBearing { get; set; }
        public double TargetDistance { get; set; }

        public bool IsMovingToEnemy { get; set; }
        public RobotStatus Status { get; set; }
        public int CurrentEnemiesAlive { get; set; }
        public int MoveDirection { get; set; } = 1;

        public override void OnScannedRobot(ScannedRobotEvent e) => OnScannedRobotModule.Action(this, e);
        public override void OnStatus(StatusEvent e) => OnStatusModule.Action(this, e);
        public override void OnMessageReceived(MessageEvent e) => OnMessageReceivedModule.Action(this, e);
        public override void OnRobotDeath(RobotDeathEvent e) => OnRobotDeathModule.Action(this, e);
        public override void OnCustomEvent(CustomEvent e) => OnCustomEventModule.Action(this, e);

        public override void Run()
        {
            StartModule.Action(this);
            while (true)
                LoopingModule.Action(this);
        }
    }
}
