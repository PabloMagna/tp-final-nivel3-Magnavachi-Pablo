using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace dominio
{
    public class Items
    {

        public int Id { get; set; }
        [DisplayName("Item Code")]
        public string ItemCode { get; set; }
        [DisplayName("Item")]
        public string Name { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        public string UrlImage { get; set; }
        [DisplayName("Price")]
        public decimal Price { get; set; }
        [DisplayName("Brand")]
        public Trademarks TradeDesciption { get; set; }
        [DisplayName("Category")]
        public Category CategoryDescription { get; set; }
    }
}
