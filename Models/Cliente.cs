using System.ComponentModel.DataAnnotations;

namespace GerenciamentoTurismo.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do cliente é obrigatório.")] // Campo obrigatório
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")] // Limita o tamanho
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email do cliente é obrigatório.")] // Campo obrigatório
        [EmailAddress(ErrorMessage = "Por favor, insira um formato de email válido.")] // Valida formato de email
        public string Email { get; set; }
        public List<Reserva> Reservas { get; set; } = new();

        public DateTime? DeletedAt { get; set; }
    }
}
