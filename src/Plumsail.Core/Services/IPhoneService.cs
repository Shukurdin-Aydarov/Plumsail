using System.Collections.Generic;
using System.Threading.Tasks;

using Plumsail.Core.Models;

namespace Plumsail.Core.Services
{
    public interface IPhoneService
    {
        Task<IEnumerable<Phone>> GetAsync(string title);
        Task<Phone> AddAsync(Phone phone);
    }
}
