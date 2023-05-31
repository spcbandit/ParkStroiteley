using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkStroiteleyMVC.Controllers.Core.Interface
{
    interface IDigger : IDisposable
    {
        public bool IsDispose { get; }
        public void Save();
        public void Connect();
    }
}
