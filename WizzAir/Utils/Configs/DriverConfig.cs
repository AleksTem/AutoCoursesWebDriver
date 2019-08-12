using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WizzAir.Utils.Configs
{
    public static class DriverConfig
    {
        public static readonly TimeSpan ImplicitWait = new TimeSpan(0, 0, 0, 5);
        public static readonly TimeSpan NoWait = new TimeSpan(0, 0, 0, 0);
        public static readonly TimeSpan LowWait = TimeSpan.FromSeconds(10);
        public static readonly TimeSpan ExtraWait = TimeSpan.FromSeconds(90);
        public static readonly TimeSpan MiddleWait = TimeSpan.FromSeconds(40);


    }
}
