using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace proyecto_program_6.Models
{
    public class OrdenesHistory
    {
        public int TX_NUMBER { get; set; }
        public DateTime ORDER_DATE { get; set; }
        public string STATUS { get; set; }
        public string ACTION { get; set; }
        public string SYMBOL { get; set; }
        public int QUANTITY { get; set; }
        public double PRICE { get; set; }

      
    }
}
