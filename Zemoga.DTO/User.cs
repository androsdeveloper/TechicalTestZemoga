using System;
using System.Collections.Generic;
using System.Text;

namespace Zemoga.DTO
{
    public class User
    {
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string NameUser { get; set; }
        public string PasswordUser { get; set; }
        public int? IdRole { get; set; }
    }
}
