using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GerenciamentoTurismo.Data;
using GerenciamentoTurismo.Models;

namespace GerenciamentoTurismo.Pages_Clientes
{
    public class IndexModel : PageModel
    {
        private readonly GerenciamentoTurismo.Data.AgenciaTurismoContext _context;

        public IndexModel(GerenciamentoTurismo.Data.AgenciaTurismoContext context)
        {
            _context = context;
        }

        public IList<Cliente> Cliente { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Cliente = await _context.Clientes.ToListAsync();
        }
    }
}
