using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseStudy.Models
{
    public class CropDetail
    {
        [Key]
        public int CropId { get; set; }
        public int CropTypeId { get; set; }
        [ForeignKey("User")]
        public int FarmerId { get; set; }

        public User User { get; set; }
       
        public string CropName { get; set; } = null!;
        public string Location { get; set; } = null!;
        public int QtyAvailable { get; set; }
        public decimal ExpectedPrice { get; set; }
        public CropType CropType { get; set; }
        
    }
}
