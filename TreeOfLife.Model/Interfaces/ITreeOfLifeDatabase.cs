using Raven.Client;

namespace TreeOfLife.Model.Interfaces
{
    public interface ITreeOfLifeDatabase
    {
        IDocumentStore DocumentStore { get; }
        void HardDeletDatabase();
    }
}