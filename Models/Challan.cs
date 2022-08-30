using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EChallan1.Web.Models
{
    [Table(name: "Challans")]
    public class Challan
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChallanID { get; set; }

        [Required(ErrorMessage = "It's An Required Field")]
        [Display(Name = "Challan Number")]
        public string ChallanNumber { get; set; }

        [Required(ErrorMessage = "It's An Required Field")]
        [StringLength(100)]
        [Display(Name = "Challan Description")]
        public string ChallanDescription { get; set; }

        [Display(Name = "Date")]
        [Required(ErrorMessage = "Date is required")]
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "{0} is an required field")]
        [Display(Name = "Fine")]
        public int Fine { get; set; }

        [JsonIgnore]

        [Required]
        public int Customerid { get; set; }

        [ForeignKey(nameof(Challan.Customerid))]
        public Customer Customer { get; set; }

        [JsonIgnore]
        public int IID { get; set; }

        [ForeignKey(nameof(Challan.IID))]
        public Issue Issue { get; set; }

        [JsonIgnore]
        public ICollection<ChallanDetail> ChallanDetail { get; set; }
    }
}
