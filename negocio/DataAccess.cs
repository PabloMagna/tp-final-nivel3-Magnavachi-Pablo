using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using negocio;

namespace negocio
{
    public class DataAccess
    {
        private SqlConnection conection;
        private SqlCommand command;
        private SqlDataReader reader;

        public SqlDataReader Reader
        {
            get { return reader; }
        }
        public DataAccess ()
        {
            conection = new SqlConnection("server=.\\SQLEXPRESS; database = CATALOGO_DB; integrated security=true");
            command = new SqlCommand();
        }
        public void settingQuery(string query)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;
        }
        public void executeQuery()
        {
            command.Connection = conection;
            try
            {
                conection.Open();
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void executeAction()
        {
            command.Connection = conection;
            try
            {
                conection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void settingParametter(string name, object value)
        {
            command.Parameters.AddWithValue(name, value);
        }
        public void closeConnection()
        {
            if(reader!=null)
            {
                reader.Close();
            }
            conection.Close();
        }
        public void addItem(Items newItem)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.settingQuery("insert into ARTICULOS (Codigo, Nombre, Descripcion, ImagenUrl, Precio, IdMarca, IdCategoria) values (@code,@name,@desc,@url,@price,@idmark,@idcatergory)");
                data.settingParametter("@code",newItem.ItemCode);
                data.settingParametter("@name",newItem.Name);
                data.settingParametter("@desc",newItem.Description);
                data.settingParametter("@url",newItem.UrlImage);
                data.settingParametter("@price",newItem.Price);
                data.settingParametter("@idmark",newItem.TradeDesciption.TradeId);
                data.settingParametter("@idcategory",newItem.CategoryDescription.CategoryId);
                data.executeAction();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void setProcedure(string sp)
        {
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = sp;
        }

    }
}
