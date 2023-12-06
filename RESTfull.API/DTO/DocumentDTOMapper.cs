using RESRTfull.Domain;

namespace RESTfull.API.DTO
{
    public class DocumentDTOMapper
    {
        public static DocumentDTO ToDto(Document document)
        {
            var documentDTO = new DocumentDTO
            {
                ID = document.ID,
                DocumentName = document.DocumentName,
                DocumentNumber = document.DocumentNumber

            };
            return documentDTO;
        }

        public static Document ToEntity(DocumentDTO documentDTO)
        {
            var document = new Document
            {
                ID = documentDTO.ID,
                DocumentName = documentDTO.DocumentName,
                DocumentNumber = documentDTO.DocumentNumber
            };
            return document;
        }
    }
}
