using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BackboneDL;
using System.Net;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Routing;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using Backbone_Testing.Controllers;
using System.Web.Http.Results;

namespace Backbone_Testing.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void UpdateEmployeeTest()
        {
            
            var controller = new EmployeeController();
            Employee employee = new Employee { Id = 1606, Name = "Demo1", KnownAs = "Demo1", Surname = "Demo1", Position = "Demo1", ContactNumber = "Demo1" };

            int Result = controller.Put(1606, employee);            
            Assert.IsNotNull(Result);            
        }

        [TestMethod]
        public void GetAllEmployees_ShouldReturnAllEmployees()
        {
            System.Collections.Generic.List<Employee> testEmployees = GetTestEmployees();
            var controller = new Controllers.EmployeeController();

            System.Collections.Generic.List<Employee> result = controller.Get() as System.Collections.Generic.List<Employee>;
            Assert.AreNotSame(testEmployees[0], result[1]);
        }

        [TestMethod]
        public void GetEmployeFound()
        {
            // Set up Prerequisites   
            var controller = new EmployeeController();
            // Act  
            Employee employee = controller.Get(1606);
            // Assert  
            Assert.IsNotNull(employee);
        }

        [TestMethod]
        public void GetAllEmployees_ShouldReturnEmployee()
        {
            System.Collections.Generic.List<Employee> testEmployees = GetTestEmployees();
            var controller = new Controllers.EmployeeController();

            System.Collections.Generic.List<Employee> result = controller.Get();
            
            Assert.AreNotEqual(testEmployees[1], result[0]);
        }

        [TestMethod]
        public void AddEmployee()
        {
            var controller = new Controllers.EmployeeController();
            var employee = new Employee { Id = 1, Name = "Demo1", KnownAs = "Demo1", Surname = "Demo1", Position = "Demo1", ContactNumber = "Demo1" };
            Employee newEmployee = controller.Post(employee);
            Employee emp = new Employee();
            Assert.AreNotSame(emp, newEmployee);
        }

        [TestMethod]
        private System.Collections.Generic.List<Employee> GetTestEmployees()
        {
            var testEmployees = new System.Collections.Generic.List<Employee>();
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
            testEmployees.Add(new Employee
            {
                Id = 3,
                Name = "Demo3",
                KnownAs = "Demo3",
                Surname = "Demo3",
                Position = "Demo3",
                ContactNumber = "Demo3"
            });
            testEmployees.Add(new Employee
            {
                Id = 4,
                Name = "Demo4",
                KnownAs = "Demo4",
                Surname = "Demo4",
                Position = "Demo4",
                ContactNumber = "Demo4"
            });

            return testEmployees as System.Collections.Generic.List<Employee>;
        }
    }
}
