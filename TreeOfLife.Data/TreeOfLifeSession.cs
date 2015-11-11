using System.Collections.Generic;
using System.Linq;
using TreeOfLife.Model;
using TreeOfLife.Model.Interfaces;

namespace TreeOfLife.Data
{
    public class TreeOfLifeSession : ITreeOfLifeSession
    {
        private readonly ITreeOfLifeDatabase _database;

        public TreeOfLifeSession(ITreeOfLifeDatabase database)
        {
            _database = database;
        }

        public void DeleteAll<T>()
        {
            using (var session = _database.DocumentStore.OpenSession())
            {
                var items = session.Query<T>().ToList();

                foreach (var item in items)
                {
                    session.Delete(item);
                }

                session.SaveChanges();
            }
        }

        public IEnumerable<T> Query<T>()
        {
            IEnumerable<T> result;

            using (var session = _database.DocumentStore.OpenSession())
            {
                result = session.Query<T>();
            }

            return result;
        }

        public void Store<T>(IEnumerable<T> items)
        {
            using (var session = _database.DocumentStore.OpenSession())
            {
                foreach (var item in items)
                {
                    session.Store(item);
                }

                session.SaveChanges();
            }
        }

        public void Update<T>(T item) where T : Entity
        {
            using (var session = _database.DocumentStore.OpenSession())
            {
                session.Store(item, item.Id);

                session.SaveChanges();
            }
        }
    }
}