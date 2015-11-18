using System.Collections.Generic;

namespace TreeOfLife.Model.Interfaces
{
    public interface IMetalRepository : IRepository
    {
        IEnumerable<Metal> ReadAll();
        void Update(Metal metal);
    }
}