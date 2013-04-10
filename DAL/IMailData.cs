using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALTypes;

namespace DAL
{
    public interface IMailData
    {
        IList<Mail> GetMails();
        IList<Mail> GetMails(Mail.Folders folder);
        Mail GetMails(int id);
    }
}
