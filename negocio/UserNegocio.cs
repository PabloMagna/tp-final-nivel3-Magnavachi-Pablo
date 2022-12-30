using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dominio;
using FinalProyect_MaxiPrograma_LVL3.dominio;
using negocio;

namespace FinalProyect_MaxiPrograma_LVL3.negocio
{
    public class UserNegocio
    {
        public bool login(UserClass user)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.settingQuery("select id,UserType from Usuarios where @user = UserName and @pass = Password and active = 1");
                data.settingParametter("@user", user.UserName);
                data.settingParametter("@pass", user.Password);

                data.executeQuery();
                while (data.Reader.Read())
                {
                    user.Id = (int)data.Reader["id"];
                    user.TypeUser = (int)data.Reader["UserType"] == 2 ? typeUser.Admin : typeUser.User;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                data.closeConnection();
            }
        }
    }
}