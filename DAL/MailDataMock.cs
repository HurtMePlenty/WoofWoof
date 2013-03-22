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
        public const string MyAdress = "WoofWoof@woof.woof";

        public MailDataMock()
        {
            Initialize();
        }

        private IList<Mail> mails;

        public IList<Mail> GetMails()
        {
            return mails;
        } 
        
        public IList<Mail> GetMails(Mail.Folders folder)
        {
            return mails.Where(m => m.To == MyAdress).ToList();
        } 

        private void Initialize()
        {
            mails = new List<Mail>();
            mails.Add(new Mail()
                          {
                              From = "Test@test.test",
                              To = MyAdress,
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
                              To = MyAdress,
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
                              To = MyAdress,
                              Date = DateTime.Now - new TimeSpan(1),
                              Subject = "Fcken spam",
                              Body = "spam spam spam",
                              IsArchive = false,
                              IsSentByMe = false,
                              IsSpam = true
                          });

            mails.Add(new Mail()
                          {
                              From = MyAdress,
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
                              From = MyAdress,
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
