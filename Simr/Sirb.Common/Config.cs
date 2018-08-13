using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirb.Common
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
