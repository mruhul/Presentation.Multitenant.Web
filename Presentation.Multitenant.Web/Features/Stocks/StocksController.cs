using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Presentation.Multitenant.Web.Features.Stocks
{
    public class StocksController : Controller
    {
        private readonly StocksRequestHandler _requestHandler;

        public StocksController(StocksRequestHandler requestHandler)
        {
            _requestHandler = requestHandler;
        }

        public async Task<IActionResult> Index(StocksRequest request)
        {
            var vm = await _requestHandler.Handle(request);

            if (vm == null) return NotFound();

            return View("~/Features/Stocks/Views/Index.cshtml", vm);
        }
    }
}
