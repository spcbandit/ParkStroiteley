using ParkStroiteleyMVC.Models.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkStroiteleyMVC.Models.ObjectDTO
{
    public class GalleryDTO
    {
        public int Id { get; set; }
        public string NameFile { get; set; }
        public string AboutFile { get; set; }
        public ImageGalleryType Type { get; set; }
        public ImageSizeType Size { get; set; }
        public DateTime DateAdd { get; set; }
    }
}
