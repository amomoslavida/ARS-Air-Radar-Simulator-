using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_Air_Radar_Simulator_
{
    interface MapObject
    {
        int x
        {
            get;
            set;
        }

        int y
        {
            get;
            set;
        }


        public string getLocation();
        

    }
}
