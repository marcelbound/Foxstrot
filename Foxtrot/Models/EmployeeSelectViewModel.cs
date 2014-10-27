using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foxtrot.Models
{
    public class EmployeeSelectViewModel
    {
        public string FullName { get; set; }
        public Guid Id { get; set; }
        public string Email { get; set; }
    }
}