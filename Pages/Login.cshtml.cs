using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GerenciamentoTurismo.Pages
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "O campo Usuário é obrigatório")]
            public string Usuario { get; set; }

            [Required(ErrorMessage = "O campo Senha é obrigatório")]
            [DataType(DataType.Password)]
            public string Senha { get; set; }
        }

        public void OnGet(string returnUrl = "/")
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = "/")
        {
            if (ModelState.IsValid)
            {
                if (Input.Usuario == "admin" && Input.Senha == "1234")
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, Input.Usuario)
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Usuário ou senha inválidos.");
                }
            }
            return Page();
        }
    }
}
