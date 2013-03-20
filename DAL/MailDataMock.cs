using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALTypes;

namespace DAL
{
    public class MailDataMock: IMailData
    {
        public MailDataMock()
        {
            Initialize();
        }

        private IList<Mail> mails;
        public IList<Mail> Mails { get { return mails; } }

        private void Initialize()
        {
            mails = new List<Mail>();
            mails.Add(new Mail()
                          {
                              From = "Test@test.test",
                              To = "WoofWoof@woof.woof",
                              Date = DateTime.Now - new TimeSpan(1),
                              Subject = "Subject 1",
                              Body = "Body1",
                              IsArchive = false,
                              IsSentByMe = false,
                              IsSpam = false
                          });

            mails.Add(new Mail()
                          {
                              From = "Test@test.test",
                              To = "WoofWoof@woof.woof",
                              Date = DateTime.Now - new TimeSpan(1),
                              Subject = "Fcken spam",
                              Body = "spam spam spam",
                              IsArchive = false,
                              IsSentByMe = false,
                              IsSpam = true
                          });

            mails.Add(new Mail()
                          {
                              From = "Test@test.test",
                              To = "WoofWoof@woof.woof",
                              Date = DateTime.Now - new TimeSpan(1),
                              Subject = "Fcken spam",
                              Body = "spam spam spam",
                              IsArchive = false,
                              IsSentByMe = false,
                              IsSpam = true
                          });

            mails.Add(new Mail()
                          {
                              From = "WoofWoof@woof.woof",
                              To = "Test@test.test",
                              Date = DateTime.Now - new TimeSpan(1),
                              Subject = "wooof",
                              Body = "wfwfwfwf",
                              IsArchive = false,
                              IsSentByMe = true,
                              IsSpam = false
                          });


            mails.Add(new Mail()
                          {
                              From = "WoofWoof@woof.woof",
                              To = "Test@test.test",
                              Date = DateTime.Now - new TimeSpan(1),
                              Subject = "wooof",
                              Body = "wfwfwfwf",
                              IsArchive = true,
                              IsSentByMe = true,
                              IsSpam = true
                          });
        }
    }
}
