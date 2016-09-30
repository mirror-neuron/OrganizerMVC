using OrganizerMVC.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrganizerMVC.Models
{
    public class FullContacts
    {
        public Contacts Focus { get; set; }
        public IEnumerable<Contacts> Contacts { get; set; }
    }
}