using Microsoft.EntityFrameworkCore;
using ParkStroiteleyMVC.Models;
using ParkStroiteleyMVC.Models.ObjectDTO;
using ParkStroiteleyMVC.Controllers.Core.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkStroiteleyMVC.Models.Enums;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ParkStroiteleyMVC.Controllers.Core.HomeCore
{
    public struct HomeDigger : IDigger
    {
        #region [Const/Props]
        private const int CountPreviewNews = 6;
        private const int CountPreviewGallery = 9;
        private DBContext Context;
        public bool IsDispose { get; set; }
        #endregion

        public ContactsDTO GetContacts()
        {
            var contacts = Context.Contacts.FirstOrDefault();
            return contacts;
        }
        public void PostComment(int id, string name, string email, string comment)
        {
            var news = Context.News.Where(x => x.Id == id).Include(x => x.Comments).FirstOrDefault();
            news.Comments.Add(new CommentDTO() { Comment = comment, User = new UserDTO() { Email = email }, UserName = name, DateAdd = DateTime.Now  });
            Context.SaveChanges();
        }
        public List<NewDTO> GetNewsPreview()
        {
            List<NewDTO> news = null;
            news = Context.News
                .OrderByDescending(x => x.Id)
                .Take(CountPreviewNews)
                .Include(x=>x.Blocks)
                .ToList();
            news.Reverse();

            return news;
        }
        public List<GalleryDTO> GetGalleryPreview()
        {
            List<GalleryDTO> gallery = null;
            gallery = Context.Gallery
                .OrderByDescending(x => x.Id)
                .Take(CountPreviewGallery)
                .ToList();
            gallery.Reverse();

            return gallery;
        }
        public List<NewDTO> GetNewsStart()
        {
            List<NewDTO> news = null;
            news = Context.News
                .OrderByDescending(x => x.Id)
                .Take(20)
                .Include(x => x.Blocks)
                .ToList();
            return news;
        }

        public List<NewDTO> GetNewsAfterLastId(int id)
        {
            List<NewDTO> news = null;
            news = Context.News
                .Where(x => x.Id < id)
                .OrderByDescending(x => x.Id)
                .Take(20)
                .Include(x => x.Blocks)
                .ToList();
            return news;
        }

        public List<NewDTO> GetNews(DateTime start, DateTime end, NewsType? type)
        {
            List<NewDTO> news = null;
            if (type.HasValue)
            {
                news = Context.News
                    .Where(x => x.DatePublish >= start && x.DatePublish <= end && x.Type == type.Value)
                    .OrderByDescending(x=>x.Id)
                    .Include(x => x.Blocks)
                    .ToList();
            }
            else 
            {
                news = Context.News
                    .Where(x => x.DatePublish >= start && x.DatePublish <= end)
                    .OrderByDescending(x=>x.Id)
                    .Include(x => x.Blocks)
                    .ToList();
            }
            return news;
        }
        public List<NewDTO> GetNews(int page = 1)
        {
            List<NewDTO> news = null;
            int count = 20;
            news = Context.News
                .OrderByDescending(x => x.Id)
                .Skip((count * page) - count)
                .Take(count * page)
                .Include(x => x.Blocks)
                .ToList();
            return news;
        }
        public NewDTO GetOneNews(int id)
        {
            NewDTO @new = null;
            @new = Context.News.Where(x => x.Id == id).Include(x => x.Blocks).Include(x => x.Comments).FirstOrDefault();
            return @new;
        }

        public void SetCommentIntoNews(int id, string message, string name)
        {
            var news = Context.News.Where(x => x.Id == id).Include(x=>x.Comments).FirstOrDefault();
            news.Comments.Add(new CommentDTO() { DateAdd = DateTime.Now, Comment = message, UserName = name });
            Context.SaveChanges();
        }

        public void SetLike(int id)
        {
            var news = Context.News.Where(x => x.Id == id).FirstOrDefault();
            news.CountLikes++;
            Context.SaveChanges();
        }

        public void SetDislike(int id)
        {
            var news = Context.News.Where(x => x.Id == id).FirstOrDefault();
            news.CountDislikes++;
            Context.SaveChanges();
        }

        #region [IDisposable]
        public void Connect()
        {
            Context = new DBContext(new DbContextOptions<DBContext>());
            IsDispose = false;
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context = null;
            IsDispose = true;
        }
        #endregion
    }
}
