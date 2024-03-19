using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestorHelperWebApp.Models
{
    public class InvestmentResult
    {
        public List<IndividualInvestmentResult> InvestmentResults { get; private set; }
        private List<Stock> stocks;
        private decimal contributionAmount;
        private decimal maxHolding;

        public InvestmentResult(List<Stock> stocks, decimal contributionAmount)
        {
            this.stocks = stocks;
            this.contributionAmount = contributionAmount;
            InvestmentResults = calculateInvestmentResults();
        }

        private List<IndividualInvestmentResult> calculateInvestmentResults()
        {
            var investmentResults = new List<IndividualInvestmentResult>();
            maxHolding = findHighestStockHolding();

            var initialStocksLength = stocks.Count;
            for (int i = 0; i < initialStocksLength; i++)
            {
                var smallestHolding = findLowestStock();
                if (smallestHolding.StockPrice == 0) // find out why the last value gets reset and nulled but leaves holdings amount
                {
                    return investmentResults;
                }
                decimal differenceBetweenMaxAndMin = maxHolding - smallestHolding.StockHoldings;
                int stockSharesToBuy = (int)(differenceBetweenMaxAndMin / smallestHolding.StockPrice); 

                if (stockSharesToBuy * smallestHolding.StockPrice > contributionAmount || stockSharesToBuy == 0)
                {
                    return investmentResults;
                }
                else
                {
                    IndividualInvestmentResult individualInvestmentResult = new IndividualInvestmentResult();
                    individualInvestmentResult.NumSharesToBuy = stockSharesToBuy;
                    individualInvestmentResult.StockSymbol = smallestHolding.StockSymbol;
                    investmentResults.Add(individualInvestmentResult);
                    stocks.Remove(smallestHolding);
                }
            }

            return investmentResults;
        }

        private decimal findHighestStockHolding()
        {
            decimal maxHolding = 0;

            foreach(Stock stock in stocks)
            {
                if (stock.StockHoldings > maxHolding)
                {
                    maxHolding = stock.StockHoldings;
                }
            }

            return maxHolding;
        }
        
        private Stock findLowestStock()
        {
            Stock minStockHolding = new Stock();
            minStockHolding.StockHoldings = maxHolding;
            foreach(Stock stock in stocks)
            {
                if (stock.StockHoldings < minStockHolding.StockHoldings)
                {
                    minStockHolding = stock;
                }
            }
            return minStockHolding;
        }
    }
}
