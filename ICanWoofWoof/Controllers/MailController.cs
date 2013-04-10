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
using ICanWoofWoof.CustomResults;
using Newtonsoft.Json;

namespace ICanWoofWoof.Controllers
{
    public class MailController : Controller
    {
        private readonly IDataBaseContext _dbContext = new DataBaseContextMock();

        public JsonResult Get(Mail.Folders folder)
        {
            return new JsonNetResult(_dbContext.MailData.GetMails(folder));
        }

        public JsonResult GetMail(int id)
        {
            return Json(_dbContext.MailData.GetMails(id), JsonRequestBehavior.AllowGet);
        }
    }
}
