namespace RESTfull.API.DTO
{
    public class AddressDTO
    {
        public Guid ID { get; set; }
        public string AddressPermanentRegistration { get; set; } = string.Empty;
        public string? AddressTemporaryRegistration { get; set; }
    }
}