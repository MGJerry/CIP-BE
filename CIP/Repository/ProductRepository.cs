using CIP.Base;
using CIP.Models;
using Microsoft.EntityFrameworkCore;

namespace CIP.Repository
{
    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository()
        {
        }

        public ProductRepository(CipContext context) => _context = context;
    }
}
