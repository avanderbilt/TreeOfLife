using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TreeOfLife.Logic.Factories;
using TreeOfLife.Model;
using TreeOfLife.Model.Interfaces;

namespace TreeOfLife.Logic.Repositories
{
    public class ElementRepository : IElementRepository
    {
        private readonly IReadOnlyCollection<Element> _elements;
        private readonly ITreeOfLifeSession _session;

        public ElementRepository(IElementFactory elementFactory, ITreeOfLifeSession session)
        {
            _session = session;

            _elements = new ReadOnlyCollection<Element>(new List<Element>
            {
                elementFactory.Create("Elements/1", 11, "Air", "\U0001F701"),
                elementFactory.Create("Elements/2", 23, "Water", "\U0001F704"),
                elementFactory.Create("Elements/3", 31, "Fire", "\U0001F702"),
                elementFactory.Create("Elements/4", 33, "Earth", "\U0001F703"),
                elementFactory.Create("Elements/5", 34, "Spirit", "\U0001F700")
            });
        }

        public void DeleteAll()
        {
            _session.DeleteAll<Element>();
        }

        public IEnumerable<Element> ReadAll()
        {
            return _session.Query<Element>().OrderBy(e => e.Name);
        }

        public void StoreData()
        {
            _session.Store(_elements);
        }

        public void Update(Element element)
        {
            _session.Update(element);
        }
    }
}