using System.Collections.Generic;

namespace TreeOfLife.Model.Interfaces
{
    public interface IPathRepository : IRepository
    {
        IEnumerable<Path> ReadAll();
        void Update(Path path);
    }
}