using System.Collections.Generic;
using Services.ViewModels;

namespace Services.Interfaces
{
    public interface IProductInterface
    {
        IEnumerable<ProductViewModel> GetAllProducts();
        IEnumerable<ProductViewModel> GetProductsByCategory(string category);
        void AddProduct(ProductViewModel product);
    }
}
