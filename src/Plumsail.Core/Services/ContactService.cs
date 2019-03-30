using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Plumsail.Core.Models;
using Plumsail.Core.Repositories;

namespace Plumsail.Core.Services
{
    public class ContactService : IContactService
    {
        private readonly Context context;
        public ContactService(Context context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Contact>> GetContactsAsync()
        {
            return await context.Contacts.ToListAsync();
        }

        public async Task<Contact> AddAsync(Contact contact)
        {
            //Todo: 
            var addedContact = await context.Contacts.AddAsync(contact);

            await context.SaveChangesAsync();

            return addedContact.Entity;
        }
    }
}
