using System.Linq;
using System.Threading.Tasks;
using League.Data;
using League.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace League.Pages
{
    public class ConferenceModel : PageModel
    {
        private readonly LeagueContext _context { get; set;}
        public DbSet<Division> division { get; set; }
        public ConferenceModel(LeagueContext context)
        {
            _context = context;
        }
        public async Task OnGetAsync(string id)
        {
            division = (DbSet<Division>)_context.Divisions.Where(d => d.ConferenceId == id);
        }    
    }

}