
namespace RESTfull.API.DTO
{
    public class EducationDTO
    {
        public Guid ID { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Institution { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}