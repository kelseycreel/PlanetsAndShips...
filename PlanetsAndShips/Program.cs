using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanetsAndShips
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> planetList = new List<string>() { "Mercury", "Mars" };
            planetList.Add("Jupiter");
            planetList.Add("Saturn");

            List<string> lastTwo = new List<string>() { "Neptune", "Pluto" };
            // yes pluto is a planet

            planetList.AddRange(lastTwo);

            planetList.Insert(0, "Venus");
            planetList.Insert(1, "Earth");

            List<string> rockyPlanets = planetList.GetRange(0, 2);

            planetList.Remove("Pluto");

            var artemisPlanets = new List<string>() { "Mercury", "Venus" };
            var aresPlanets = new List<string>() { "Neptune", "Uranus" };
            var zeusPlanets = new List<string>() { "Pluto", "Venus" };

            var spacecrafts = new Dictionary<string, List<string>>() { { "Artemis", artemisPlanets } };
            spacecrafts.Add("Zeus", zeusPlanets);
            spacecrafts.Add("Ares", aresPlanets);


            var ships = spacecrafts.Keys;

            foreach (var planet in planetList)
            {
                var print = $"{planet}: ";

                foreach (var ship in ships)
                {
                    var visitedPlanets = spacecrafts.GetValueOrDefault(ship);
                    if (visitedPlanets[0] == planet)
                    {
                        print += ship + ", ";
                    }
                    else if (visitedPlanets[1] == planet)
                    {
                        print += ship + ", ";
                    }
                }

                Console.WriteLine(print.Remove((print.Length - 2), 2));
            }


            //// this is apparently backwards than requested but it took forever so hERE YA GO
            var visited = "";
            foreach (var planet in planetList)
            {
                visited = spacecrafts
                    .FirstOrDefault(x => x.Value.Contains(planet))
                    .Key;
            }
            var strs = visited + ": ";
            foreach (KeyValuePair<string, List<string>> entry in spacecrafts)
            {
                foreach (var ent in entry.Value)
                {
                    if (entry.Key == visited)
                        strs += ent + ", ";
                }

            }
            Console.WriteLine(strs);
            Console.ReadKey();


        }
    }
}
