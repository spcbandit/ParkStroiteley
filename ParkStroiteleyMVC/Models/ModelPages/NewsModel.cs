using ParkStroiteleyMVC.Models.ObjectDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkStroiteleyMVC.Models.ModelPages
{
    public class NewsModel : LayoutModel
    {
        public NewsModel(string name, string about, ContactsDTO contacts) : base(name, about, contacts)
        { }
        public List<NewDTO> News { get; set; }
    }
}
