using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkStroiteleyMVC.Models.ObjectDTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string HASH { get; set; }
        public string Token { get; set; }
        //Получать рассылку сайта
        public bool IsTakeEmailMessages { get; set; }
        public DateTime DateReg { get; set; }
        public DateTime LastAuth { get; set; }
        //Расширение класса (если будет нужно)
        public List<VoidParamDTO> VoidParams { get; set; }
    }
}
