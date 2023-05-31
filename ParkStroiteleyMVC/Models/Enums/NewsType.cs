using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ParkStroiteleyMVC.Models.Enums
{
    public enum NewsType
    {
        [EnumMember(Value = "Важная")]
        Important,
        [EnumMember(Value = "Ежедневная")]
        Daily,
        [EnumMember(Value = "Недельная")]
        Weekly,
        [EnumMember(Value = "Мероприятие")]
        Event
    }
}
