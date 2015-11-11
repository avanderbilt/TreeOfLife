using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TreeOfLife.Logic.Factories;
using TreeOfLife.Model;
using TreeOfLife.Model.Interfaces;

namespace TreeOfLife.Logic.Repositories
{
    public class PlanetRepository : IPlanetRepository
    {
        private readonly IReadOnlyCollection<Planet> _planets;
        private readonly ITreeOfLifeSession _session;

        public PlanetRepository(IPlanetFactory planetFactory, ITreeOfLifeSession session)
        {
            _session = session;

            _planets = new ReadOnlyCollection<Planet>(new List<Planet>
            {
                planetFactory.Create("Planets/1", 12, 8, "Mercury", '\u263F'),
                planetFactory.Create("Planets/2", 13, 9, "Moon", '\u263E'),
                planetFactory.Create("Planets/3", 14, 7, "Venus", '\u2640'),
                planetFactory.Create("Planets/4", 21, 4, "Jupiter", '\u2643'),
                planetFactory.Create("Planets/5", 27, 5, "Mars", '\u2642'),
                planetFactory.Create("Planets/6", 30, 6, "Sun", '\u2609'),
                planetFactory.Create("Planets/7", 32, 3, "Saturn", '\u2644')
            });
        }

        public void DeleteAll()
        {
            _session.DeleteAll<Planet>();
        }

        public IEnumerable<Planet> ReadAll()
        {
            return _session.Query<Planet>().OrderBy(l => l.Number);
        }

        public void StoreData()
        {
            _session.Store(_planets);
        }

        public void Update(Planet planet)
        {
            _session.Update(planet);
        }
    }
}