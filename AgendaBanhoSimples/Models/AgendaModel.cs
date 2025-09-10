using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaBanhoSimples.Models
{
    public class AgendaModel
    {
        [Key]
        public int IdBanho { get; set; }

        [Required(ErrorMessage = "! Digite a data do horário")]
        public DateTime DataBanho { get; set; }

        public string Observacoes { get; set; }

        public string Cliente { get; set; }

        [Required(ErrorMessage = "! Digite o nome do(s) cachorro(s)")]
        public string Cachorro { get; set; }

        [Column(TypeName = "decimal(10,2)")] 
        public decimal Valor { get; set; }
    }
}
