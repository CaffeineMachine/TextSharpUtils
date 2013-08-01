using System;
using TS.Utilities;

namespace TextSharpUtils
{
    class TextSharpUtils
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("TextSharpUtils");
                Console.WriteLine();
                Console.WriteLine("NAME");
                Console.WriteLine("     TextSharpUtils - A Utility for inserting named destinations to correspond with bookmarks.");
                Console.WriteLine("SYNOPSIS");
                Console.WriteLine("     TextShaprUtils [inputfilepath]");
                Console.WriteLine("DESCRIPTION");
                Console.WriteLine("     Running this program will create a copy of the input file, except the name will be appended with -2.pdf");
                return;
            }
            var bd = new BookmarkDuplicator();
            var document = args[0];
            bd.DuplicateBookmarksToDestinations(document);
        }
    }
}
