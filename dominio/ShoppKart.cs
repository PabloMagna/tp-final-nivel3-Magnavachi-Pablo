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
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }

        public ShoppKart(int user, int item, string name, decimal price, int quantity)
        {
            IdUser = user;
            IdItem = item;
            Quantity = quantity;
            Name = name;
            Price = price;
            Total = price * quantity;
        }
        public ShoppKart(int user, int item, int quantity)
        {
            IdUser = user;
            IdItem = item;
            Quantity = quantity;
        }
        public ShoppKart()
        {
            
        }
        
    }
}