using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EChallan1.Web.Models
{
    [Table(name: "ChallanDetails")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Customerid { get; set; }

        [Required(ErrorMessage = "It's An Required Field")]
        [Display(Name = "RC Number")]
        public string RCNumber { get; set; }

        [Required(ErrorMessage = "It's An Required Field")]
        [Display(Name = "Car Number")]
        public string CarNumber { get; set; }

        [Required(ErrorMessage = "Please Provide {0}!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid! Mobile Number")]
        [Display(Name = "Mobile Number")]

        public int MobileNumber { get; set; }

        [JsonIgnore]
        public ICollection<Challan> Challan { get; set; }
    }
}
