using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace EmailTraceListener
{
    public class EmailTraceListener : TraceListener
    {
        private TraceEmailer traceEmailer;
        public ITraceEmailer CurrentTraceEmailer
        {
            get
            {
                if (traceEmailer == null)
                {
                    traceEmailer = new TraceEmailer(
                        Attributes["fromAddress"],
                        Attributes["toAddress"],
                        Attributes["subject"]
                        );
                }
                return traceEmailer;
            }
        }

        protected override string[] GetSupportedAttributes()
        {
            return new string[] { "fromAddress", "toAddress", "subject" };
        }

        public override void Write(string message)
        {
            //CurrentTraceEmailer.SendTraceEmail(message);
        }

        public override void WriteLine(string message)
        {
            CurrentTraceEmailer.SendTraceEmail(message);
        }
    }
}
