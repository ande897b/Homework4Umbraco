using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClassLibrary;
using Homework4Umbraco.Data;
using Microsoft.AspNetCore.Authorization;

namespace Homework4Umbraco.Pages.Participants
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly Homework4Umbraco.Data.Homework4UmbracoContext _context;

        public DetailsModel(Homework4Umbraco.Data.Homework4UmbracoContext context)
        {
            _context = context;
        }

        public Participant Participant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            Participant = await _context.Participant.FirstOrDefaultAsync(m => m.ID == id);

            if (Participant == null)
            {
                return NotFound();
            }
            return Page();
        }
        
    }
}
