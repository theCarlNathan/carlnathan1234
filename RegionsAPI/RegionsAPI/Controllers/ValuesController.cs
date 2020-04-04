using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RegionsAPI.Controllers
{
    public class ValuesController : ApiController
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

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

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

}
