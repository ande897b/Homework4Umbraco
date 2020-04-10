using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClassLibrary;
using Homework4Umbraco.Data;
using Microsoft.AspNetCore.Authorization;

namespace Homework4Umbraco.Pages.SerialNumbers
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly Homework4Umbraco.Data.Homework4UmbracoContext _context;

        public EditModel(Homework4Umbraco.Data.Homework4UmbracoContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SerialNumber).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SerialNumberExists(SerialNumber.SerialNumberID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SerialNumberExists(string id)
        {
            return _context.SerialNumber.Any(e => e.SerialNumberID == id);
        }
    }
}
