using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SyonOnline.ServiceReference.Adquirencia;
using Newtonsoft.Json;

namespace SyonOnline.WebApi.SyonOnline.WebApi.Moq.Adquirencia
{
    public class AdquirenciaInfo
    {
        private readonly string _fileName;

        public AdquirenciaInfo()
        {
            _fileName = "mockAdquirencia.json";
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

        public bool EqualsResult(object obj)
        {
            var resultWS = (CreditAuthorizationResponse)obj;

            var testPass = this.Result.CodRet == resultWS.CodRet;

            return testPass;
        }
    }
}
