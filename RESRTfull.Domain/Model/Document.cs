using System.ComponentModel.DataAnnotations.Schema;

namespace RESRTfull.Domain
{
    public class Document
    {
        public Guid ID { get; set; }
        public string DocumentName { get; set; } = string.Empty;

        public string DocumentNumber { get; set; } = string.Empty;

        public Guid IndividualID { get; set; }
        [ForeignKey("IndividualID")]
        public Individual Individual { get; set; } = null!;

    }
}