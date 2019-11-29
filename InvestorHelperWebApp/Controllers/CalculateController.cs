using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvestorHelperWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace InvestorHelperWebApp.Controllers
{
    public class CalculateController : Controller
    {
        public IActionResult Index(StockHoldingsVM vm)
        {
            vm.Holdings = new List<Stock>();
            for (int i = 0; i < vm.NumOfStocks; i++)
            {
                vm.Holdings.Add(new Stock());
            }
            return View("Index",vm);
        }

        public IActionResult CalculateInvestment(StockHoldingsVM vm)
        {
            InvestmentResult investResult = new InvestmentResult(vm.Holdings, vm.ContributionAmount);
            return View(investResult);
        }
    }
}