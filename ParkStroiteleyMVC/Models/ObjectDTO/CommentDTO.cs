using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkStroiteleyMVC.Models.ObjectDTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public UserDTO User { get; set; }
        /// <summary>
        /// If UserDTO null
        /// </summary>
        public string UserName { get; set; }
        public string Comment { get; set; }
        public DateTime DateAdd { get; set; }
    }
}
