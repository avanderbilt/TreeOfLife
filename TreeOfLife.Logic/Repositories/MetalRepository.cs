using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TreeOfLife.Logic.Factories;
using TreeOfLife.Model;
using TreeOfLife.Model.Interfaces;

namespace TreeOfLife.Logic.Repositories
{
    public class MetalRepository : IMetalRepository
    {
        private readonly IReadOnlyCollection<Metal> _metals;
        private readonly ITreeOfLifeSession _session;

        public MetalRepository(IMetalFactory metalFactory, ITreeOfLifeSession session)
        {
            _session = session;

            _metals = new ReadOnlyCollection<Metal>(new List<Metal>
            {
                metalFactory.Create("Metals/1", 12, "Mercury"),
                metalFactory.Create("Metals/2", 13, "Silver"),
                metalFactory.Create("Metals/3", 14, "Copper"),
                metalFactory.Create("Metals/4", 21, "Tin"),
                metalFactory.Create("Metals/5", 27, "Iron"),
                metalFactory.Create("Metals/6", 30, "Gold"),
                metalFactory.Create("Metals/7", 32, "Lead")
            });
        }

        public void DeleteAll()
        {
            _session.DeleteAll<Metal>();
        }

        public IEnumerable<Metal> ReadAll()
        {
            return _session.Query<Metal>().OrderBy(e => e.Name);
        }

        public void StoreData()
        {
            _session.Store(_metals);
        }

        public void Update(Metal metal)
        {
            _session.Update(metal);
        }
    }
}