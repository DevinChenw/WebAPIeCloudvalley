using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPIeCloudvalley;
using WebAPIeCloudvalley.Controllers;

namespace WebAPIeCloudvalley.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // 排列
            ValuesController controller = new ValuesController();

            // 作用
            IEnumerable<string> result = controller.Get();

            // 判斷提示
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }

        [TestMethod]
        public void GetById()
        {
            // 排列
            ValuesController controller = new ValuesController();

            // 作用
            string result = controller.Get(5);

            // 判斷提示
            Assert.AreEqual("value", result);
        }

        [TestMethod]
        public void Post()
        {
            // 排列
            ValuesController controller = new ValuesController();

            // 作用
            controller.Post("value");

            // 判斷提示
        }

        [TestMethod]
        public void Put()
        {
            // 排列
            ValuesController controller = new ValuesController();

            // 作用
            controller.Put(5, "value");

            // 判斷提示
        }

        [TestMethod]
        public void Delete()
        {
            // 排列
            ValuesController controller = new ValuesController();

            // 作用
            controller.Delete(5);

            // 判斷提示
        }

        [TestMethod()]
        public void GetProductTotalUsageAmountByIdTEST()
        {
            ValuesController controller = new ValuesController();
            var result = controller.GetProductTotalUsageAmount("order1", 1, 10);

            var isOk = false;
            if (result.IsSuccess)
            {
                isOk = true;
            }

            Assert.IsTrue(isOk);
        }

        [TestMethod()]
        public void GetProductGroupDateTotalUsageAmountTEST()
        {
            ValuesController controller = new ValuesController();
            var result = controller.GetProductGroupDateTotalUsageAmount("order2", 1, 10);

            var isOk = false;
            if (result.IsSuccess)
            {
                isOk = true;
            }

            Assert.IsTrue(isOk);
        }
    }
}
