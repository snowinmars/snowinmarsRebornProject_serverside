using System;

namespace Simr.Common
{
    public static class Config
    {
        static Config()
        {
            Random = new Random();
        }

        public static Random Random { get; }
    }
}