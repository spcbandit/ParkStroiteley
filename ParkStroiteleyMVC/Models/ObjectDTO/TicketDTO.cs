using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkStroiteleyMVC.Models.ObjectDTO
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public string Contact { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public UserDTO User { get; set; }
    }
}
