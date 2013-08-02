using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TS.Interfaces;
using iTextSharp.text.pdf;

namespace TS.Utilities
{
    public class NamedDestinationFactory : INamedDestinationFactory
    {
        private readonly IUniqueNameProvider _nameProvider;
        public NamedDestinationFactory(IUniqueNameProvider nameProvider)
        {
            _nameProvider = nameProvider;
        }

        public NamedDestinationFactory() : this(new DefaultNameProvider())
        {
        }

        public INamedDestination CreateNamedInstanceFor(Dictionary<string, object> iDestination)
        {
            // TODO: Either verify that these settings are okay by default, or make them configuration injectable.
            var uniqueIdentifier = Guid.NewGuid().ToString().Replace("-", string.Empty);
            var page = 0;
            var typeParam = -1.0f;
            var type = 0;
            if (iDestination.ContainsKey("Title"))
            {
                var title = _nameProvider.GetName(iDestination["Title"].ToString());
                if (!string.IsNullOrEmpty(title))
                {
                    uniqueIdentifier = title;
                }
            }
            if (iDestination.ContainsKey("Page"))
            {
                var matches = Regex.Match(iDestination["Page"].ToString(), @"(?'page'\d*) (?'type'\w*) (?'typeParam'\d*)");
                if (!string.IsNullOrEmpty(matches.Groups["page"].Value))
                {
                    page = Int32.Parse(matches.Groups["page"].Value);
                }
                if (!string.IsNullOrEmpty(matches.Groups["type"].Value))
                {
                    type = GetPDFViewType(matches.Groups["type"].Value);
                }
                if (!string.IsNullOrEmpty(matches.Groups["typeParam"].Value))
                {
                    typeParam = float.Parse(matches.Groups["typeParam"].Value);
                }
            }
            
            var destination = new PdfDestination(type, typeParam);
            return new NamedDestinationImpl(uniqueIdentifier, page, destination);
        }

        internal static int GetPDFViewType(string expectedType)
        {
            switch (expectedType)
            {
                case "FIT":
                    return PdfDestination.FIT;
                case "FITB":
                    return PdfDestination.FITB;
                case "FITBH":
                    return PdfDestination.FITBH;
                case "FITBV":
                    return PdfDestination.FITBV;
                case "FITH":
                    return PdfDestination.FITH;
                case "FITR":
                    return PdfDestination.FITR;
                case "FITV":
                    return PdfDestination.FITV;
                default:
                    return PdfDestination.XYZ;
            }
        }
    }

    public class NamedDestinationImpl : INamedDestination
    {
        public NamedDestinationImpl(string name, int page, PdfDestination destination)
        {
            Name = name;
            Page = page;
            Destination = destination;
        }
        public string Name { get; private set; }
        public int Page { get; private set; }
        public PdfDestination Destination { get; private set; }
    }
}
