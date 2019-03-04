using Ingress.Core;

namespace Presentation.Multitenant.Web.Features.Stocks.Providers
{
    [ConfigSectionName("Ingress:Tenancy:ListingConfigSettings")]
    public class ListingConfigSettings
    {
        public string DetailsBaseUrl { get; set; }
        public string ImageBaseUrl { get; set; }
    }
}
