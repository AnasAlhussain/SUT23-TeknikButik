using SUT23_TeknikButikModels;

namespace SUT23_TeknikButik.Services
{
    public interface ICustomer
    {
       Task <IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetSingelCustomer(int id);

        Task<IEnumerable<Customer>> Search(string name);
    }
}
