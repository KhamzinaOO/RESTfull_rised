namespace RESTfull.API.DTO
{
    public class DocRussianPassportDTO
    {
        public Guid ID { get; set; }
        public string DocumentSeries { get; set; } = string.Empty;
        public string DocumentIssuer { get; set; } = string.Empty;
        public string DocumentIssuerCode { get; set; } = string.Empty;
        public DateTime DocumentDate { get; set; }
    }
}