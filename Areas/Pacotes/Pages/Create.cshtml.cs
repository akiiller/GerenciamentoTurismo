using GerenciamentoTurismo.Data;
using GerenciamentoTurismo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GerenciamentoTurismo.Areas.Pacotes.Pages
{
    public class CreateModel : PageModel
    {
        private readonly AgenciaTurismoContext _context;

        public CreateModel(AgenciaTurismoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PacoteTuristico PacoteTuristico { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (PacoteTuristico.DataInicio.Date < DateTime.Now.Date)
            {
                ModelState.AddModelError("PacoteTuristico.DataInicio", "A data de início não pode ser anterior a hoje.");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PacotesTuristicos.Add(PacoteTuristico);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}