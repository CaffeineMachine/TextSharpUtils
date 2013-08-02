using System.Collections.Generic;

namespace TS.Interfaces
{
    public interface IBookmarkDuplicator
    {
        void DuplicateBookmarksToDestinations();
        void DuplicateBookmarksToDestinations(string document);
        IEnumerable<INamedDestination> GetFlattenedDestinations(Dictionary<string, object> source);
    }
}
