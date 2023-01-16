using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dominio;
using FinalProyect_MaxiPrograma_LVL3.dominio;
using negocio;
using System.Data.SqlClient;

namespace FinalProyect_MaxiPrograma_LVL3.negocio
{
    public class ShoppKartNegocio
    {
        public void add(ShoppKart kart)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.settingQuery("insert into ShopKart (IdUser,IdItem,Quantity, Price, Name) values (@user,@item,@quantity, (select Precio from ARTICULOS where Id = @item), (select Nombre from ARTICULOS where Id = @item))");
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
        public List<ShoppKart> toListWithId(int idUser)
        {
            List<ShoppKart> list = new List<ShoppKart>();
            DataAccess data = new DataAccess();
            try
            {
                data.settingQuery("select id, idUser, idItem, name, quantity, price from ShopKart where IdUser = @user");
                data.settingParametter("@user", idUser);
                data.executeQuery();
                while (data.Reader.Read())
                {
                    ShoppKart aux = new ShoppKart();
                    aux.Id = (int)data.Reader["Id"];
                    aux.IdUser = (int)data.Reader["IdUser"];
                    aux.IdItem = (int)data.Reader["IdItem"];
                    aux.Quantity = (int)data.Reader["Quantity"];
                    aux.Name = (string)data.Reader["Name"];
                    aux.Price = (decimal)data.Reader["Price"];
                    aux.Total = aux.Price * aux.Quantity;
                    list.Add(aux);
                }
                return list;
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
        public void deleteQuantity(int id, int quantity)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.settingQuery("update ShopKart set Quantity = Quantity - @quantity where Id=@id");
                data.settingParametter("@id", id);
                data.settingParametter("@quantity", quantity);
                data.executeQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.closeConnection();
            }
        }
    }
}