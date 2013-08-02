using iTextSharp.text.pdf;

namespace TS.Interfaces
{
    public interface INamedDestination
    {
        string Name { get; }
        int Page { get; }
        PdfDestination Destination { get; }
    }
}
