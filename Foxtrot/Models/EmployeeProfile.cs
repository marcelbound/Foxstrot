using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Key]
        public Guid Id { get; set; }
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
        [MaxLength(150)]
        public string SearchText { get; set; }

        public ApplicationUser User { get; set; }

        public EmployeeProfile()
        {
            Id = Guid.NewGuid();
        }

        public void UpdateSearchText()
        {
            this.SearchText = string.Format("{0} {1} {2}", FirstName, LastName, Email).Trim();
        }

        [NotMapped]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}