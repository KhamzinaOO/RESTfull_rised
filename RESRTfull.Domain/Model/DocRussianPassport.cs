using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RESRTfull.Domain
{
    public class DocRussianPassport
    {
        public Guid ID { get; set; }
        public string DocumentSeries { get; set; } = string.Empty;
        public string DocumentIssuer { get; set; } = string.Empty;
        public string DocumentIssuerCode { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime DocumentDate { get; set; }

        public Guid IndividualID { get; set; }
        [ForeignKey("IndividualID")]
        public Individual Individual { get; set; } = null!;

    }
}
