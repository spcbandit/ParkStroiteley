using ParkStroiteleyMVC.Models.ObjectDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkStroiteleyMVC.Models.ModelPages
{
    public class CardNewsModel: LayoutModel
    {
        public CardNewsModel(string name, string about, ContactsDTO contacts) : base(name, about, contacts)
        { }
        public NewDTO News { get; set; }
    }
}
