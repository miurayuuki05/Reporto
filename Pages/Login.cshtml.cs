using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Reporto.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string? Username { get; set; }
        [BindProperty]
        public string? Password { get; set; }


        public void OnGet()
        {
        }

        public void OnPost()
        {
            // Handle Login
            

            // Redirect to Home
            Response.Redirect("/Home");


        }
    }
}
