using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Participant
    {
        public int ID { get; set; }
        [Required]
        [MaxLength (50)]
        [DisplayName ("First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [EmailAddress]
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9]{4}[-]){3}[a-zA-Z0-9]{4}", ErrorMessage = "Serial number format should be like this: xxxx-xxxx-xxxx-xxxx")] // sets the required input as "xxxx-xxxx-xxxx-xxxx"
        [Required]
        [DisplayName("Serial Number")]
        public string SerialNumberID { get; set; }





       
    }
    
}
