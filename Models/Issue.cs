using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EChallan1.Web.Models
{
    [Table(name: "Issues")]
    public class Issue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IID { get; set; }

        [Required]
        [StringLength(50)]
        public string Issues { get; set; }

        [Required(ErrorMessage = "It's An Required Field")]
        [StringLength(100)]
        [Display(Name = "Issue Description")]
        public string IssueDescription { get; set; }

        [JsonIgnore]
        public ICollection<Challan> Challan { get; set; }
    }
}
