using RESRTfull.Domain;

namespace RESTfull.API.DTO
{
    public class DocRussianPassportDTOMapper
    {
        public static DocRussianPassportDTO ToDto(DocRussianPassport russianPassport)
        {
            var russianPassportDTO = new DocRussianPassportDTO
            {
                ID = russianPassport.ID,
                DocumentSeries = russianPassport.DocumentSeries,
                DocumentIssuer = russianPassport.DocumentIssuer,
                DocumentDate = russianPassport.DocumentDate,
                DocumentIssuerCode = russianPassport.DocumentIssuerCode
            };
            return russianPassportDTO;
        }

        public static DocRussianPassport ToEntity(DocRussianPassportDTO russianPassportDTO)
        {
            var russianPassport = new DocRussianPassport
            {
                ID = russianPassportDTO.ID,
                DocumentSeries = russianPassportDTO.DocumentSeries,
                DocumentIssuer = russianPassportDTO.DocumentIssuer,
                DocumentDate = russianPassportDTO.DocumentDate,
                DocumentIssuerCode = russianPassportDTO.DocumentIssuerCode
            };
            return russianPassport;
        }
    }
}
