using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace GerenciamentoTurismo.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime DataReserva { get; set; }

        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [ValidateNever]
        public Cliente Cliente { get; set; }

        [Display(Name = "Pacote Turístico")]
        public int PacoteTuristicoId { get; set; }

        [ValidateNever]
        public PacoteTuristico PacoteTuristico { get; set; }
        
    }
}
