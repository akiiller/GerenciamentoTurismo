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
    public class DeleteModel : PageModel
    {
        private readonly GerenciamentoTurismo.Data.AgenciaTurismoContext _context;

        public DeleteModel(GerenciamentoTurismo.Data.AgenciaTurismoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cliente Cliente { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (cliente is not null)
            {
                Cliente = cliente;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cliente != null)
            {
                cliente.DeletedAt = DateTime.UtcNow;
                _context.Update(cliente);
                await _context.SaveChangesAsync();
            }

            TempData["SuccessMessage"] = $"Cliente '{Cliente.Nome}' atualizado com sucesso!";

            return RedirectToPage("./Index");
        }
    }
}
