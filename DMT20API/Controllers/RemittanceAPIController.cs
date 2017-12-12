using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DMT20API.Models;
using System.Web.Script.Serialization;

namespace DMT20API.Controllers
{
    public class RemittanceAPIController : ApiController
    {
        // GET: api/RemittanceAPI
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/RemittanceAPI/5
        public string Get(int id)
        {
            return "value is " + Convert.ToString(id);
        }

      //  POST: api/RemittanceAPI
        //public string AddConsumer([FromBody]string value)
        //{
        //    return "Value returnded from : - " + value;
        //}

        // PUT: api/RemittanceAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/RemittanceAPI/5
        public void Delete(int id)
        {
        }

        public string  GetData(int id)
        {
            return "{\"value\":\"" + Convert.ToString(id) +"\"}";
        }

        [System.Web.Http.HttpPost]
        public string AddRemitUserData([FromBody]string id)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            Person[] persons = js.Deserialize<Person[]>(id);

            if (persons.Length >= 0)
                return Convert.ToString(id);
            else
                return "No Value is coming";
        }
    }
}
