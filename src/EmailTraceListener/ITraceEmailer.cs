using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmailTraceListener
{
    public interface ITraceEmailer
    {
        void SendTraceEmail(string message);
        string MailFrom { get; set; }
        string MailTo { get; set; }
        string Subject { get; set; }
    }
}
