using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Foxtrot.Models
{
    public enum EmployeeClass
    {
        Management,
        General
    }
    public class EmployeeProfile
    {
        public EmployeeClass Class { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(30)]
        public string Title { get; set; }
        [MaxLength(25)]
        public string Location { get; set; }
    }
}