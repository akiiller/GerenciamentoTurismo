using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoTurismo.Models
{
    public class PacoteTuristico
    {
        public int Id { get; set; }

        [Display(Name = "Título do Pacote")]
        [Required(ErrorMessage = "O título é obrigatório.")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "O título deve ter entre 10 e 200 caracteres.")]
        public string Titulo { get; set; }

        [Display(Name = "Data de Início")]
        [Required(ErrorMessage = "A data de início é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [Display(Name = "Capacidade Máxima")]
        [Required(ErrorMessage = "A capacidade máxima é obrigatória.")]
        [Range(1, 100, ErrorMessage = "A capacidade deve ser um número entre 1 e 100.")]
        public int CapacidadeMaxima { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0.01, 99999.99, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal Preco { get; set; }

        // Um pacote pode ter várias reservas.
        public List<Reserva> Reservas { get; set; } = new();

        // Navegação para a entidade de associação (representa os destinos do pacote).
        public List<PacoteDestino> PacoteDestinos { get; set; } = new();
    }
}
