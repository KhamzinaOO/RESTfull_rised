using RESRTfull.Domain;

namespace RESTfull.API.DTO
{
    public class DocInternationalPassportDTOMapper
    {
        public static DocInternationalPassportDTO ToDto(DocInternationalPassport internationalPassport)
        {
            var internationalPassportDTO = new DocInternationalPassportDTO
            {
                ID = internationalPassport.ID,
                DocumentSeries = internationalPassport.DocumentSeries,
                DocumentDateOfIssue = internationalPassport.DocumentDateOfIssue,
                DocumentExpirationDate = internationalPassport.DocumentExpirationDate,
                DocumentIssuer = internationalPassport.DocumentIssuer
            };
            return internationalPassportDTO;
        }

        public static DocInternationalPassport ToEntity(DocInternationalPassportDTO internationalPassportDTO)
        {
            var internationalPassport = new DocInternationalPassport
            {
                ID = internationalPassportDTO.ID,
                DocumentSeries = internationalPassportDTO.DocumentSeries,
                DocumentDateOfIssue = internationalPassportDTO.DocumentDateOfIssue,
                DocumentExpirationDate = internationalPassportDTO.DocumentExpirationDate,
                DocumentIssuer = internationalPassportDTO.DocumentIssuer
            };
            return internationalPassport;
        }
    }
}
