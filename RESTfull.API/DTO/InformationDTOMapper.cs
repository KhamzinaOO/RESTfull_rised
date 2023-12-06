using RESRTfull.Domain;

namespace RESTfull.API.DTO
{
    internal class InformationDTOMapper
    {
        public static InfoDTO ToDto(Info info)
        {
            var informationDTO = new InfoDTO
            {
                ID = info.ID,
                Name = info.Name,
                Gender = info.Gender,
                DateOfBirth = info.DateOfBirth,
                Email = info.Email,
                Phone = info.Phone
            };
            return informationDTO;
        }

        public static Info ToEntity(InfoDTO informationDTO)
        {
            var info = new Info
            {
                ID = informationDTO.ID,
                Name = informationDTO.Name,
                Gender = informationDTO.Gender,
                DateOfBirth = informationDTO.DateOfBirth,
                Email = informationDTO.Email,
                Phone = informationDTO.Phone
            };
            return info;
        }
        public static List<InfoDTO> ToDto(List<Info> informations)
        {
            var informationDTO = new List<InfoDTO>();
            foreach (var information in informations)
            {
                informationDTO.Add(ToDto(information));
            }

            return informationDTO;
        }
    }
}