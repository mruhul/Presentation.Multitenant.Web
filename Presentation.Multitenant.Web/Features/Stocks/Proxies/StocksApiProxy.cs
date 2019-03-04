using Ingress.Core.Attributes;
using Ingress.Tenancy.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Multitenant.Web.Features.Stocks.Proxies
{
    public class StockProxyDto
    {
        public string Id { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public int Odometer { get; set; }
        public string PhotoUrl { get; set; }
        public string DetailsUrl { get; set; }
    }

    [AutoBindToSelf]
    public class StocksApiProxy
    {
        private readonly ITenantConfig _tenantConfig;
        private Dictionary<string, IEnumerable<StockProxyDto>> _source = new Dictionary<string, IEnumerable<StockProxyDto>>
        {
            {
                "carsales",
                new List<StockProxyDto>
                {
                    new StockProxyDto
                    {
                        Id = "SSE-AD-5941977",
                        DetailsUrl = "/Audi-A3-2016/SSE-AD-5941977",
                        Odometer = 39068,
                        Price = 29000,
                        PhotoUrl = "/cars/private/5m97pd57whxu6l7ogb6bobhi6.jpg",
                        Title = "2016 Audi A3 Attraction Auto MY16"
                    },
                    new StockProxyDto
                    {
                        Id = "OAG-AD-16906787",
                        DetailsUrl = "/Volkswagen-Tiguan-2017/OAG-AD-16906787",
                        Odometer = 46276,
                        Price = 27990,
                        PhotoUrl = "/car/dealer/4r92m171i9xipgmzj6w2e5coa.jpg",
                        Title = "2017 Volkswagen Tiguan 110TSI Trendline 5N Auto 2WD MY17"
                    }
                }
            },
            {
                "bikesales",
                new List<StockProxyDto>
                {
                    new StockProxyDto
                    {
                        Id = "OAG-AD-15254494",
                        DetailsUrl = "/2018-harley-davidson-heritage-classic-107-flhc/OAG-AD-15254494/",
                        Odometer = 2250,
                        Price = 25990,
                        PhotoUrl = "/bike/dealer/rzhh6mibzr5ferl48cyu8.jpg",
                        Title = "2018 Harley-Davidson Heritage Classic 107 (FLHC)"
                    }
                }
            },
            {
                "soloautos",
                new List<StockProxyDto>
                {
                    new StockProxyDto
                    {
                        Id = "SA-AD-89163077",
                        DetailsUrl = "/2017-BMW-Serie-3-Sedán-330iA-Luxury-Line/SA-AD-89163077",
                        Odometer = 27000,
                        Price = 519000,
                        PhotoUrl = "/car/private/owzzaaac4ifkdrv2bu7y37no7.jpg",
                        Title = "2017 BMW Serie 3 Sedán 330iA Luxury Line"
                    },
                    new StockProxyDto
                    {
                        Id = "SA-AD-89163083",
                        DetailsUrl = "/2013-BMW-X6-X6M/SA-AD-89163083",
                        Odometer = 54856,
                        Price = 629000,
                        PhotoUrl = "/car/private/nc3zpiz6w93wxs562qe3w1rme.jpg",
                        Title = "2013 BMW X6 X6M"
                    }
                }
            }
        };

        public StocksApiProxy(ITenantConfig tenantConfig)
        {
            _tenantConfig = tenantConfig;
        }

        public Task<IEnumerable<StockProxyDto>> Get()
        {
            return Task.FromResult(
                (_source.TryGetValue(_tenantConfig.Current.Name, out var result) 
                ? result 
                : Enumerable.Empty<StockProxyDto>()) as IEnumerable<StockProxyDto>);
        }
    }
}
