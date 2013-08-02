using System.Collections.Generic;

namespace TS.Interfaces
{
    public interface INamedDestinationFactory
    {
        INamedDestination CreateNamedInstanceFor(Dictionary<string, object> iDestination);
    }
}
