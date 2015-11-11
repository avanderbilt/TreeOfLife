using System.Collections.Generic;

namespace TreeOfLife.Model.Interfaces
{
    public interface IZodiacSignRepository : IRepository
    {
        IEnumerable<ZodiacSign> ReadAll();
        void Update(ZodiacSign zodiacSign);
    }
}