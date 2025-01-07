using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Reporto.Data;

namespace Reporto.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly AppDbContext? _context;

        public DashboardModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string? Username { get; set; }
        public void OnGet()
        {
            Users = _context?.Users.ToListAsync().Result;
        }
        public List<User>? Users { get; set; }
    }
}
