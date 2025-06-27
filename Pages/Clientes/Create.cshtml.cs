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
        private readonly AgenciaTurismoContext _context;

        public CreateModel(AgenciaTurismoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Cliente Cliente { get; set; } // = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine($"{Cliente.Id} ");
            // Se o ModelState não for válido (incluindo nossos erros customizados), recarrega a página
            if (!ModelState.IsValid)
            {
                // Adicione um log ou um breakpoint aqui para inspecionar os erros.
                // Por exemplo, para ver os erros no console:
                foreach (var modelStateEntry in ModelState.Values)
                {
                    //var propertyName = modelStateEntry.Key;
                    //var errors = modelStateEntry.Value.Errors;
                    foreach (var error in modelStateEntry.Errors)
                    {
                        Console.WriteLine($"Erro de validação no campo : {error.ErrorMessage}{Cliente.Id}");
                    }
                }
                return Page();
            }

            _context.Clientes.Add(Cliente);
            
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"Cliente '{Cliente.Nome}' criado com sucesso!";

            return RedirectToPage("./Index");
        }
    }
}
