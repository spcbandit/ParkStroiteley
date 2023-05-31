using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ParkStroiteleyMVC.Models.Enums
{
    public enum ImageGalleryType
    {
        [EnumMember(Value = "Все")]
        All,
        [EnumMember(Value = "Природа")]
        Nature,
        [EnumMember(Value = "Птицы")]
        Bird,
        [EnumMember(Value = "Пейзаж")]
        Landscape,
        [EnumMember(Value = "Спорт")]
        Sport,
        [EnumMember(Value = "Отдых")]
        Relax,
    }
}
