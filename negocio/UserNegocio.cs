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
                data.settingQuery("select id,UserType,UserName,UrlImage from Usuarios where @Email= Email and @pass = Pass and active = 1");
                data.settingParametter("@Email", user.Email);
                data.settingParametter("@pass", user.Password);

                data.executeQuery();
                while (data.Reader.Read())
                {
                    user.Id = (int)data.Reader["id"];
                    user.TypeUser = (int)data.Reader["UserType"] == 2 ? typeUser.Admin : typeUser.User;
                    user.UserName = (string)data.Reader["UserName"];
                    user.UrlImagen = (string)data.Reader["UrlImage"];
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
        public void register(UserClass user)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.settingQuery("insert into Usuarios (Email,Pass,UserType,UrlImage,UserName,active) values (@email,@pass,@type,@img,@user,1)");
                data.settingParametter("@email", user.Email);
                data.settingParametter("@pass", user.Password);
                data.settingParametter("@type", user.TypeUser == typeUser.Admin ? 2 : 1);
                data.settingParametter("@img", user.UrlImagen);
                data.settingParametter("@user", user.UserName);
                data.executeQuery();
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