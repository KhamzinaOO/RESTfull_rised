using RESRTfull.Domain;

namespace RESTfull.API.DTO
{
    public class EducationDTOMapper
    {
        public static EducationDTO ToDto(Education education)
        {
            var educationDTO = new EducationDTO
            {
                ID = education.ID,
                Type = education.Type,
                Institution = education.Institution,
                Date = education.Date
            };
            return educationDTO;
        }

        public static Education ToEntity(EducationDTO educationDTO)
        {
            var education = new Education
            {
                ID = educationDTO.ID,
                Type = educationDTO.Type,
                Institution = educationDTO.Institution,
                Date = educationDTO.Date
            };
            return education;
        }
    }
}
