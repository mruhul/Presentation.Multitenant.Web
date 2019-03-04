using System.Threading.Tasks;

namespace Presentation.Multitenant.Web.Features.Stocks
{
    public interface IStockListViewModelProvider
    {
        Task<StockListViewModel> Get(StocksRequest request);
        string[] SupportedTenants { get; }
    }
}
