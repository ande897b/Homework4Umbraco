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
    public class IndexModel : PageModel
    {
        private readonly Homework4Umbraco.Data.Homework4UmbracoContext _context;

        public IndexModel(Homework4Umbraco.Data.Homework4UmbracoContext context)
        {
            _context = context;
        }

        public IList<SerialNumber> SerialNumber { get;set; }

        public async Task OnGetAsync()
        {
            SerialNumber = await _context.SerialNumber.ToListAsync();
        }
    }
}
