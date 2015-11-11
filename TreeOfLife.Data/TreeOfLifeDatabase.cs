using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Util;
using TreeOfLife.Model;
using TreeOfLife.Model.Interfaces;

namespace TreeOfLife.Data
{
    public class TreeOfLifeDatabase : ITreeOfLifeDatabase
    {
        private const string DefaultDatabase = "TreeOfLife";
        private const int Port = 8888;
        private const string Url = "http://localhost";

        public TreeOfLifeDatabase()
        {
            Initialize();
        }

        public IDocumentStore DocumentStore { get; private set; }

        public void HardDeletDatabase()
        {
            DocumentStore.DatabaseCommands.GlobalAdmin.DeleteDatabase("TreeOfLife", true);

            Initialize();
        }

        private void Initialize()
        {
            DocumentStore = new DocumentStore {Url = $"{Url}:{Port}", DefaultDatabase = DefaultDatabase};
            DocumentStore.Conventions.FindTypeTagName =
                t => t == typeof (Sephira) ? "Sephiroth" : Inflector.Pluralize(t.Name);
            DocumentStore.Initialize();
        }
    }
}