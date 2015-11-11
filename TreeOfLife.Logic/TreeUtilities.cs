using TreeOfLife.Model.Interfaces;

namespace TreeOfLife.Logic
{
    public class TreeUtilities : ITreeUtilities
    {
        private readonly IHebrewLetterRepository _hebrewLetterRepository;
        private readonly IPathRepository _pathRepository;
        private readonly IPlanetRepository _planetRepository;
        private readonly ISephiraRepository _sephiraRepository;
        private readonly IZodiacSignRepository _zodiacSignRepository;
        private readonly ITreeOfLifeDatabase _database;

        public TreeUtilities(IHebrewLetterRepository hebrewLetterRepository, ISephiraRepository sephiraRepository,
            IPlanetRepository planetRepository, IZodiacSignRepository zodiacSignRepository,
            IPathRepository pathRepository, ITreeOfLifeDatabase database)
        {
            _hebrewLetterRepository = hebrewLetterRepository;
            _sephiraRepository = sephiraRepository;
            _planetRepository = planetRepository;
            _zodiacSignRepository = zodiacSignRepository;
            _pathRepository = pathRepository;
            _database = database;
        }

        public void RebuildDatabase()
        {
            _database.HardDeletDatabase();

            _hebrewLetterRepository.StoreData();
            _sephiraRepository.StoreData();
            _planetRepository.StoreData();
            _zodiacSignRepository.StoreData();
            _pathRepository.StoreData();
        }
    }
}