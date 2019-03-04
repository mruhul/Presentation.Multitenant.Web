using Bolt.Common.Extensions;
using Ingress.Core.Attributes;
using Ingress.Tenancy.Abstracts;
using Presentation.Multitenant.Web.Features.Stocks.Proxies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Multitenant.Web.Features.Stocks
{
    [AutoBindToSelf]
    public class StocksRequestHandler
    {
        private readonly IEnumerable<IStockListViewModelProvider> _providers;
        private readonly ITenantConfig _tenantConfig;

        public StocksRequestHandler(IEnumerable<IStockListViewModelProvider> providers, ITenantConfig tenantConfig)
        {
            _providers = providers;
            _tenantConfig = tenantConfig;
        }

        public async Task<StockListViewModel> Handle(StocksRequest request)
        {
            var tenant = _tenantConfig.Current.Name;

            var provider = _providers.FirstOrDefault(x => 
                                x.SupportedTenants == null 
                                || x.SupportedTenants.Length == 0
                                || x.SupportedTenants.Any(t => t.IsSame(tenant)));

            if (provider == null) return null;

            return await provider.Get(request);
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
