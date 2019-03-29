using Robocode;

namespace Tankmageddon.Nagibator.EventModules
{
    public static class OnStatusModule
    {
        public static void Action(NagibatorTank me, StatusEvent e)
        {
            me.Status = e.Status;
        }
    }
}
