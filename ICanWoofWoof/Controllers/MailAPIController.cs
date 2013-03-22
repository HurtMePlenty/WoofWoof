using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using DAL;
using DALTypes;


namespace ICanWoofWoof.Controllers
{
    public class MailAPIController : ApiController
    {
        private readonly IDataBaseContext _dbContext = new DataBaseContextMock();

        //GET api/mailapi/inbox
        public IEnumerable<Mail> Get(Mail.Folders folder)
        {
            return _dbContext.MailData.GetMails(folder);
        }

        // POST api/mailapi
        public void Post([FromBody]string value)
        {
        }

        // PUT api/mailapi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/mailapi/5
        public void Delete(int id)
        {
        }
    }
}
