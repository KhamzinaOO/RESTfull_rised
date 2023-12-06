using RESRTfull.Domain;

namespace RESTfull.API.DTO
{
    public class IndividualDTO
    {
        public Guid ID { get; set; }
        public InfoDTO? InformationDTO { get; set; } = new InfoDTO();
        public List<JobDTO>? JobsDTOs { get; set; } = new List<JobDTO>();
        public List<EducationDTO>? EducationsDTOs { get; set; } = new List<EducationDTO>();
        public List<DocumentDTO>? DocumentsDTOs { get; set; } = new List<DocumentDTO>();
        public DocForeignPassportDTO? ForeignPassportDTO { get; set; } = new DocForeignPassportDTO();
        public DocInternationalPassportDTO? InternationalPassportDTO { get; set; } = new DocInternationalPassportDTO();
        public DocRussianPassportDTO? RussianPassportDTO { get; set; } = new DocRussianPassportDTO();
        public AddressDTO? PersonAddressDTO { get; set; } = new AddressDTO();
    }
}
