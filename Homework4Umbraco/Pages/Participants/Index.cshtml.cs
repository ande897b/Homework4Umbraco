using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClassLibrary;
using Homework4Umbraco.Data;

namespace Homework4Umbraco.Pages.Participants
{
    public class IndexModel : PageModel
    {
        private readonly Homework4UmbracoContext _context;

        public IndexModel(Homework4UmbracoContext context)
        {
            _context = context;
        }

        public string FNameSort { get; set; }
        public string LNameSort { get; set; }
        public string EmailSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Participant> Participant { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            FNameSort = String.IsNullOrEmpty(sortOrder) ? "fname" : "";
            LNameSort = String.IsNullOrEmpty(sortOrder) ? "lname" : "";
            EmailSort = String.IsNullOrEmpty(sortOrder) ? "email" : "";
         
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Participant> participantIQ = from s in _context.Participant
                                                 select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                participantIQ = participantIQ.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "fname":
                    participantIQ = participantIQ.OrderBy(s => s.FirstName);
                    break;
                case "lname":
                    participantIQ = participantIQ.OrderBy(s => s.LastName);
                    break;
                case "email":
                    participantIQ = participantIQ.OrderBy(s => s.Email);
                    break;

                default:
                    participantIQ = participantIQ.OrderBy(s => s.FirstName);
                    break;
            }

            int pageSize = 10;
            Participant = await PaginatedList<Participant>.CreateAsync(
                participantIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
