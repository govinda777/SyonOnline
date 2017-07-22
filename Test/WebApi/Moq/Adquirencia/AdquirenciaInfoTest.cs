using System;
using System.Collections.Generic;
using System.Text;
using SyonOnline.WebApi.SyonOnline.WebApi.Moq.Adquirencia;
using Xunit;

namespace SyonOnline.Test.WebApi.Moq.Adquirencia
{
    public class AdquirenciaInfoTest
    {
        [Fact]
        public void GetCollection_SendPathJson_ReturnCollection()
        {
            //Arrange
            var pathJson = @"..\..\..\..\WebApi\SyonOnline.WebApi\Moq\Adquirencia\mockAdquirencia.json";
            var model = new AdquirenciaInfo(pathJson);

            //Act
            var result = model.GetCollection();

            //Assert
            Assert.True(result != null);
        }
    }
}
