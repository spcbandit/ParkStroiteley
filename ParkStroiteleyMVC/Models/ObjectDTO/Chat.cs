using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkStroiteleyMVC.Models.ObjectDTO
{
    public class DialogDTO
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string About { get; set; }
        public List<MessageDTO> Messages { get; set; }
        public DateTime DateCreate { get; set; }
    }
    public class MessageDTO
    { 
        public UserDTO User { get; set; }
        public AdminDTO Admin { get; set; }
        public string About { get; set; }
        public string Text { get; set; }
        public DateTime DateSend { get; set; }
    }
}
