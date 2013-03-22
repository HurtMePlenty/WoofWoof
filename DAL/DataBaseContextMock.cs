using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALTypes;

namespace DAL
{
    public class DataBaseContextMock : IDataBaseContext
    {

        public DataBaseContextMock()
        {
            _mailDataMock = new MailDataMock();
        }

        private readonly MailDataMock _mailDataMock; 

        public IMailData MailData
        {
            get { return _mailDataMock; }
        }

    }
}
