using CIP.Base;
using CIP.Models;
using Microsoft.EntityFrameworkCore;

namespace CIP.Repository
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository()
        {
        }

        public CustomerRepository(CipContext context) => _context = context;
    }
}
