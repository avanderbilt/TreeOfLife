using System.Collections.Generic;

namespace TreeOfLife.Model.Interfaces
{
    public interface ISephiraRepository : IRepository
    {
        IEnumerable<Sephira> ReadAll();
        void Update(Sephira sephira);
    }
}