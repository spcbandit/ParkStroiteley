using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ParkStroiteleyMVC.Models.Enums
{
    public enum ImageSizeType
    {
        [EnumMember(Value = "none")]
        None,
        [EnumMember(Value = "large")]
        Large,
        [EnumMember(Value = "medium")]
        Medium,
        [EnumMember(Value = "small")]
        Small
    }
}
