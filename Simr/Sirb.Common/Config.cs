namespace Sirb.Common
{
    using System;

    public static class Config
    {
        static Config()
        {
            Config.Random = new Random();
        }

        public static Random Random { get; }
    }
}