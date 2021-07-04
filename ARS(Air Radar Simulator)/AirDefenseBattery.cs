using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_Air_Radar_Simulator_
{
    class AirDefenseBattery : MapObject
    {
        public int x { get; set; }

        public int y { get; set; }

        public int range { get; set; }

        public AirDefenseBattery()
        {

        }

  

        public string getLocation()
        {
            string xpoint = x.ToString();
            string ypoint = y.ToString();
            string point = xpoint + "," + ypoint;
            return point;
        }
        public string missilelaunch()
        {
            return "Aircraft shot at : ";
        }
   
    }
}
