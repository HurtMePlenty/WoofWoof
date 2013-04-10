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
            //return mails.Where(m => m.To == MyAdress).ToList();
            switch (folder)
            {
               case Mail.Folders.Inbox:
                    return mails.Where(m => m.To == MyAdress && !m.IsSpam && !m.IsArchive).ToList();
               case Mail.Folders.Sent:
                    return mails.Where(m => m.IsSentByMe).ToList();
                case Mail.Folders.Spam:
                    return mails.Where(m => m.IsSpam).ToList();
                case Mail.Folders.Archive:
                    return mails.Where(m => m.IsArchive).ToList();
            }
            return new List<Mail>();
        }

        public Mail GetMails(int id)
        {
            return mails.FirstOrDefault(m => m.Id == id);
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
                              IsSpam = false
                          });
        }
    }
}
