using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace MyBelongingsApp.Attach
{
    public class MyTimer : Timer
    {
        public MyTimer()
        {
            this.Enabled = true;
            this.Interval = 5000;
            this.Start();
            this.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
        }
    }
}
