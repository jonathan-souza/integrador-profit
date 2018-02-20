using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConnectionMonitor
{
    public class Monitor
    {
        private static Monitor _Instance;
        public static Monitor Instance
        {
            get
            {
                StartInstance();

                return _Instance;
            }
        }

        private static void StartInstance()
        {
            if (_Instance == null)
            {
                lock (syncRoot)
                {
                    _Instance = new Monitor();
                }
            }
        }
        private static Timer TestTimer { get; set; }
        private static object syncRoot = new Object();

        private static string Status { get; set; }

        public string GetStatus()
        {
            return Status;
        }

        private void CheckStatusHandler(object sender, EventArgs e)
        {
            CheckStatus();
        }

        private static void CheckStatus()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://www.google.com");
                request.Timeout = 3000;
                request.AllowAutoRedirect = false; // find out if this site is up and don't follow a redirector
                request.Method = "HEAD";

                using (var response = request.GetResponse())
                {
                    lock (syncRoot)
                    {
                        Status = "Internet Connection OK";
                    }
                }
            }
            catch
            {
                lock (syncRoot)
                {
                    Status = "NO Internet Connection";
                }
            }
        }

        public void Start()
        {
            StartInstance();
        }

        private Monitor()
        {
            Status = "Unknown State";

            if (TestTimer == null)
            {
                TestTimer = new Timer();
                TestTimer.Elapsed += new ElapsedEventHandler(CheckStatusHandler);
                TestTimer.Interval = 5000;
                TestTimer.Start();
            }

            CheckStatus();
        }
    }
}
