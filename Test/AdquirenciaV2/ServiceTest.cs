using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using SyonOnline.ServiceReference.AdquirenciaV2;


namespace SyonOnline.Test.AdquirenciaV2
{
    public class ServiceTest
    {
        //[TestCaseSource(typeof(MockGetAuthorizedCredit), Constant.MOCK)]
        [Fact]
        public async void GetAuthorizedCredit_CallEmptyParameter_ReturnMessenge()
        {
            //Arrange

            ////Act
            var result = await new KomerciWcfClient().GetAuthorizedCreditAsync(new GetAuthorizedCredit());

            ////Assert
            Assert.True(result != null);
        }
    }
}
