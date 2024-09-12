namespace RadiatorSprings.Core.ValueObjects;

public record Document
{
    public string DocumentType { get; set; } = "";
    public string DocumentNumber { get; set; } = "";

    public Document(string documentType, string documentNumber)
    {
        DocumentType = documentType;
        DocumentNumber = documentNumber;
    }

    public static Document Create(string documentType, string documentNumber)
    {
        if (string.IsNullOrEmpty(documentType))
            throw new ArgumentNullException(nameof(documentType));

        if (string.IsNullOrEmpty(documentNumber))
            throw new ArgumentNullException(nameof(documentNumber));

        return new Document(documentType, documentNumber);
    }
}
