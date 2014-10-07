using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Axosoft.Core.Services;
using System.Diagnostics;

namespace Axosoft.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async void TestMethod1()
        {

            var auth = await Auth.Instance.GetTokenAsync("mintek.axosoft.com", "kevinw@software-logistics.com", "Spooked4283");
            Debug.WriteLine(auth);

        }
    }
}
