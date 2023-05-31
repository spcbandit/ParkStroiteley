using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using ParkStroiteleyMVC.Controllers.Core.Interface;
using ParkStroiteleyMVC.Models.ModelPages;
using ParkStroiteleyMVC.Models.ObjectDTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkStroiteleyMVC.Controllers.Core.HomeCore
{
    public class HomeDispatcher : IHomeDispatcher
    {
        #region [IHomeDispatcher]
        public IndexModel Index { get { return CreateIndex(); } }
        public AboutModel About { get { return CreateAbout(); } }
        public MapModel Map { get { return CreateMap(); } }
        public NewsModel News { get { return CreateNews(PageNews); } }

        public int CardNewsId { get; set; }
        public int PageNews { get; set; } 
        public CardNewsModel CardNews { get { return CreateCardNews(); } }
        #endregion
        private Action<string> Logs => Startup.Logs;
        private HomeDigger Digger;
        public HomeDispatcher()
        {
            Digger.Connect();
        }

        public List<NewDTO> GetNewsLazy(int lastID)
        {
            List<NewDTO> news = null;
            try
            {
                news = Digger.GetNewsAfterLastId(lastID);
            }
            catch (Exception ex)
            {
                Logs.Invoke($"~~MethodeDispatcher: CreateNewsLazy {Environment.NewLine}{ex.Message}");
            }
            return news;
        }

        #region [Helpers]

        private AboutModel CreateAbout()
        {
            AboutModel model = null;
                 try
            {
                model = new AboutModel(
                          "О ПАРКЕ",
                          "Одно из лучших мест времяпрепровождения в г.Орске",
                          Digger.GetContacts() ?? new Models.ObjectDTO.ContactsDTO() { PhoneNumber = "+7000000" });
           
            }
            catch (Exception ex)
            {
                Logs.Invoke($"~~MethodeDispatcher: CreateIndex {Environment.NewLine}{ex.Message}");
            }
            return model;
        }
        private IndexModel CreateIndex()
        {
            IndexModel model = new IndexModel(
                "ПАРК СТРОИТЕЛЕЙ",
                "Одно из лучших мест времяпрепровождения в г.Орске",
                Digger.GetContacts() ?? new Models.ObjectDTO.ContactsDTO() { PhoneNumber = "+7000000" } );
            try
            {
                model.News = Digger.GetNewsPreview();
                model.Gallery = Digger.GetGalleryPreview();
            }
            catch (Exception ex)
            {
                Logs.Invoke($"~~MethodeDispatcher: CreateIndex {Environment.NewLine}{ex.Message}");
            }
            return model;
        }

        private MapModel CreateMap()
        {
            MapModel model = null;
            try
            {
              model = new MapModel(
              "КАРТА ПАРКА",
              "Здесь вы можете посмотреть карту всего парка и основные контакты.",
              Digger.GetContacts() ?? new Models.ObjectDTO.ContactsDTO() { PhoneNumber = "+7000000" });
        
            }
            catch(Exception ex)
            {
                Logs.Invoke($"~~MethodeDispatcher: CreateMap {Environment.NewLine}{ex.Message}");
            }
            return model;
        }
        public NewsModel CreateNews(int page = 1)
        {
            NewsModel model = null;
            try
            {
                model = new NewsModel(
                "НОВОСТИ ПАРКА",
                "Последние новости и события нашего любимого парка.",
                Digger.GetContacts() ?? new Models.ObjectDTO.ContactsDTO() { PhoneNumber = "+7000000" });
                model.News = Digger.GetNews(page);
            }
            catch (Exception ex)
            {
                Logs.Invoke($"~~MethodeDispatcher: CreateNews {Environment.NewLine}{ex.Message}");
            }
            return model;
        }
        public CardNewsModel CreateCardNews()
        {
            CardNewsModel model = null;
            try
            {
                var news = Digger.GetOneNews(CardNewsId);
                model = new CardNewsModel(
                "НОВОСТИ ПАРКА",
                "Последние новости и события нашего любимого парка.",
                Digger.GetContacts() ?? new Models.ObjectDTO.ContactsDTO() { PhoneNumber = "+7000000" });
                model.News = news;
            }
            catch (Exception ex)
            {
                Logs.Invoke($"~~MethodeDispatcher: CreateCardNews {Environment.NewLine}{ex.Message}");
            }
            return model;
        }

        public void PostComment(int id, string name, string email, string message)
        {
            Digger.PostComment(id, name,email,message);
        }
        #endregion
    }
}
