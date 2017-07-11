using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackboneDL;
using Backbone_Testing;
using Backbone_Testing.Controllers;

namespace Backbone_Testing.Tests
{
    [TestClass]
    public class TestEmployees
    {
        [TestMethod]
        public void GetAllEmployees_ShouldReturnAllEmployees()
        {
            var testEmployees = GetTestProducts();
            var controller = new EmployeeController();

            var result = controller.Get() as List<Employee>;
            Assert.AreEqual(testEmployees.Count, result.Count);
        }

        [TestMethod]
        private List<Employee> GetTestProducts()
        {
            var testEmployees = new List<Employee>();
            testEmployees.Add(new Employee { Id = 1, Name = "Demo1", KnownAs = "Demo1", Surname = "Demo1", Position = "Demo1", ContactNumber = "Demo1" });
            testEmployees.Add(new Employee
            {
                Id = 2,
                Name = "Demo2",
                KnownAs = "Demo2",
                Surname = "Demo2",
                Position = "Demo2",
                ContactNumber = "Demo2"
            });
            testEmployees.Add(new Employee { Id = 3, Name = "Demo3",
                KnownAs = "Demo3",
                Surname = "Demo3",
                Position = "Demo3",
                ContactNumber = "Demo3"
            });
            testEmployees.Add(new Employee { Id = 4, Name = "Demo4",
                KnownAs = "Demo4",
                Surname = "Demo4",
                Position = "Demo4",
                ContactNumber = "Demo4"
            });

            return testEmployees;
        }
    }
}
