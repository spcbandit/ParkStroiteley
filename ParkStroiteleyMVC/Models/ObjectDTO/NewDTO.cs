using Microsoft.AspNetCore.Http;

using ParkStroiteleyMVC.Models.Enums;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ParkStroiteleyMVC.Models.ObjectDTO
{
    public class NewDTO
    {
        public int? Id { get; set; }
        public string Header { get; set; }
        public NewsType Type { get; set; }
        public DateTime DatePublish { get; set; }
        public DateTime? DateDelete { get; set; }
        public List<BlockDTO> Blocks { get; set; }
        public List<CommentDTO> Comments { get; set; }
        public int CountLikes { get; set; }
        public int CountDislikes { get; set; }

        public NewsPreview GetPreview()
        {
            string? text = null;
            string? img = null;
            foreach (var item in Blocks) // Ищем первый попавшийся текстовый блок
            {
                if (item.Type == BlockType.Text)
                {
                    text = item.Text;
                    break;
                }
            }
            foreach (var item in Blocks) // Ищем первый попавшийся изображениевый блок
            {
                if (item.Type == BlockType.Image)
                {
                    img = item.ImageURL;
                    break;
                }
            }
            return new NewsPreview
            {
                Id = Id,
                Header = Header,
                Type = Type,
                DatePublish = DatePublish,
                Text = text == null ? "" : (text.Length <= 300? text : $"{text.Substring(0, 300)}..."),
                Image = img
            };
        }
    }
    public class NewsPreview
    { 
        public int? Id { get; set; }
        public string Header { get; set; }
        public NewsType Type { get; set; }
        public DateTime DatePublish { get; set; }
        public string? Text { get; set; }
        public string? Image { get; set; }
    }
}
