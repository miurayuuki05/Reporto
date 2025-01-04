using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Reporto.Data;



namespace Reporto.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly AppDbContext? _context;
        public RegisterModel(AppDbContext context)
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

        public  Task<IActionResult> OnPostRegister()
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(Password);
            _context?.Users.Add(new User
            {
                Username = Username,
                Password = hashedPassword
            });
            
            _context?.SaveChanges();

            return Task.FromResult<IActionResult>(Redirect("/"));
        }
    }
}
