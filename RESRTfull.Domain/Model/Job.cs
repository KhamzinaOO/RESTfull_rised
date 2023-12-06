using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RESRTfull.Domain
{
    public class Job
    {
        public Guid ID { get; set; }
        public string Position { get; set; } = string.Empty;
        public string Organization { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime DateStart;

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime? DateEnd;

        public Guid IndividualID { get; set; }
        [ForeignKey("IndividualID")]
        public Individual Individual { get; set; } = null!;
    }
}
