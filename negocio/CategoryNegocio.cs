using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class CategoryNegocio
    {
        public List<Category> listar()
        {
            List<Category> newList = new List<Category>();
            DataAccess data = new DataAccess();
            try
            {
                data.settingQuery("select id, descripcion from categorias");
                data.executeQuery();

                while(data.Reader.Read())
                {
                    Category aux = new Category();
                    aux.CategoryId = (int)data.Reader["id"];
                    aux.CategoryDescription = (string)data.Reader["descripcion"];

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
