using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Reporto.Data;

namespace Reporto.Pages
{
    public class LoginModel : PageModel
    {
        private readonly AppDbContext? _context;
        public LoginModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string? Username { get; set; }
        [BindProperty]
        public string? Password { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPostLogin()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                return Page();
            }

            var user = _context?.Users.FirstOrDefaultAsync(u => u.Username == Username).Result;

            if (user == null)
            {
                return Page();
            }
            
            var valid = BCrypt.Net.BCrypt.Verify(Password, user?.Password);

            if (!valid)
            {
                return Page();
            }
            
            return RedirectToPage("Index");
        }
    }
}
