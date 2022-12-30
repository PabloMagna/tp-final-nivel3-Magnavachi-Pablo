using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProyect_MaxiPrograma_LVL3.dominio
{
    public enum typeUser
    {
        Admin = 1,
        User = 2
    }
    public class UserClass
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public typeUser TypeUser { get; set; }
        public bool Active { get; set; }
        public UserClass(string pass, string userName, bool type)
        {
            Password = pass;
            UserName = userName;
            Active = true;
            TypeUser = type ? typeUser.Admin : typeUser.User;
        }
    }
}