﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALTypes
{
    public class Mail
    {
        private static int _id;
        public Mail()
        {
            Id = _id++;
        }

        public int Id { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsSpam { get; set; }
        public bool IsSentByMe { get; set; }
        public bool IsArchive { get; set; }

        public enum Folders
        {
            Inbox,
            Archive,
            Sent,
            Spam 
        }
    }
}
