using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Trademarks
    {
        public int TradeId { get; set; }
        public string TradeDescription { get; set; }

        public override string ToString()
        {
            return TradeDescription;
        }
    }
}
