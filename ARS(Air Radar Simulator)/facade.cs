using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS_Air_Radar_Simulator_
{
    class facade
    {
        private int mapSize;
        private int radarRange;
        private int missileRange;
        private int planeRange;
        private int numofPlanes;
        private int numOfAirDefenseBatteries;
        private int numOfAirRadar;
        private int numofCities;
        private List<Aircraft> aircraft = new List<Aircraft>();
        private List<AirDefenseBattery> airDefenseBattery = new List<AirDefenseBattery>();
        private List<AirRadar> airRadar = new List<AirRadar>();
        private List<City> city = new List<City>();
        string folder = @"C:\Users\bulut\source\repos\ARS(Air Radar Simulator)\ARS(Air Radar Simulator)";
        string filename = "radarlog.txt";
        FileStream ostrm;
        StreamWriter writer;
        TextWriter oldOut = Console.Out;

        public facade()
        {
            entranceToProgram();

        }

        private void entranceToProgram()
        {
            string rawinput;
            int uinput;
            Console.WriteLine("Welcome to the Air Defense System! ");
            Console.WriteLine("This is a program for simulating and obversing an Air Defense System(ARS) in a randomized action.You can enter your own parameters, or Try a premade simulation.");
            Console.WriteLine("Note that this simulation results are recorded to a .txt file inside this program.");
            Console.WriteLine("Press 1 to try a pre-made simulation");
            Console.WriteLine("Press 2 to enter your own parameters.");
            Console.WriteLine("Press any other number to  to exit the program");
            rawinput = Console.ReadLine();
            uinput = Convert.ToInt32(rawinput);

            switch (uinput)
            {
                case 1:
                    premadeSimulator();
                    break;
                case 2:
                    userMadeSimulator();
                    break;
                default:
                    break;

            }

        }

        private void userMadeSimulator()
        {
            Console.WriteLine("Please only enter Integers unless specified");
            
            Console.WriteLine("Please enter the Map Size (For reference, default is 100)");
            string sizeofMap = Console.ReadLine();
            mapSize = Convert.ToInt32(sizeofMap);
            
            Console.WriteLine("Please enter the radar range (For reference, default is 20)");
            string rangeRadar = Console.ReadLine();
            radarRange = Convert.ToInt32(rangeRadar);
            
            Console.WriteLine("Please enter the missile range (For reference, default is 40)");
            string rangeMissile = Console.ReadLine();
            missileRange = Convert.ToInt32(rangeMissile);

            Console.WriteLine("Please enter the aircraft Range (For reference, default is 10)");
            string rangeAircraft = Console.ReadLine();
            planeRange = Convert.ToInt32(rangeAircraft);

            Console.WriteLine("Please enter the number of aircraft (For reference, default is 10)");
            string planeNumber = Console.ReadLine();
            numofPlanes = Convert.ToInt32(planeNumber);

            Console.WriteLine("Please enter the number of air defense batteries (For reference, default is 2)");
            string airdefensebatteriesNumber = Console.ReadLine();
            numOfAirDefenseBatteries = Convert.ToInt32(airdefensebatteriesNumber);

            Console.WriteLine("Please enter the number of air radars (For reference, default is 4)");
            string airradarNumber = Console.ReadLine();
            numOfAirRadar = Convert.ToInt32(airradarNumber);

            Console.WriteLine("Please enter the number of cities (For reference, default is 4)");
            string cityNumber = Console.ReadLine();
            numOfAirRadar = Convert.ToInt32(cityNumber);


            airRadarCreator(numOfAirRadar, radarRange);
            airRadarCount(airRadar);

            airDefenseCreator(numOfAirDefenseBatteries, missileRange);
            airDefenceCount(airDefenseBattery);

            cityCreator(numofCities);
            cityCount(city);

            Console.WriteLine("Starting the simulation...");

            aircraftCreator(numofPlanes, planeRange);
            detection(aircraft, airRadar, city, airDefenseBattery);
        }

        private void premadeSimulator()
        {
            mapSize = 100;
            radarRange = 20;
            missileRange = 40;
            planeRange = 10;
            numofPlanes = 10;
            numOfAirDefenseBatteries = 2;
            numOfAirRadar = 4;
            numofCities = 4;
            airRadarCreator(numOfAirRadar, radarRange);
            airRadarCount(airRadar);

            airDefenseCreator(numOfAirDefenseBatteries, missileRange);
            airDefenceCount(airDefenseBattery);

            cityCreator(numofCities);
            cityCount(city);

            Console.WriteLine("Starting the simulation...");

            aircraftCreator(numofPlanes, planeRange);
            detection(aircraft, airRadar, city, airDefenseBattery);






        }
        private void airRadarCreator(int radarCount, int radarR)
        {
            for (int i = 0; i < radarCount; i++)
            {

                var dupes = airRadar.Select((a, b) => new { index = b, value = a })
                   .GroupBy(a => new { a.value.x, a.value.y })
                   .Where(a => a.Skip(1).Any());
                if (!dupes.Any())
                {
                    Random rnd = new Random();
                    int randomx = rnd.Next(mapSize);
                    int randomy = rnd.Next(mapSize);
                    if (randomx != 100)
                    {
                        airRadar.Add(new AirRadar() { x = randomx + 1, y = randomy, range = radarR });
                    }
                    else
                    {
                        airRadar.Add(new AirRadar() { x = randomx - 1, y = randomy, range = radarR });
                    }
                }
                else
                {
                    Random rnd = new Random();
                    int randomx = rnd.Next(mapSize);
                    int randomy = rnd.Next(mapSize);

                    airRadar.Add(new AirRadar() { x = randomx, y = randomy, range = radarR });
                }

            }
        }
        private void airDefenseCreator(int defenceCount, int missileRange)
        {
            for (int i = 0; i < defenceCount; i++)
            {

                var dupes = airDefenseBattery.Select((a, b) => new { index = b, value = a, range = missileRange })
                   .GroupBy(a => new { a.value.x, a.value.y })
                   .Where(a => a.Skip(1).Any());
                if (!dupes.Any())
                {
                    Random rnd = new Random();
                    int randomx = rnd.Next(mapSize);
                    int randomy = rnd.Next(mapSize);
                    if (randomx != 100)
                    {
                        airDefenseBattery.Add(new AirDefenseBattery() { x = randomx + 1, y = randomy, range = missileRange });
                    }
                    else
                    {
                        airDefenseBattery.Add(new AirDefenseBattery() { x = randomx - 1, y = randomy, range = missileRange });
                    }
                }
                else
                {
                    Random rnd = new Random();
                    int randomx = rnd.Next(mapSize);
                    int randomy = rnd.Next(mapSize);

                    airDefenseBattery.Add(new AirDefenseBattery() { x = randomx, y = randomy });
                }

            }
        }

        private void cityCreator(int cityCount)
        {
            for (int i = 0; i < cityCount; i++)
            {

                var dupes = city.Select((a, b) => new { index = b, value = a })
                   .GroupBy(a => new { a.value.x, a.value.y })
                   .Where(a => a.Skip(1).Any());
                if (!dupes.Any())
                {
                    Random rnd = new Random();
                    int randomx = rnd.Next(mapSize);
                    int randomy = rnd.Next(mapSize);
                    if (randomx != 100)
                    {
                        city.Add(new City() { x = randomx + 1, y = randomy });
                    }
                    else
                    {
                        city.Add(new City() { x = randomx - 1, y = randomy });
                    }
                }
                else
                {
                    Random rnd = new Random();
                    int randomx = rnd.Next(mapSize);
                    int randomy = rnd.Next(mapSize);

                    city.Add(new City() { x = randomx, y = randomy });
                }

            }
        }

        private void aircraftCreator(int planeCount, int prange)
        {
            for (int i = 0; i < planeCount; i++)
            {



                Random rnd = new Random();
                int randomx = rnd.Next(mapSize);
                int randomy = rnd.Next(mapSize);

                aircraft.Add(new Aircraft() { x = randomx, y = randomy, range = prange });



            }

        }
        private void airRadarCount(List<AirRadar> radars)
        {
            Console.WriteLine("creating air Radar Installations at these coordinates :");
            for (int i = 0; i < radars.Count; i++)
            {
                Console.WriteLine(radars.ElementAt(i).getLocation());
            }

        }
        private void cityCount(List<City> cities)
        {
            Console.WriteLine("creating cities at these coordinates :");
            for (int i = 0; i < cities.Count; i++)
            {
                Console.WriteLine(cities.ElementAt(i).getLocation());
            }

        }
        private void airDefenceCount(List<AirDefenseBattery> airDefenseBatteries)
        {
            Console.WriteLine("creating air defence at these coordinates :");
            for (int i = 0; i < airDefenseBatteries.Count; i++)
            {
                Console.WriteLine(airDefenseBatteries.ElementAt(i).getLocation());
            }

        }

        private void detection(List<Aircraft> aircraft, List<AirRadar> radars, List<City> cities, List<AirDefenseBattery> airDefenseBatteries)
        {

            for (int i = 0; i < aircraft.Count(); i++)
            {
                for (int j = 0; j < radars.Count(); j++)
                {


                    int radarDistanceX = Math.Abs(radars.ElementAt(j).x - aircraft.ElementAt(i).x);
                    int radarDistanceY = Math.Abs(radars.ElementAt(j).y - aircraft.ElementAt(i).y);
                    double radarResult = Math.Abs(Math.Sqrt(radarDistanceX * radarDistanceX + radarDistanceY * radarDistanceY));
                    double radarCompare = Convert.ToDouble(radars.ElementAt(j).range);


                    if (radarResult < radarCompare && aircraft.ElementAt(i).isShot == false)
                    {
                        if (aircraft.ElementAt(i).getType() == "FOE" || aircraft.ElementAt(i).getType() == "Bogey")
                        {

                            for (int k = 0; k < airDefenseBatteries.Count(); k++)
                            {
                                int missileDistanceX = Math.Abs(airDefenseBatteries.ElementAt(k).x - aircraft.ElementAt(i).x);
                                int missileDistanceY = Math.Abs(airDefenseBatteries.ElementAt(k).y - aircraft.ElementAt(i).y);
                                double missileResult = Math.Abs(Math.Sqrt(missileDistanceX * missileDistanceX + missileDistanceY * missileDistanceY));
                                double missileCompare = Convert.ToDouble(airDefenseBatteries.ElementAt(k).range);
                                

                                if (missileResult < missileCompare)
                                {
                                    radars.ElementAt(j).initCommand(command: new concereteComand(airDefenseBatteries.ElementAt(k)));
                                    string radarString = radars.ElementAt(j).missileOrder();
                                    string aircraftString = aircraft.ElementAt(i).getLocation();
                                    Logger.WriteLine(radarString + aircraftString);
                                    Logger.SaveLog();
                                    aircraft.ElementAt(i).isShot = true;
                                }
                                else
                                {
                                    for (int z = 0; z < cities.Count(); z++)
                                    {
                                        int cityDistancex = Math.Abs(aircraft.ElementAt(i).x - cities.ElementAt(z).x);
                                        int cityDistanceY = Math.Abs(aircraft.ElementAt(i).y - cities.ElementAt(z).y);
                                        double cityResult = Math.Abs(Math.Sqrt(cityDistancex * cityDistancex + cityDistanceY * cityDistanceY));
                                        double cityCompare = Convert.ToDouble(aircraft.ElementAt(z).range);
                                        if (cityResult < cityCompare && aircraft.ElementAt(i).isBombed == false)
                                        {
                                            string cityString = cities.ElementAt(z).getLocation();
                                            string bombingString = aircraft.ElementAt(i).getLocation();
                                            Logger.WriteLine("Our city the the coordinates of : " + cityString + " bombed by the aircraft from " + bombingString + "");
                                            aircraft.ElementAt(i).isBombed = true;
                                            Logger.SaveLog();
                                        }
                                        else if (aircraft.ElementAt(i).isSeen == false)
                                        {
                                            string bombingString = aircraft.ElementAt(i).getLocation();
                                            Logger.WriteLine("Aircraft at the coordinates of "+ bombingString + " could not be shot but no city is harmed!");
                                            aircraft.ElementAt(i).isSeen = true;
                                            Logger.SaveLog();
                                        }
                                       
                                    }
                                }




                            } 

                        }
                        else if (aircraft.ElementAt(i).isfriendlyonce == false)
                        { 
                            string aircraftString = aircraft.ElementAt(i).getLocation();
                            Logger.WriteLine("Friendly aircraft spotted at the coordinates of " + aircraftString + "");
                            Logger.SaveLog();
                            aircraft.ElementAt(i).isfriendlyonce = true;

                        }


                    }
                    else
                    {
                        for (int z = 0; z < cities.Count(); z++)
                        {
                            int cityDistancex = Math.Abs(aircraft.ElementAt(i).x - cities.ElementAt(z).x);
                            int cityDistanceY = Math.Abs(aircraft.ElementAt(i).y - cities.ElementAt(z).y);
                            double cityResult = Math.Abs(Math.Sqrt(cityDistancex * cityDistancex + cityDistanceY * cityDistanceY));
                            double cityCompare = Convert.ToDouble(aircraft.ElementAt(z).range);

                            if (aircraft.ElementAt(i).getType() == "FOE" || aircraft.ElementAt(i).getType() == "Bogey")
                            {
                             
                                
                                if (cityResult < cityCompare && aircraft.ElementAt(i).isBombed == false)
                            
                                {
                                string cityString = cities.ElementAt(z).getLocation();
                                string bombingString = aircraft.ElementAt(i).getLocation();
                                Logger.WriteLine("Our city the the coordinates of : " + cityString + " bombed by the aircraft from " + bombingString + "");
                                aircraft.ElementAt(i).isBombed = true;
                                Logger.SaveLog();
                           
                                }

                            }
                            else if (aircraft.ElementAt(i).isfriendlyonce == false)
                            {
                                string cityString = cities.ElementAt(z).getLocation();
                                Logger.WriteLine("Our city at the coordinates of  " + cityString + " reports a friendly aircraft");
                                Logger.SaveLog();
                                aircraft.ElementAt(i).isfriendlyonce = true;

                            }



                        }



                    }
                }
            }

        }

    }
}
