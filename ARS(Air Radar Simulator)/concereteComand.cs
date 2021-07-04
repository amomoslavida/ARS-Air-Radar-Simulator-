using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_Air_Radar_Simulator_
{
    class concereteComand : Command
    {
        private AirDefenseBattery airdefense;

        public concereteComand(AirDefenseBattery defenseBattery)
        {
            this.airdefense = defenseBattery;
        }

        public string Execute()
        {
            string launch = this.airdefense.missilelaunch();
            return launch;
        }
    }
}
