using RESRTfull.Domain;

namespace RESTfull.API.DTO
{
    public class DocForeignPassportDTOMapper
    {
        public static DocForeignPassportDTO ToDto(DocForeignPassport foreignPassport)
        {
            var foreignPassportDTO = new DocForeignPassportDTO
            {
                ID = foreignPassport.ID,
                DocumentSeries = foreignPassport.DocumentSeries,
                DocumentCountry = foreignPassport.DocumentCountry,
                DocumentDate = foreignPassport.DocumentDate
            };
            return foreignPassportDTO;
        }

        public static DocForeignPassport ToEntity(DocForeignPassportDTO foreignPassportDTO)
        {
            var foreignPassport = new DocForeignPassport
            {
                ID = foreignPassportDTO.ID,
                DocumentSeries = foreignPassportDTO.DocumentSeries,
                DocumentCountry = foreignPassportDTO.DocumentCountry,
                DocumentDate = foreignPassportDTO.DocumentDate
            };
            return foreignPassport;
        }
    }
}
