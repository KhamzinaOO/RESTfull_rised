using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace RESRTfull.Domain
{
    public class Info
    {
        public Guid ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Gender {  get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime DateOfBirth;
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public Guid IndividualID { get; set; }
        [ForeignKey("IndividualID")]
        public Individual Individual { get; set; } = null!;

    
    }
}
