using ParkStroiteleyMVC.Models.ObjectDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkStroiteleyMVC.Models.ModelPages
{
    public class MapModel : LayoutModel
    {
        public MapModel(string name, string about, ContactsDTO contacts) : base(name, about, contacts)
        { Contacts = contacts; }
        public ContactsDTO Contacts { get; set; }

    }
}
