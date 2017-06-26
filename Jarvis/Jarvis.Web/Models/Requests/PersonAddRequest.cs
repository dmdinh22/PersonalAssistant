using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jarvis.Web.Models.ViewModels
{
    public class PersonAddRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}