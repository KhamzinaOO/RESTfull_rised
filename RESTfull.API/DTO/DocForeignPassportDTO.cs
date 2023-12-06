namespace RESTfull.API.DTO
{
    public class DocForeignPassportDTO
    {
        public Guid ID { get; set; }
        public string DocumentSeries { get; set; } = String.Empty;
        public string DocumentCountry { get; set; } = String.Empty;
        public DateTime DocumentDate { get; set; }
    }
}