using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestorHelperWebApp.Models
{
    public class StockHoldingsVM
    {
        public int NumOfStocks { get; set; } = 0;
        public decimal ContributionAmount { get; set; }
        
        public List<Stock> Holdings { get; set; }
    }
}
