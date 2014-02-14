using System.ComponentModel.DataAnnotations;

namespace OmegaLabsZero.Models
{
    public class StatusViewModel
    {
        [Required]
        [Key]
        [Display(Name = "ID status")]
        public int STA_ID { get; set; }

        [Required]
        [Display(Name = "Nome status")]
        public string STA_NOME { get; set; }
    }
}