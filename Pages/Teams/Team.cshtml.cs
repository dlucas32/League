using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using League.Data;
using League.Models;


namespace League.Pages.Teams
{
    public class TeamModel : PageModel
    {
        private readonly LeagueContext _context;
        public TeamModel(LeagueContext context)
        {
            _context = context;
        }
        public Team Team { get; set; }
        public async Task OnGetAsync(string ID)
        {
            Team = await _context.Teams.FirstOrDefaultAsync(t => t.TeamId == ID);
        }

            

    }

}
