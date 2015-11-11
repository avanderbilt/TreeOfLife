using System.Collections.Generic;

namespace TreeOfLife.Model.Interfaces
{
    public interface IPlanetRepository : IRepository
    {
        IEnumerable<Planet> ReadAll();
        void Update(Planet planet);
    }
}