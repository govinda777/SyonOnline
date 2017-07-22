using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SyonOnline.WebApi.SyonOnline.WebApi.Model;
using SyonOnline.WebApi.SyonOnline.WebApi.Moq.Adquirencia;
using SyonOnline.ServiceReference.Adquirencia;

namespace SyonOnline.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AdquirenciaController : Controller
    {

        // GET api/values/password
        [HttpGet("{password}")]
        public async Task<List<ValidationResult>> ValidateFull(string password)
        {
            var moq = new AdquirenciaInfo();
            var service = new KomerciWcfClient();
            var result = new List<ValidationResult>();

            Parallel.ForEach(moq.GetCollection(), async x => {
                result.Add(await CallGetAuthorizedCreditAsync(service, x));
            });

            return result;

        }

        private async Task<ValidationResult> CallGetAuthorizedCreditAsync(KomerciWcfClient service, AdquirenciaInfo item)
        {
            var result = await service.GetAuthorizedCreditAsync(item.Request);

            item.EqualsResult(result);

            return new ValidationResult();
        }
    }
}
