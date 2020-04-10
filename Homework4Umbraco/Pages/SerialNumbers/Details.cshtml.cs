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

namespace Homework4Umbraco.Pages.SerialNumbers
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly Homework4Umbraco.Data.Homework4UmbracoContext _context;

        public DetailsModel(Homework4Umbraco.Data.Homework4UmbracoContext context)
        {
            _context = context;
        }

        public SerialNumber SerialNumber { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SerialNumber = await _context.SerialNumber.FirstOrDefaultAsync(m => m.SerialNumberID == id);

            if (SerialNumber == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
