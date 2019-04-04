using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Plumsail.Core.Models;
using Plumsail.Core.Services;

namespace Plumsail.Controllers
{
    [Route("api/v1/[controller]")]
    public class PhonesController : Controller
    {
        private readonly IPhoneService phoneService;
        public PhonesController(IPhoneService service)
        {
            phoneService = service;
        }
        
        public async Task<IActionResult> GetAsync(string title)
        {
            var phones = await phoneService.GetAsync(title);

            if (phones.Count() == 0)
                return NoContent();

            return Json(phones);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]Phone phone)
        {
            var addedPhone = await phoneService.AddAsync(phone);

            return Json(addedPhone);
        }
    }
}
