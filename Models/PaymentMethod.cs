using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.ComponentModel;
using System.Collections.Generic;

namespace EChallan1.Web.Models
{
    [Table(name: "PaymentMethods")]
    public class PaymentMethod
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Payment Method ID")]
        public int PaymentMethodId { get; set; }

        [StringLength(50)]
        [Display(Name ="Payment Method")]
        public string PaymentStatus { get; set; }

        [Required]
        [DefaultValue(true)]
        [Display(Name = "Method Enabled")]
        public bool MethodEnabled { get; set; }

        public ICollection<ChallanDetail> ChallanDetail { get; set; }
    }
}
