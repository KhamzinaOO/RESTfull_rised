using System.ComponentModel.DataAnnotations.Schema;

namespace RESRTfull.Domain
{
    public class Address
    {

        public Guid ID { get; set; }
        public string AddressPermanentRegistration { get; set; } = string.Empty;
        public string? AddressTemporaryRegistration { get; set; }

        //сделать через modelBuilder.Entity<>()
        public Guid IndividualID { get; set; }
        [ForeignKey("IndividualID")]
        public Individual Individual { get; set; } = null!;
    }
}
