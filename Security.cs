using FinalProyect_MaxiPrograma_LVL3.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProyect_MaxiPrograma_LVL3
{
    public static class Security
    {
        public static bool isLogged(Object user)
        {
            UserClass userConected = user != null ? (UserClass)user : null;
            if (userConected != null && userConected.Id != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool isAdmin(object user)
        {
            UserClass userClass = (UserClass)user;
            if(userClass.TypeUser == typeUser.Admin)
            {
                return true;
            }
            return false;
        }
    }
}