using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkStroiteleyMVC.Models.ObjectDTO
{
    public class ContactsDTO
    {
        public int Id { get; set; }
        public string MainURLSite { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberZam { get; set; }
        public string Email { get; set; }
        public string LinkVK { get; set; }
        public string LinkInst { get; set; }
        public string LinkFacebook { get; set; }
        public string LinkOK { get; set; }
        public string PhoneWhatsUp { get; set; }
        public string AdministratorFIO { get; set; }
        public string AdministratorFIOZam { get; set; }
        public string PositionAdmin { get; set; }
    }
}
