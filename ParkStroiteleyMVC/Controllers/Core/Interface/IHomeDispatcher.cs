using Microsoft.AspNetCore.Mvc;

using ParkStroiteleyMVC.Models.ModelPages;
using ParkStroiteleyMVC.Models.ObjectDTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkStroiteleyMVC.Controllers.Core.Interface
{
    public interface IHomeDispatcher
    {
        public IndexModel Index { get; }
        public AboutModel About{ get; }
        public MapModel Map { get; }

        public int PageNews { get; set; }
        public NewsModel News { get; }
        public List<NewDTO> GetNewsLazy(int lastID);
        public void PostComment(int id, string name, string email, string message);

        public int CardNewsId { get; set; }
        public CardNewsModel CardNews { get; }
    }
}
