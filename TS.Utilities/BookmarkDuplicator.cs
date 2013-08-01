using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace TS.Utilities
{
    public class BookmarkDuplicator
    {
        public string FileName { get; set; }
        private IEnumerable<Dictionary<string, object>> GetBookmarksFromDocument(string document)
        {
            if (string.IsNullOrEmpty(document))
                throw new NullReferenceException("Empty filename passed.");
            if (!File.Exists(document))
                throw new FileNotFoundException(string.Format("{0} does not exist.", document));

            var reader = new PdfReader(document);
            var bookmarks = SimpleBookmark.GetBookmark(reader);
            reader.Close();
            return bookmarks;
        }

        public void DuplicateBookmarksToDestinations()
        {
            DuplicateBookmarksToDestinations(FileName);
        }

        public void DuplicateBookmarksToDestinations(string document)
        {
            if (string.IsNullOrEmpty(document))
                throw new NullReferenceException("Empty filename passed.");
            if (!File.Exists(document))
                throw new FileNotFoundException(string.Format("{0} does not exist.", document));

            var bookmarks = GetBookmarksFromDocument(document);
            var nameddests = new List<NamedDestinationImpl>();
            foreach (var topLevelBookmark in bookmarks)
            {
                nameddests.AddRange(GetFlattenedDestinations(topLevelBookmark));
            }

            InsertDestinationsIntoDocument(document, nameddests);
        }

        private void InsertDestinationsIntoDocument(string document, IEnumerable<NamedDestinationImpl> nameddests)
        {
            if (!File.Exists(document))
                throw new FileNotFoundException("Document not found.", document);

            var extensionIndex = document.IndexOf(".pdf");
            var tempDoc = document.Substring(0, extensionIndex) + "-2.pdf";
            var doc = new Document();
            var copy = new PdfCopy(doc, new FileStream(tempDoc, FileMode.Create));
            doc.Open();
            var reader = new PdfReader(document);
            copy.Outlines = GetBookmarksFromDocument(document).ToList();
            for (int page = 0; page < reader.NumberOfPages; )
            {
                copy.AddPage(copy.GetImportedPage(reader, ++page));
            }
            foreach (var destination in nameddests)
            {
                copy.AddNamedDestination(destination.Name, destination.Page, destination.Destination);
            }
            copy.FreeReader(reader);
            reader.Close();
            doc.Close();
            // TODO: Uniqueness tests?
        }

        public IEnumerable<NamedDestinationImpl> GetFlattenedDestinations(Dictionary<string, object> source)
        {
            var items = new List<NamedDestinationImpl> { NamedDestinationFactory.Instance.CreateNamedInstanceFor(source) };
            if (source.ContainsKey("Kids") && source["Kids"] is IEnumerable<Dictionary<string, object>>)
            {
                foreach (var kid in (source["Kids"] as IEnumerable<Dictionary<string, object>>))
                {
                    items.AddRange(GetFlattenedDestinations(kid));
                }
            }
            return items;
        }
    }
}
