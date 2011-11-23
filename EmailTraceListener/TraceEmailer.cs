using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace EmailTraceListener
{
    public class TraceEmailer: ITraceEmailer
    {
        public string MailFrom { get; set; }
        public string MailTo { get; set; }
        public string Subject { get; set; }


        public TraceEmailer(string from, string to, string subject)
        {
            MailFrom = from;
            MailTo = to;
            Subject = subject;
        }

        public void SendTraceEmail(string message)
        {
            try
            {
                MailMessage msg = new MailMessage(MailFrom, MailTo, Subject, message);

                SmtpClient smtp = new SmtpClient();
                smtp.SendCompleted += (sender, e) =>
                    {
                        if (e.Cancelled)
                        {

                        }
                    };
                smtp.SendAsync(msg, null);
            }

            catch
            { }
        }


    }
}
