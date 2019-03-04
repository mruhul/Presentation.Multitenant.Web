using Ingress.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Multitenant.Web.Features.Stocks.Providers
{
    public class StaticDataSettings
    {
        public string Heading { get; set; }
        public string Slogan { get; set; }
    }

    [AutoBind]
    public class StaticDataSettingsProvider : Ingress.Tenancy.Abstracts.ITenantConfigProvider<StaticDataSettings>
    {
        public IDictionary<string, StaticDataSettings> Get()
        {
            return new Dictionary<string, StaticDataSettings>
            {
                {
                    "carsales",
                    new StaticDataSettings
                    {
                        Heading = "Carsales",
                        Slogan = "Carsales | Australia's No.1 Car Website - carsales.com.au"
                    }
                },
                {
                    "bikesales",
                    new StaticDataSettings
                    {
                        Heading = "Bikesales",
                        Slogan = "Bikesales | Australia's No.1 Bike Website - bikesales.com.au"
                    }
                },
                {
                    "soloautos",
                    new StaticDataSettings
                    {
                        Heading = "Soloautos",
                        Slogan = "Soloautos | Newly Used Cars and New Vehicles - soloautos.mx"
                    }
                }
            };
        }
    }
}
