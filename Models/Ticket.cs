using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data;

namespace Bug_Tracker.Models
{
    public class Ticket
    {
        [Display(Name ="Bug Title")]
        [Required(ErrorMessage = "You must give us your email address.")]
        public string TicketName { get; set; }

        [Display(Name = "Description of Problem")]
        public string TicketDescription { get; set; }

        [Display(Name = "Project")]
        public string ProjectName { get; set; }

        [Display(Name = "Priority Level")]
        public string Priority { get; set; }

        [Display(Name = "Problem type")]
        public string TicketType { get; set; }

        [Display(Name = "Your Name")]
        [Required(ErrorMessage = "You must give us your name.")]
        public string SubmitterName { get; set; }

        [Display(Name = "Your Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "You must give us your email address.")]
        public string SubmitterEmail { get; set; }

        [Display(Name = "Confirm Email")]
        [DataType(DataType.EmailAddress)]
        [Compare("SubmitterEmail", ErrorMessage = "The email and confim email must match.")]
        [Required(ErrorMessage = "You must confirm your email address.")]
        public string ConfirmEmail { get; set; }

        private DateTime _SetDefaultDate = DateTime.Now;
        public DateTime CreatedDate {
            get
            {
                return _SetDefaultDate;
            }
            set
            {
                _SetDefaultDate = value;
            }
        }

    }

}