using System.Collections.Generic;
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
        private readonly LeagueContext _context;
        public List<Division> divisions { get; set; }
        private Conference conference { get; set; }
        public ConferenceModel(LeagueContext context)
        {
            _context = context;
        }
        public async Task OnGetAsync(string name)
        {
            conference = await _context.Conferences.FirstOrDefaultAsync(c => c.Name == name);
            var division = from d in _context.Divisions select d;
            division = division.Where(d => d.ConferenceId.Contains(conference.ConferenceId));

            divisions = await division.ToListAsync();
        }    
    }

}