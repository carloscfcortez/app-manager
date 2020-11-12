using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AppManager.Application.Interfaces;
using AppManager.Application.Services;
using AppManager.Domain.Entities;
using AppManager.Domain.Interfaces.Services;
using Moq;
using Xunit;
namespace AppManager.UnitTests
{

    public class TreeTest
    {

        [Fact]
        public void ReturnTreeByFilterSpecies()
        {
            Mock<ITreeService> _mock = new Mock<ITreeService>();

            var obj = new List<Tree>();
            obj.Add(new Tree() { Id = 1 });

            _mock.Setup(x => x.FindAllWithIncludes("teste", "")).Returns(obj);
            var service = new TreeAppService(_mock.Object);
            var result = service.FindAllWithIncludes("teste", "");
            
            
            Assert.Equal(obj, result);
            Assert.IsType<List<Tree>>(result);

        }
    }
}
