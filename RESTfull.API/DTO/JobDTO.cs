namespace RESTfull.API.DTO
{
    public class JobDTO
    {
        public Guid ID { get; set; }
        public string Position { get; set; } = string.Empty;
        public string Organization { get; set; } = string.Empty;

        public DateTime DateStart;

        public DateTime? DateEnd;
    }
}