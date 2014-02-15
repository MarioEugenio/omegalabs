using System.ComponentModel.DataAnnotations;


namespace OmegaLabsZero.Models
{
    public class UsuarioViewModel
    {
        [Required]
        [Key]
        [Display(Name = "ID Usuario")]
        public int USR_ID { get; set; }

        [Required]
        [Display(Name = "Nome Usuario")]
        public string USR_NOME { get; set; }

        [Required]
        [Display(Name = "Email Usuario")]
        public string USR_EMAIL { get; set; }

        [Required]
        [Display(Name = "Senha Usuario")]
        public string USR_SENHA { get; set; }

        [Required]
        [Display(Name = "Status")]
        public int STA_ID { get; set; }

        [Required]
        [Display(Name = "Status Nome")]
        public string STA_NOME { get; set; }
    }
}