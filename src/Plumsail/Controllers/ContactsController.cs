using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Plumsail.Core.Models;
using Plumsail.Core.Services;

namespace Plumsail.Controllers
{
    [Route("api/v1/[controller]")]
    public class ContactsController : Controller
    {
        private readonly IContactService contactService;
        public ContactsController(IContactService service)
        {
            contactService = service;
        }
        
        public async Task<IActionResult> GetContactsAsync()
        {
            var contacts = await contactService.GetContactsAsync();

            if (contacts.Count() == 0)
                return NoContent();

            return Json(contacts);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Contact contact)
        {
            var addedContact = await contactService.AddAsync(contact);

            return Json(addedContact);
        }
    }
}
