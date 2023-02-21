
using static NewSolarSystem.Program;

namespace NewSolarSystem
{
    internal class PlanetsCatalog
    {
        public List<Planet> Planets { get; }
        private static int count = 1;

        public PlanetsCatalog()
        {
            Planets = new List<Planet>();
        }

        public PlanetsCatalog(Planet planet1, Planet planet2, Planet planet3)
        {
            Planets = new List<Planet>();
            Planets.Add(planet1);
            Planets.Add(planet2);
            Planets.Add(planet3);
        }

        public (string, int, int) GetPlanet(string name, Validator PlanetValidator)
        {
            string mistake = PlanetValidator(name);

            if (!(mistake is null))
            {
                return (mistake, 0, 0);
            }

            foreach (var planet in Planets)
            {
                if (planet.Name == name)
                {
                    return (mistake, planet.Number, planet.EquatorLenth);
                }
            }

            return (mistake, 0, 0);
        }

        public string PlanetValidator(string name)
        {
            if (count == 3)
            {
                count = 1;
                return "Вы спрашиваете слишком часто.";
            }

            count++;

            foreach (var planet in Planets)
            {
                if (planet.Name == name)
                {
                    return null;
                }
            }

            return "Не удалось найти планету.";
        }
    }
}