using System.Collections.Generic;
using System.Threading.Tasks;
using DataModels.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IService
    {
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order> GetOrderAsync(int id);
        Task<int> AddOrderAsync(Order order);
        Task<List<Pet>> GetPetsAsync();
        Task<Pet> GetPetAsync(int id);
        Task<int> AddPetAsync(Pet pet);
        Task<List<Product>> GetDiscontinuedProductsAsync();
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(int id);
        Task<int> AddProductAsync(Product product);
    }
}