using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClassLibrary;
using Homework4Umbraco.Data;

namespace Homework4Umbraco.Pages.SerialNumbers
{
    public class CreateModel : PageModel
    {
        private readonly Homework4Umbraco.Data.Homework4UmbracoContext _context;

        public CreateModel(Homework4Umbraco.Data.Homework4UmbracoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SerialNumber SerialNumber { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SerialNumber.Add(SerialNumber);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}