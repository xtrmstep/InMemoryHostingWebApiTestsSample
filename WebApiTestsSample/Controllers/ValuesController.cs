using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiTestsSample.Models;

namespace WebApiTestsSample.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IHttpActionResult Get()
        {
            using (var db = new ApiDataContext())
            {
                var l = db.Items.ToList();
                return Ok(l);
            }
        }

        // GET api/values/5
        public IHttpActionResult Get(int id)
        {
            return Ok("value");
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}