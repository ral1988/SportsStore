using System.Linq;

namespace SportsStore.Models
{
    public class IProductRepository
    {
        private IQueryable<Product> Products { get; }
    }
}