using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using dominio;
using System.Data.SqlClient;

namespace FinalProyect_MaxiPrograma_LVL3
{
    public class UserFavoritesNegocio
    {
       public void add(int userId, int itemId)
        {
            DataAccess data = new DataAccess();
            data.settingQuery("insert into UserFavorites (IdUser, IdItem) values (@IdUser, @IdItem)");
            data.settingParametter("@IdUser", userId);
            data.settingParametter("@IdItem", itemId);
            data.executeAction();
        }
        public void delete(int userId, int itemId)
        {
            DataAccess data = new DataAccess();
            data.settingQuery("delete from UserFavorites where IdUser = @IdUser and IdItem = @IdItem");
            data.settingParametter("@IdUser", userId);
            data.settingParametter("@IdItem", itemId);
            data.executeAction();
        }
        public bool exists(int userId, int itemId)
        {
            DataAccess data = new DataAccess();
            data.settingQuery("select * from UserFavorites where IdUser = @IdUser and IdItem = @IdItem");
            data.settingParametter("@IdUser", userId);
            data.settingParametter("@IdItem", itemId);
            data.executeQuery();
            if (data.Reader.HasRows)
            {
                data.closeConnection();
                return true;
            }
            else
            {
                data.closeConnection();
                return false;
            }
        }


    }
}