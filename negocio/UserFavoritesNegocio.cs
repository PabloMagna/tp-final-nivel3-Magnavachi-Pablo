using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using dominio;
using System.Data.SqlClient;
using FinalProyect_MaxiPrograma_LVL3.dominio;
using System.Web.WebSockets;

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
        public List<int> toListFromIdUser(int idUser)
        {
            DataAccess data = new DataAccess();
            List<int> lista = new List<int>();
            data.settingQuery("Select idItem from UserFavorites where IdUser = @idUser");
            data.settingParametter("@idUser", idUser);
            data.executeQuery();

            while (data.Reader.Read())
            {
                int aux = (int)data.Reader["idItem"];
            }

            data.closeConnection();
            return lista;
        }

    }
}