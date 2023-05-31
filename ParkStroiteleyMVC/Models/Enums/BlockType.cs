using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ParkStroiteleyMVC.Models.Enums
{
    public enum BlockType
    {
        [EnumMember(Value = "Текст")]
        Text,
        [EnumMember(Value = "Изображение")]
        Image,
        [EnumMember(Value = "Видео")]
        Video
    }
}
