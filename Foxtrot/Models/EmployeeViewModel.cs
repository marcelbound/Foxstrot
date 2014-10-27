using Foxtrot.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace Foxtrot.Models
{
    public class EmployeeViewModel : RegisterViewModel
    {
        [Display(Name = "Class")]
        public EmployeeClass Class { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        public Guid Id { get; set; }
    }
}