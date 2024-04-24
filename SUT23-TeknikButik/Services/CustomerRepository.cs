using Microsoft.EntityFrameworkCore;
using SUT23_TeknikButik.Data;
using SUT23_TeknikButikModels;

namespace SUT23_TeknikButik.Services
{
    public class CustomerRepository : ICustomer
    {
        private AppDbContext _appDbContext;
        public CustomerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
          return  await _appDbContext.Customers.ToListAsync();

        }
        public async Task<Customer> GetSingelCustomer(int id)
        {
            return await _appDbContext.Customers.
                FirstOrDefaultAsync(c => c.CustomerId == id);
        }

        public async Task<IEnumerable<Customer>> Search(string name)
        {
            IQueryable<Customer> qury = _appDbContext.Customers;
            if (!string.IsNullOrEmpty(name))
            {
                qury = qury.Where(c => c.FirstName.Contains(name) 
                || c.LastName.Contains(name));
            }
            return await  qury.ToListAsync();
        }
    }
}
