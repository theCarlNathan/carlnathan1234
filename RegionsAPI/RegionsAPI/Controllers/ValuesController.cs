using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RegionsAPI.Controllers
{
    public class RegionController : ApiController
    {
        // GET api/values
        public IEnumerable<Region> Get()
        {
            //return new string[] { "Carl", "Nathan", "Mier" };

            List<Region> regions = File.ReadAllLines("D:\\SourceCodes\\cleverBit\\cleverbitTask\\RegionsAPI\\RegionsAPI\\regions.csv")
                                           .Select(v => Region.FromCsv(v))
                                           .ToList();
            return regions;

        }

        public IEnumerable<Employee> Get(string ID)
        {
            //return new string[] { "Carl", "Nathan", "Mier" };

            List<Region> regions = File.ReadAllLines("D:\\SourceCodes\\cleverBit\\cleverbitTask\\RegionsAPI\\RegionsAPI\\regions.csv")
                                           .Select(v => Region.FromCsv(v))
                                           .ToList();
            List<Employee> employees = File.ReadAllLines("D:\\SourceCodes\\cleverBit\\cleverbitTask\\RegionsAPI\\RegionsAPI\\employees.csv")
                                           .Select(v => Employee.FromCsv(v))
                                           .ToList();

            List<Employee> employeesToReturn = new List<Employee>();
            
            return getAllEmployees(ID, regions, employees);



            return employeesToReturn;
            //return regions.Where(x=>x.ID == ID);

        }

        private IEnumerable<Employee> getAllEmployees(string regionID,List<Region> regions, List<Employee> employees)
        {
            var employeesToReturn = new List<Employee>();
            foreach (var employee in employees.Where(x => x.Region == regionID).ToList())
            {
                employeesToReturn.Add(employee);
                //an extra step is to remove the employee from the list
                employees.Remove(employee);
            }

            return employeesToReturn;
            //throw new NotImplementedException();
        }

        // GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }

    public class Region
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string ParentID { get; set; }

        public static Region FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            Region region = new Region();

            region.Name = values[0];
            region.ID = values[1];
            region.ParentID = values[2];
            return region;
        }

    }

    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Region { get; set; }

        public static Employee FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            Employee employee = new Employee();

            employee.Region = values[0];
            employee.FirstName = values[1];
            employee.LastName = values[2];
            return employee;
           
        }

    }

}
