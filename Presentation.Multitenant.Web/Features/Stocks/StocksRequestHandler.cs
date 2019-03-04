using Ingress.Core.Attributes;
using Presentation.Multitenant.Web.Features.Stocks.Proxies;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Multitenant.Web.Features.Stocks
{
    [AutoBindToSelf]
    public class StocksRequestHandler
    {
        private readonly IEnumerable<IStockListViewModelProvider> _providers;

        public StocksRequestHandler(IEnumerable<IStockListViewModelProvider> providers)
        {
            _providers = providers;
        }

        public async Task<StockListViewModel> Handle(StocksRequest request)
        {
            throw new NotImplementedException();
        }
    }

    public class StocksRequest
    {
    }

    public class StockListViewModel
    {
        public string Heading { get; set; }
        public string Slogan { get; set; }
        public IEnumerable<StockViewModel> Items { get; set; }
    }

    public class StockViewModel
    {
        public string Title { get; set; }
        public string PhotoUrl { get; set; }
        public string Price { get; set; }
        public string Odometer { get; set; }
        public string DetailsUrl { get; set; }
    }
}
