using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BackboneDL;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Threading.Tasks;

namespace Backbone_Testing.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeeController : ApiController
    {
        EmployeeOperations empOperations = new EmployeeOperations();

        // GET: api/Employee
        public List<Employee> Get()
        {
            EmployeeOperations empOperations = new EmployeeOperations();

            List<Employee> emp = empOperations.GetEmployees();

            return emp;
        }

        public Employee Get(int id)
        {
            Employee emp = empOperations.GetEmployee();

            return emp;
        }

        // POST: api/Employee
        [ResponseType(typeof(Employee))]
        [HttpPost]
        public Employee Post(Employee employee)
        {
           Employee results = new Employee();
            try
            {  
                results = empOperations.AddNewEmployee(employee);
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return results;
        }

        // PUT: api/Employee/5
        public int Put(int id, Employee employee )
        {
            int results = 0;
            try
            {
                results = empOperations.UpdatEmployee(employee);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return results;
        }

        // DELETE: api/Employee/5
        public int Delete(int id)
        {
            int results = 0;
            try
            {
                results = empOperations.DeleteEmployee((id));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return results;
        }
    }
    
}
