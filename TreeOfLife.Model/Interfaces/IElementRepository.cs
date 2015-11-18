using System.Collections.Generic;

namespace TreeOfLife.Model.Interfaces
{
    public interface IElementRepository : IRepository
    {
        IEnumerable<Element> ReadAll();
        void Update(Element element);
    }
}