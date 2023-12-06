namespace RESTfull.API.DTO
{
    public class DocInternationalPassportDTO
    {
        public Guid ID { get; set; }
        public string DocumentSeries { get; set; } = String.Empty;
        public string DocumentIssuer { get; set; } = String.Empty;
        public DateTime DocumentDateOfIssue { get; set; }
        public DateTime DocumentExpirationDate { get; set; }
    }
}