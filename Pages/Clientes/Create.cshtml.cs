using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GerenciamentoTurismo.Data;
using GerenciamentoTurismo.Models;

namespace GerenciamentoTurismo.Pages_Clientes
{
    public class CreateModel : PageModel
    {
        private readonly GerenciamentoTurismo.Data.AgenciaTurismoContext _context;

        public CreateModel(GerenciamentoTurismo.Data.AgenciaTurismoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Cliente Cliente { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Clientes.Add(Cliente);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"Cliente '{Cliente.Nome}' criado com sucesso!";

            return RedirectToPage("./Index");
        }
    }
}
