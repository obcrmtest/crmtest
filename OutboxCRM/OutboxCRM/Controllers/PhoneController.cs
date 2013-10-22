using OutboxCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OutboxCRM.Controllers
{
    public class PhoneController : ApiController
    {
        
        // GET api/phone
        public IEnumerable<Phone> Get()
        {
            throw new Exception("Metoda niedostępna");
        }

        // GET api/phone/5
        public IEnumerable<Phone> Get(string id)
        {
            List<Phone> phones = AccountPhone.GetAccountPhones(id);
            return phones;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}