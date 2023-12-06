namespace RESTfull.API.DTO
{
    public class InfoDTO
    {
        public Guid ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;

        public DateTime DateOfBirth;
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}