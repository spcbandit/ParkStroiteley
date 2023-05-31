using Microsoft.AspNetCore.Mvc;

using ParkStroiteleyMVC.Models.ModelPages;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkStroiteleyMVC.Controllers.Core.Interface
{
    public interface IAdminDispatcher
    {
        public IndexModel Index { get; }
    }
}
