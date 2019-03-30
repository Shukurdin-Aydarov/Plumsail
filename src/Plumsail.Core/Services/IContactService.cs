using System.Collections.Generic;
using System.Threading.Tasks;

using Plumsail.Core.Models;

namespace Plumsail.Core.Services
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetContactsAsync();
        Task<Contact> AddAsync(Contact contact);
    }
}
