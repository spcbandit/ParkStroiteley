using Microsoft.AspNetCore.Mvc;
using ParkStroiteleyMVC.Models.ObjectDTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkStroiteleyMVC.Models.ModelPages
{
    public class LayoutModel
    {
        public LayoutModel() { }
        public LayoutModel(string namePage, string aboutPage, ContactsDTO contacts)
        {
            NamePage = namePage;
            AboutPage = aboutPage;
            Contacts = contacts;
        }

        public string NamePage { get; set; }
        public string AboutPage { get; set; }
        public ContactsDTO Contacts { get; set; }
    }
}
