using ParkStroiteleyMVC.Models.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkStroiteleyMVC.Models.ObjectDTO
{
    public class BlockDTO
    {
        public int Id { get; set; }
        public BlockType Type { get; set; }          // Тип блока
        public string Text { get; set; }             // Просто текст
        public string ImageURL { get; set; }         // Путь к картинке
        public ImageSizeType ImageSize { get; set; } // Размер картинки
        public string ImageAbout { get; set; }       // Подпись к картинке
        public string VideoLink { get; set; }        // Сылка на встраиваемое видео
        public DateTime DateAdd { get; set; }        // Дата добавления
    }
}
