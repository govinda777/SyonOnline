using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SyonOnline.ServiceReference.Adquirencia;
using Newtonsoft.Json;

namespace SyonOnline.WebApi.Moq.Adquirencia
{
    public class AdquirenciaInfo
    {
        private readonly string _fileName;

        public AdquirenciaInfo()
        {
            _fileName = @"Moq\Adquirencia\mockAdquirencia.json";
        }

        public AdquirenciaInfo(string fileName)
        {
            _fileName = fileName;
        }

        public AdquirenciaInfo(GetAuthorizedCredit request, CreditAuthorizationResponse result)
        {
            Request = request;
            Result = result;
        }

        public GetAuthorizedCredit Request;
        public CreditAuthorizationResponse Result;

        public List<AdquirenciaInfo> GetCollection()
        {   
            var json = System.IO.File.ReadAllText(_fileName);
            return JsonConvert.DeserializeObject<AdquirenciaInfo[]>(json).ToList();
        }

        public bool EqualsResult(object obj, out string message)
        {
            message = string.Empty;

            var resultWS = (CreditAuthorizationResponse)obj;
            
            var testPass = this.Result.CodRet == resultWS.CodRet;

            if(!testPass)
            {
                message = string.Format("CodRet | {0} == {1} , {2}", this.Result.CodRet, resultWS.CodRet, resultWS.Msgret);
            }

            return testPass;
        }
    }
}
