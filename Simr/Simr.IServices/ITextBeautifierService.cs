using Simr.Common.Enums;

namespace Simr.IServices
{
    public interface ITextBeautifierService
    {
        string Beautify(string input, Language from, Language to);
    }
}