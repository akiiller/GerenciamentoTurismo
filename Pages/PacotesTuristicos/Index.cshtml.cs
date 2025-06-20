using GerenciamentoTurismo.Data;
using GerenciamentoTurismo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoTurismo.Pages.PacotesTuristicos
{
    public class IndexModel : PageModel
    {
        private readonly AgenciaTurismoContext _context;

        public IndexModel(AgenciaTurismoContext context)
        {
            _context = context;
        }

        // Propriedade para armazenar a lista de pacotes a ser exibida na página
        public IList<PacoteTuristico> PacotesTuristicos { get; set; }

        // Método executado quando a página é carregada via GET
        public async Task OnGetAsync()
        {
            // Busca todos os pacotes no banco de dados e os armazena na propriedade
            PacotesTuristicos = await _context.PacotesTuristicos.ToListAsync();
        }
    }
}
