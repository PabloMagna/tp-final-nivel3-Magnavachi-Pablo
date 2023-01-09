using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProyect_MaxiPrograma_LVL3.dominio
{
    public class ShoppKart
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdItem { get; set; }
        public int Quantity { get; set; }
        
        public ShoppKart(int user, int item, int quantity)
        {
            IdUser = user;
            IdItem = item;
            Quantity = quantity;
        }
        
    }
}