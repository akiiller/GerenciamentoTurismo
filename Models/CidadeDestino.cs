using System.ComponentModel.DataAnnotations;

namespace GerenciamentoTurismo.Models
{
    public class CidadeDestino
    {
        public int Id { get; set; }

        [Display(Name = "Nome da Cidade")] 
        [Required(ErrorMessage = "O nome da cidade é obrigatório.")] 
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")] 
        public string Nome { get; set; }
        public int PaisDestinoId { get; set; }
        public PaisDestino Pais { get; set; }
        public List<PacoteDestino> PacoteDestinos { get; set; } = new();
    }
}
