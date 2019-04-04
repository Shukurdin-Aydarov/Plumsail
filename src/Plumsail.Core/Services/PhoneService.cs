using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Plumsail.Core.Models;
using Plumsail.Core.Repositories;

namespace Plumsail.Core.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly Context context;
        public PhoneService(Context context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Phone>> GetAsync(string title)
        {
            if (string.IsNullOrEmpty(title))
                return await context.Phones
                    .ToListAsync();

            return await context.Phones
                .Where(x => x.Title.Contains(title))
                .ToListAsync();
        }

        public async Task<Phone> AddAsync(Phone phone)
        {
            //Todo: 
            var entry = await context.Phones.AddAsync(phone);

            await context.SaveChangesAsync();

            return entry.Entity;
        }
    }
}
