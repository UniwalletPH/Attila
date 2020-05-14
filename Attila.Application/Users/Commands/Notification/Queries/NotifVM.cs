using System;
using System.Collections.Generic;
using System.Text;

namespace Attila.Application.Notification.Queries
{
    public class NotifVM
    {
        public int TargetUserID { get; set; }

        public string Description { get; set; }

        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
