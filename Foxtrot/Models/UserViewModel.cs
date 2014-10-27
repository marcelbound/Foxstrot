using Foxtrot.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foxtrot.Models
{
    public class UserViewModel
    {
        // permissions right now can be represented with a flag, 
        // but this class could easily host a dictionary of roles => permissions
        // and cached per session.
        public bool IsManager { get; set; }   
    }
}