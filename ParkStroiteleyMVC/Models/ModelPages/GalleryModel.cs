using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkStroiteleyMVC.Models.ModelPages
{
    public class GalleryModel
    {
        public Models.Enums.ImageGalleryType Type { get; set; }
        public List<Models.ObjectDTO.GalleryDTO> Imgs { get; set; }
    }
}
