using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GerenciamentoTurismo.Data;
using GerenciamentoTurismo.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoTurismo.Pages_Reservas
{
    public class CreateModel : PageModel
    {
        private readonly AgenciaTurismoContext _context;

        public CreateModel(AgenciaTurismoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Reserva Reserva { get; set; }

        // Propriedades para popular os dropdowns
        public SelectList ClientesSL { get; set; }
        public SelectList PacotesTuristicosSL { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            ClientesSL = new SelectList(await _context.Clientes.ToListAsync(), nameof(Cliente.Id), nameof(Cliente.Nome));

            var pacotesDisponiveis = await _context.PacotesTuristicos
                .Include(p => p.Reservas)
                .Where(p => p.DataInicio > DateTime.Now && p.Reservas.Count < p.CapacidadeMaxima)
                .ToListAsync();

            PacotesTuristicosSL = new SelectList(pacotesDisponiveis, nameof(PacoteTuristico.Id), nameof(PacoteTuristico.Titulo));

            return Page();
        }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            // --- VALIDA��O DAS REGRAS DE NEG�CIO ---

            // 1. Verificar se o pacote ainda est� dispon�vel (algu�m pode ter reservado enquanto o form estava aberto)
            var pacote = await _context.PacotesTuristicos
                .Include(p => p.Reservas)
                .FirstOrDefaultAsync(p => p.Id == Reserva.PacoteTuristicoId);
            Console.WriteLine($"{Reserva.Id} ");

            if (pacote == null || pacote.DataInicio <= DateTime.Now || pacote.Reservas.Count >= pacote.CapacidadeMaxima)
            {
                ModelState.AddModelError(string.Empty, "Este pacote n�o est� mais dispon�vel para reserva.");
            }

            // 2. Verificar se este cliente j� n�o reservou este pacote
            bool jaReservado = await _context.Reservas
                .AnyAsync(r => r.ClienteId == Reserva.ClienteId && r.PacoteTuristicoId == Reserva.PacoteTuristicoId);

            if (jaReservado)
            {
                ModelState.AddModelError(string.Empty, "Este cliente j� possui uma reserva para este pacote.");
            }

            // Se o ModelState n�o for v�lido (incluindo nossos erros customizados), recarrega a p�gina
            if (!ModelState.IsValid)
            {
                // Precisamos recarregar os dropdowns em caso de erro
                await OnGetAsync();
                return Page();
            }

            // Se tudo estiver certo, preenche a data da reserva e salva
            Reserva.DataReserva = DateTime.Now;
            _context.Reservas.Add(Reserva);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"Reserva '{Reserva}' criada com sucesso!";

            return RedirectToPage("./Index");
        }
    }
}
