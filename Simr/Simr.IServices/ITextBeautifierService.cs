using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sirb.Common.Enums;

namespace Simr.IServices
{
    public interface ITextBeautifierService
    {
        string Beautify(string input, Language from, Language to);
    }
}
