using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TreeOfLife.Logic.Factories;
using TreeOfLife.Model;
using TreeOfLife.Model.Interfaces;

namespace TreeOfLife.Logic.Repositories
{
    public class ZodiacSignRepository : IZodiacSignRepository
    {
        private readonly IReadOnlyCollection<ZodiacSign> _zodiacSigns;
        private readonly ITreeOfLifeSession _session;

        public ZodiacSignRepository(IZodiacSignFactory zodiacSignFactory, ITreeOfLifeSession session)
        {
            _session = session;

            _zodiacSigns = new ReadOnlyCollection<ZodiacSign>(new List<ZodiacSign>
            {
                zodiacSignFactory.Create("ZodiacSigns/1", 15, "Aries", '\u2648'),
                zodiacSignFactory.Create("ZodiacSigns/2", 16, "Taurus", '\u2649'),
                zodiacSignFactory.Create("ZodiacSigns/3", 17, "Gemini", '\u264A'),
                zodiacSignFactory.Create("ZodiacSigns/4", 18, "Cancer", '\u264B'),
                zodiacSignFactory.Create("ZodiacSigns/5", 19, "Leo", '\u264C'),
                zodiacSignFactory.Create("ZodiacSigns/6", 20, "Virgo", '\u264D'),
                zodiacSignFactory.Create("ZodiacSigns/7", 22, "Leo", '\u264E'),
                zodiacSignFactory.Create("ZodiacSigns/8", 24, "Scorpio", '\u264F'),
                zodiacSignFactory.Create("ZodiacSigns/9", 25, "Sagittarius", '\u2650'),
                zodiacSignFactory.Create("ZodiacSigns/10", 26, "Capricorn", '\u2651'),
                zodiacSignFactory.Create("ZodiacSigns/11", 28, "Aquarius", '\u2652'),
                zodiacSignFactory.Create("ZodiacSigns/12", 29, "Pisces", '\u2653')
            });
        }

        public void DeleteAll()
        {
            _session.DeleteAll<ZodiacSign>();
        }

        public IEnumerable<ZodiacSign> ReadAll()
        {
            return _session.Query<ZodiacSign>().OrderBy(s => s.Name);
        }

        public void StoreData()
        {
            _session.Store(_zodiacSigns);
        }

        public void Update(ZodiacSign zodiacSign)
        {
            _session.Update(zodiacSign);
        }
    }
}