using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TreeOfLife.Logic.Factories;
using TreeOfLife.Model;
using TreeOfLife.Model.Interfaces;

namespace TreeOfLife.Logic.Repositories
{
    public class SephiraRepository : ISephiraRepository
    {
        private readonly IReadOnlyCollection<Sephira> _sephiroth;
        private readonly ITreeOfLifeSession _session;

        public SephiraRepository(ISephiraFactory sephiraFactory, ITreeOfLifeSession session)
        {
            _session = session;

            _sephiroth = new ReadOnlyCollection<Sephira>(new List<Sephira>
            {
                sephiraFactory.Create("Sephiroth/1", 1, 1, "Kether", "Crown"),
                sephiraFactory.Create("Sephiroth/2", 2, 2, "Chokmah", "Wisdom"),
                sephiraFactory.Create("Sephiroth/3", 3, 3, "Binah", "Understanding"),
                sephiraFactory.Create("Sephiroth/4", 4, 4, "Chesed", "Mercy"),
                sephiraFactory.Create("Sephiroth/5", 5, 5, "Geburah", "Strength"),
                sephiraFactory.Create("Sephiroth/6", 6, 6, "Tiphareth", "Beauty"),
                sephiraFactory.Create("Sephiroth/7", 7, 7, "Netzach", "Victory"),
                sephiraFactory.Create("Sephiroth/8", 8, 8, "Hod", "Splendour"),
                sephiraFactory.Create("Sephiroth/9", 9, 9, "Yesod", "Foundation"),
                sephiraFactory.Create("Sephiroth/10", 10, 10, "Malkuth", "Kingdom")
            });
        }

        public void DeleteAll()
        {
            _session.DeleteAll<Sephira>();
        }

        public IEnumerable<Sephira> ReadAll()
        {
            return _session.Query<Sephira>().OrderBy(s => s.Number);
        }

        public void StoreData()
        {
            _session.Store(_sephiroth);
        }

        public void Update(Sephira sephira)
        {
            _session.Update(sephira);
        }
    }
}