using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestorHelperWebApp.Models
{
    public class Stock
    {
        public string StockSymbol { get; set; }
        public decimal StockPrice { get; set; }
        public decimal StockHoldings { get; set; }
    }
}
