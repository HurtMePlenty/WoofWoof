using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALTypes;

namespace DAL
{
    public interface IDataBaseContext
    {
        IMailData MailData { get; }
    }
}
