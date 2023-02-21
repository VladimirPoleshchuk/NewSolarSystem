
namespace NewSolarSystem
{
    internal class Planet
    {
        public string Name { get; }
        public int Number { get; }
        public int EquatorLenth { get; }
        public Planet PreviousPlanet { get; }

        public Planet(string name, int number, int equatorLenth, Planet previousPlanet)
        {
            Name = name;
            Number = number;
            EquatorLenth = equatorLenth;
            PreviousPlanet = previousPlanet;
        }
    }
}