using Ingress.Core.Attributes;
using Ingress.Tenancy.Abstracts;
using Presentation.Multitenant.Web.Features.Stocks.Proxies;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Multitenant.Web.Features.Stocks.Providers
{
    [AutoBind]
    public class StockListViewModelProvider : IStockListViewModelProvider
    {
        private readonly StocksApiProxy _proxy;
        private readonly ITenantConfig<StaticDataSettings> _staticDataSettings;
        private readonly ITenantConfig<ListingConfigSettings> _config;

        public StockListViewModelProvider(StocksApiProxy proxy, 
            ITenantConfig<StaticDataSettings> staticDataSettings,
            ITenantConfig<ListingConfigSettings> config)
        {
            _proxy = proxy;
            _staticDataSettings = staticDataSettings;
            _config = config;
        }

        public async Task<StockListViewModel> Get(StocksRequest request)
        {
            var data = await _proxy.Get();

            var result = new StockListViewModel();

            var config = _config.Current;

            result.Items = data?.Select(d => new StockViewModel {
                Odometer = $"{d.Odometer:N0} km",
                PhotoUrl = $"{config.ImageBaseUrl}/{d.PhotoUrl.TrimStart('/')}?pxc_method=crop&pxc_size=900%2c600",
                Price = $"{d.Price:C0}",
                DetailsUrl = $"{config.DetailsBaseUrl}/{d.DetailsUrl.TrimStart('/')}",
                Title = d.Title
            });

            var staticData = _staticDataSettings.Current;
            result.Heading = staticData.Heading;
            result.Slogan = staticData.Slogan;

            return result;
        }

        public string[] SupportedTenants => new string[] { }; // all
    }
}
