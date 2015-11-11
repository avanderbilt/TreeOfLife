using System.Collections.Generic;

namespace TreeOfLife.Model.Interfaces
{
    public interface ITreeOfLifeSession
    {
        void DeleteAll<T>();
        IEnumerable<T> Query<T>();
        void Store<T>(IEnumerable<T> items);
        void Update<T>(T item) where T : Entity;
    }
}