using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyOrderServices.Controllers
{
    public class ProductDetailsController : ApiController
    {
        // GET: api/ProductDetails
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ProductDetails/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ProductDetails
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ProductDetails/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ProductDetails/5
        public void Delete(int id)
        {
        }
    }
}
