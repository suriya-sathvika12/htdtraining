using System.Collections.Generic;
using System.Threading.Tasks;
using ContactApp.Models;

namespace ContactApp.Repositories
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAllAsync();
        Task CreateAsync(Contact contact);
        Task DeleteAsync(long id);
    }
}