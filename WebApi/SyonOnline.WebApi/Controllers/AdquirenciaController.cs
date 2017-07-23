using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SyonOnline.WebApi.SyonOnline.WebApi.Model;
using SyonOnline.WebApi.SyonOnline.WebApi.Moq.Adquirencia;
using SyonOnline.ServiceReference.Adquirencia;
using System.Collections.Concurrent;

namespace SyonOnline.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AdquirenciaController : Controller
    {

        // GET api/values/password
        [HttpGet("{password}")]
        public Task<List<ValidationResult>> ValidateFull(string password)
        {
            var moq = new AdquirenciaInfo();
            var moqValues = moq.GetCollection();
            var service = new KomerciWcfClient();
            var resultCollection = new ConcurrentBag<ValidationResult>();
            var result = new List<ValidationResult>();

            return Task.Run(() =>
            {
                Parallel.ForEach(moqValues, x => {
                    var r = CallGetAuthorizedCreditAsync(service, x);
                    result.Add(r);
                });
                
                return result;
            });
        }

        private ValidationResult CallGetAuthorizedCreditAsync(KomerciWcfClient service, AdquirenciaInfo item)
        {
            var validationResult = new ValidationResult();
            var msg = string.Empty;
            var wsResult = service.GetAuthorizedCreditAsync(item.Request);

            wsResult.Wait();

            validationResult.TimeFinish = DateTime.Now;

            validationResult.IsPass = item.EqualsResult(wsResult.Result,out msg);
            validationResult.Message = msg;

            return validationResult;
        }
    }
}
