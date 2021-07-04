using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_Air_Radar_Simulator_
{
    class City : MapObject
    {
        public int x { get; set; }

        public int y { get; set; }

        public City()
        {

        }

  
        public string getLocation()
        {
            string xpoint = x.ToString();
            string ypoint = y.ToString();
            string point = xpoint + "," + ypoint;
            return point;
        }


    }
}
