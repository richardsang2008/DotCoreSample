using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModels.Entities;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Services
{
    public class EfRepository
    {
        #region public properties
        private readonly AppDbContext _context;
        #endregion

        #region constructor
        public EfRepository(AppDbContext context)
        {
            _context = context;
        }
        #endregion
        
        #region methods implementation 
        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<int> AddOrderAsync(Order order)
        {
            int rowsAffected;

            _context.Orders.Add(order);
            rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected;
        }
        public async Task<List<Pet>> GetPetsAsync()
        {
            return await _context.Pets.ToListAsync();
        }

        public async Task<Pet> GetPetAsync(int id)
        {
            return await _context.Pets.FindAsync(id);
        }

        public async Task<int> AddPetAsync(Pet pet)
        {
            int rowsAffected;

            _context.Pets.Add(pet);
            rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected;
        }
        public async Task<List<Product>> GetDiscontinuedProductsAsync()
        {
            return await _context.Products
                .Where(p => p.IsDiscontinued)
                .ToListAsync();
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<int> AddProductAsync(Product product)
        {
            int rowsAffected;

            _context.Products.Add(product);
            rowsAffected = await _context.SaveChangesAsync();

            return rowsAffected;
        }
        #endregion
        
        
        
    }
}