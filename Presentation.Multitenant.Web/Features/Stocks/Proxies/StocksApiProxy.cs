using Ingress.Core.Attributes;
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
        public Task<IEnumerable<StockProxyDto>> Get()
        {
            var result = new List<StockProxyDto> {
                new StockProxyDto
                {
                    Id = "SSE-AD-5941977",
                    DetailsUrl = "/cars/details/Audi-A3-2016/SSE-AD-5941977",
                    Odometer = 39068,
                    Price = 29000,
                    PhotoUrl = "/cars/private/5m97pd57whxu6l7ogb6bobhi6.jpg",
                    Title = "2016 Audi A3 Attraction Auto MY16"
                },
                new StockProxyDto
                {
                    Id = "OAG-AD-16906787",
                    DetailsUrl = "/cars/details/Volkswagen-Tiguan-2017/OAG-AD-16906787",
                    Odometer = 46276,
                    Price = 27990,
                    PhotoUrl = "/car/dealer/4r92m171i9xipgmzj6w2e5coa.jpg",
                    Title = "2017 Volkswagen Tiguan 110TSI Trendline 5N Auto 2WD MY17"
                }
            };

            return Task.FromResult(result as IEnumerable<StockProxyDto>);
        }
    }
}
