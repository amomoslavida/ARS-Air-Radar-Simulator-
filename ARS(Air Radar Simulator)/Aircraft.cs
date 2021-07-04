using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_Air_Radar_Simulator_ // Invoker
{
    class Aircraft : MapObject
    {
        public int x { get; set; }

        public int y { get; set; }
        public int range { get; set; }
        public bool isfriendlyonce { get; set; }
        public bool isShot { get; set; }
        public bool isSeen { get; set; }
        public bool isBombed { get; set; }
        private string[] types = { "FOE", "Friend", "Bogey" };
        private string signature; 

        public Aircraft()
        {
            Random rnd = new Random();
            int mIndex = rnd.Next(types.Length);
            signature = types[mIndex];
            
        }

        public string getType ()
        {
            return signature;
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
