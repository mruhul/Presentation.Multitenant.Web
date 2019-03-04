using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Presentation.Multitenant.Web.Features.Stocks
{
    public class StocksController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View("~/Features/Stocks/Views/Index.cshtml", new StockListViewModel());
        }
    }
}
