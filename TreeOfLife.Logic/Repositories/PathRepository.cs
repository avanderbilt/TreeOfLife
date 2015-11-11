using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TreeOfLife.Logic.Factories;
using TreeOfLife.Model;
using TreeOfLife.Model.Interfaces;

namespace TreeOfLife.Logic.Repositories
{
    public class PathRepository : IPathRepository
    {
        private readonly IReadOnlyCollection<Path> _paths;
        private readonly ITreeOfLifeSession _session;

        public PathRepository(IPathFactory pathFactory, ITreeOfLifeSession session)
        {
            _session = session;

            _paths = new ReadOnlyCollection<Path>(new List<Path>
            {
                pathFactory.Create("Paths/1", 11, 1, 1, 2),
                pathFactory.Create("Paths/2", 12, 2, 1, 3),
                pathFactory.Create("Paths/3", 13, 3, 1, 6),
                pathFactory.Create("Paths/4", 14, 4, 2, 3),
                pathFactory.Create("Paths/5", 15, 5, 2, 6),
                pathFactory.Create("Paths/6", 16, 6, 2, 4),
                pathFactory.Create("Paths/7", 17, 7, 3, 6),
                pathFactory.Create("Paths/8", 18, 8, 3, 5),
                pathFactory.Create("Paths/9", 19, 9, 4, 5),
                pathFactory.Create("Paths/10", 20, 10, 4, 6),
                pathFactory.Create("Paths/11", 21, 11, 4, 7),
                pathFactory.Create("Paths/12", 22, 12, 5, 6),
                pathFactory.Create("Paths/13", 23, 13, 5, 8),
                pathFactory.Create("Paths/14", 24, 14, 6, 7),
                pathFactory.Create("Paths/15", 25, 15, 6, 9),
                pathFactory.Create("Paths/16", 26, 16, 6, 8),
                pathFactory.Create("Paths/17", 27, 17, 7, 8),
                pathFactory.Create("Paths/18", 28, 18, 7, 9),
                pathFactory.Create("Paths/19", 29, 19, 7, 10),
                pathFactory.Create("Paths/20", 30, 20, 8, 9),
                pathFactory.Create("Paths/21", 31, 21, 8, 10),
                pathFactory.Create("Paths/22", 32, 22, 9, 10)
            });
        }

        public void DeleteAll()
        {
            _session.DeleteAll<Path>();
        }

        public IEnumerable<Path> ReadAll()
        {
            return _session.Query<Path>().OrderBy(s => s.Number);
        }

        public void StoreData()
        {
            _session.Store(_paths);
        }

        public void Update(Path path)
        {
            _session.Update(path);
        }
    }
}