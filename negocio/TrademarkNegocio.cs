using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class TrademarkNegocio
    {
        public List<Trademarks> listar()
        {
            List<Trademarks> newList = new List<Trademarks>();
            DataAccess data = new DataAccess();
            try
            {
                data.settingQuery("select id, descripcion from marcas");
                data.executeQuery();

                while(data.Reader.Read())
                {
                    Trademarks aux = new Trademarks();
                    aux.TradeId = (int)data.Reader["id"];
                    aux.TradeDescription = (string)data.Reader["descripcion"];

                    newList.Add(aux);
                }
                return newList;
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
