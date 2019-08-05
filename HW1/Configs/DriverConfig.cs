using System;

namespace WD_Tests
{
    public static class DriverConfig
    {
        public static readonly TimeSpan ImplicitWait = new TimeSpan(0, 0, 0, 5);
        public static readonly TimeSpan NoWait = new TimeSpan(0, 0, 0, 0);
    }
}
