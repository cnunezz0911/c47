using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using C47Example.Models.Request;
using C47Example.Services;
using C47Example.Models.Domain;
using System.Collections.Generic;

namespace C47Example.UnitTests
{
    [TestClass]
    public class PeopleTest
    {
        [TestMethod]
        public void Insert_Test()
        {
            PeopleAddRequest model = new PeopleAddRequest
            {
                FirstName = "Ronald",
                MiddleInitial = 'J',
                LastName = "McDonald",
                DOB = DateTime.Now.AddYears(-30),
                ModifiedBy = "Me"
            };
            PeopleService svc = new PeopleService();
            int result = svc.Insert(model);

            Assert.IsTrue(result > 0, "The insert Failed!");
        }

        [TestMethod]
        public void SelectAll_Test()
        {
            PeopleService svc = new PeopleService();
            List<People> result = svc.GetAll();

            Assert.IsTrue(result.Count > 0, "Select All has failed");
        }
    }
}
