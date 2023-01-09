using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProyect_MaxiPrograma_LVL3.dominio;
using negocio;

namespace FinalProyect_MaxiPrograma_LVL3.negocio
{
    public class ShoppKartNegocio
    {
        public void add(ShoppKart kart)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.settingQuery("insert into Favorites (IdUser,IdItem,Quantity) values (@user,@item,@quantity)");
                data.settingParametter("@user", kart.IdUser);
                data.settingParametter("@item", kart.IdItem);
                data.settingParametter("@quantity", kart.Quantity);
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