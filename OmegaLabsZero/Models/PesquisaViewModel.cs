using System.ComponentModel.DataAnnotations;

namespace OmegaLabsZero.Models
{
    public class PesquisaViewModel
    {
        [Required]
        [Key]
        [Display(Name = "ID da Substância")]
        public int SUB_ID { get; set; }

        [Required]
        [Display(Name = "Nome da Substância")]
        public string SUB_NOME { get; set; }

        [Required]
        [Display(Name = "ID Status")]
        public int STA_ID { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string STA_NOME { get; set; }

        [Display(Name = "ID Substância Derivada")]
        public int? DER_ID { get; set; }

        [Display(Name = "Nome Substância Derivada")]
        public string DER_NOME { get; set; }

        [Display(Name = "Detalhes da Substância")]
        public string SUB_DETALHES { get; set; }

    }
}