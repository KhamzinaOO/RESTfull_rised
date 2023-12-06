using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RESRTfull.Domain
{
    public class DocInternationalPassport
    {
        public Guid ID { get; set; }
        public string DocumentSeries { get; set; } = String.Empty;
        public string DocumentIssuer { get; set; } = String.Empty;

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime DocumentDateOfIssue { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime DocumentExpirationDate { get; set; }

        public Guid IndividualID { get; set; }
        [ForeignKey("IndividualID")]

        public Individual Individual { get; set; } = null!;
    }
}
