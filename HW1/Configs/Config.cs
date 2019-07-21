using System;

namespace HW1
{
    public static class Config
    {
        public static readonly TimeSpan ImplicitWait = new TimeSpan(0, 0, 0, 5);
        public static readonly TimeSpan NoWait = new TimeSpan(0, 0, 0, 0);
    }
}
