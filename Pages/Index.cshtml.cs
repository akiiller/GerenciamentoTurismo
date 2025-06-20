using GerenciamentoTurismo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoTurismo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AgenciaTurismoContext _context;

        public IndexModel(AgenciaTurismoContext context)
        {
            _context = context;
        }

        public DashboardViewModel DashboardStats { get; set; }

        // Uma classe interna para organizar os dados do dashboard
        public class DashboardViewModel
        {
            public int TotalClientes { get; set; }
            public int TotalPacotes { get; set; }
            public int TotalReservas { get; set; }
            public int PacotesFuturos { get; set; }
        }

        public async Task OnGetAsync()
        {
            // Inicializa nosso objeto de estatísticas
            DashboardStats = new DashboardViewModel
            {
                // Conta o total de registros em cada tabela
                TotalClientes = await _context.Clientes.CountAsync(),
                TotalPacotes = await _context.PacotesTuristicos.CountAsync(),
                TotalReservas = await _context.Reservas.CountAsync(),

                // Conta apenas os pacotes cuja data de início é no futuro
                PacotesFuturos = await _context.PacotesTuristicos.CountAsync(p => p.DataInicio > System.DateTime.Now)
            };
        }
    }
}
