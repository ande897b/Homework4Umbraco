using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClassLibrary;
using Homework4Umbraco.Data;

namespace Homework4Umbraco.Pages.Participants
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
        public Participant Participant { get; set; }
        public SerialNumber serialNumber { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (ValidSerialNumber())
            {
                _context.Participant.Add(Participant);
                ParticipantController.AddParticipant(Participant);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            else
            {
                return RedirectToPage("./Index");
            }
        }

        private bool ValidSerialNumber()
        {

            List<SerialNumber> serialnumbers = SerialNumberController.GetSerialNumbers();

            foreach (var item in serialnumbers)
            {
                if (item.SerialNumberID==Participant.SerialNumberID)
                {                
                return !(ParticipantController.GetParticipants().Count(x => x.SerialNumberID == Participant.SerialNumberID) > 1);
                }
            }


            return false;

        }
    }
}