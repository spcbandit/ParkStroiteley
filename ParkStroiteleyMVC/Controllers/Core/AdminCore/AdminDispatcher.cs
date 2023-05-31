using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using ParkStroiteleyMVC.Controllers.Core.Interface;
using ParkStroiteleyMVC.Models.ModelPages;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkStroiteleyMVC.Controllers.Core.AdminCore
{
    public class AdminDispatcher : IAdminDispatcher
    {
        #region [IAdminDispatcher]
        public IndexModel Index { get { return CreateIndex(); } }
        #endregion
        private Action<string> Logs => Startup.Logs;
        private AdminDigger Digger;
        public AdminDispatcher()
        {
            Digger.Connect();
        }

        #region [Helpers]
        private IndexModel CreateIndex()
        {
            IndexModel model = new IndexModel(
                "ПАРК СТРОИТЕЛЕЙ",
                "Одно из лучших мест времяпрепровождения в г.Орске",
                Digger.GetContacts() ?? new Models.ObjectDTO.ContactsDTO() { PhoneNumber = "+7000000" } );
            try
            {
                //IndexModel
            }
            catch (Exception ex)
            {
                Logs.Invoke($"~~MethodeDispatcher: CreateIndex {Environment.NewLine}{ex.Message}");
            }
            return model;
        }
        #endregion
    }
}
