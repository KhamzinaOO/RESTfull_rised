namespace RESTfull.API.DTO
{
    public class DocumentDTO
    {
        public Guid ID { get; set; }
        public string DocumentName { get; set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;
    }
}