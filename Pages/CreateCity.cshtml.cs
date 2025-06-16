using GerenciamentoTurismo.Data;
using GerenciamentoTurismo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GerenciamentoTurismo.Pages
{
    public class CreateCityModel : PageModel
    {
        private readonly AgenciaTurismoContext _context;

        public CreateCityModel(AgenciaTurismoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CidadeDestino Cidade { get; set; }

        public SelectList Paises { get; set; }


        public IActionResult OnGet()
        {
            Paises = new SelectList(_context.PaisesDestino, "Id", "Nome");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Paises = new SelectList(_context.PaisesDestino, "Id", "Nome", Cidade.PaisDestinoId);
                return Page();
            }
            _context.CidadesDestino.Add(Cidade);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}