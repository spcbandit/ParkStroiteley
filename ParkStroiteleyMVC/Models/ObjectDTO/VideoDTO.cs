using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkStroiteleyMVC.Models.ObjectDTO
{
    public class VideoDTO
    {
        public int Id { get; set; }
        public string URL { get; set; }
        public string About { get; set; }
        public DateTime DateAdd { get; set; }
    }
}
