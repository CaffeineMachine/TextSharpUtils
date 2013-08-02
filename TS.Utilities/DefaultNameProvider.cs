using System;
using System.Text.RegularExpressions;
using TS.Interfaces;

namespace TS.Utilities
{
    public class DefaultNameProvider : IUniqueNameProvider
    {
        public string GetName(object source)
        {
            if (source is string)
            {
                var title = (source as string);
                return Regex.Replace(title, @"[\W_]", string.Empty);
            }
            return Regex.Replace(Guid.NewGuid().ToString(), @"[\W_]", string.Empty);
        }
    }
}
