using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ProductDatabase.Entity;
using ProductDatabase.Interfaces;
using Services.Interfaces;
using Services.ViewModels;

namespace Services.Services
{
    public class ProductService : IProductInterface
    {
        private IReposInterface<Product> repos;
        MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductViewModel>());
        private Mapper mapper;

        public ProductService(IReposInterface<Product> rep)
        {
            repos = rep;
            mapper = new Mapper(config);
        }


        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            var users = mapper.Map<List<ProductViewModel>>(repos.Get());
            return users;
        }

        public IEnumerable<ProductViewModel> GetProductsByCategory(string category)
        {
            var users = mapper.Map<List<ProductViewModel>>(repos.Get());
            if (category != "")
                return users.Where(x => x.Category.ToUpper() == category.ToUpper()).ToList();
            else return users;
        }

        public void AddProduct(ProductViewModel product)
        {
            repos.Add(new Product() { Category = product.Category, Name = product.Name });
        }
    }
}
