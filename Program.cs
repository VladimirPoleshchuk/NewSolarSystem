
using System.Numerics;
using System.Xml.Linq;

namespace NewSolarSystem
{
    internal class Program
    {
        public delegate string Validator(string name);

        static void Main()
        {
            Planet venurs = new("Венера", 2, 12100, null);
            Planet earth = new("Земля", 3, 12756, venurs);
            Planet mars = new("Марс", 4, 6792, earth);

            PlanetsCatalog planets = new(venurs, earth, mars);

            Validator validator = new(planets.PlanetValidator);

            Validator validatorLemony = (string name) =>
            {
                foreach (var planet in planets.Planets)
                {
                    if (planet.Name == name)
                    {
                        return null;
                    }
                }

                if (name == "Лимония")
                {
                    return "Это запретная планета.";
                }

                return null;
            };

            List<string> names = new List<string>() { "Земля", "Лимония", "Марс", "Венера" };

            foreach (var name in names)
            {
                PrintResultPlanet(name);
            }

            void PrintResultPlanet(string name)
            {
                var tuple = planets.GetPlanet(name, validatorLemony);

                if (tuple.Item1 == null)
                {
                    Console.WriteLine($"[{tuple.Item2} {tuple.Item3}]");
                }

                Console.WriteLine(tuple.Item1);
            }
        }
    }
}