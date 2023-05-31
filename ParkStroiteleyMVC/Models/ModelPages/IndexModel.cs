using Microsoft.AspNetCore.Mvc;

using ParkStroiteleyMVC.Models.ObjectDTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkStroiteleyMVC.Models.ModelPages
{
    public class IndexModel : LayoutModel
    {
        public IndexModel(string name, string about, ContactsDTO contacts) : base(name, about, contacts)
        { }

        public List<NewDTO> News { get; set; } = new List<NewDTO>();
        public List<GalleryDTO> Gallery { get; set; } = new List<GalleryDTO>();
    }
}
