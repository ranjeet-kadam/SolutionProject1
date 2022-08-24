using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EChallan1.Web.Models
{
    [Table(name: "ChallaDetails")]
    public class ChallanDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CDID { get; set; }

        [Required]
        [Display(Name ="UPI Id")]
        public string UpiId { get; set; }   

        [Required]
        [Display(Name ="Payment Status")]
        public bool PaymentStatus { get; set; }

        public int CID { get; set; }

        [ForeignKey(nameof(ChallanDetail.CID))]
        public Challan Challan { get; set; }

        public int  PID { get; set; }

        [ForeignKey(nameof(ChallanDetail.PID))]
        public PaymentMethod PaymentMethod { get; set; }
    }
}
