using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Simr.IServices;

using Sirb.Common;
using Sirb.Common.Enums;

namespace Simr.Services
{
    public class TextBeautifierService : ITextBeautifierService
    {
        private static class CharacterResolverData
        {
            public static IDictionary<char, string[]> GetBinding(Language from, Language to)
            {
                if (from == Language.Ru && to == Language.Gr)
                {
                    return new Dictionary<char, string[]>
                    {
                        { 'а', new[] { "Α", "α" } },
                        { 'б', new[] { "Б δ" } },
                        { 'в', new[] { "Β", "β" } },
                        { 'г', new[] { "Γ", "γ" } },
                        { 'д', new[] { "Δ" } },
                        { 'е', new[] { "Ε", "ε" } },
                        { 'ё', new[] { "Ε", "ε" } },
                        { 'ж', new[] { "Ж" } },
                        { 'з', new[] { "Ζ" } },
                        { 'и', new[] { "Ν", "И" } },
                        { 'й', new[] { "Ν", "И" } },
                        { 'к', new[] { "Κ", "κ" } },
                        { 'л', new[] { "Λ", "λ" } },
                        { 'м', new[] { "Μ", "μ" } },
                        { 'н', new[] { "Н" } },
                        { 'о', new[] { "Ο", "ο" } },
                        { 'п', new[] { "Π", "π" } },
                        { 'р', new[] { "Ρ", "ρ" } },
                        { 'с', new[] { "ς", "σ" } },
                        { 'т', new[] { "T", "τ" } },
                        { 'у', new[] { "Υ" } },
                        { 'ф', new[] { "Φ", "φ" } },
                        { 'х', new[] { "Χ", "χ" } },
                        { 'ц', new[] { "ψ" } },
                        { 'ч', new[] { "Ч" } },
                        { 'ш', new[] { "ω" } },
                        { 'щ', new[] { "ω" } },
                        { 'ъ', new[] { "Ъ" } },
                        { 'ы', new[] { "Ы" } },
                        { 'ь', new[] { "Ь" } },
                        { 'э', new[] { "ξ" } },
                        { 'ю', new[] { "Ю" } },
                        { 'я', new[] { "Я" } },
                        { ' ', new[] { " " } },
                    };
                }

                if (from == Language.Ru && to == Language.Talib)
                {
                    return new Dictionary<char, string[]>
                    {
                        { 'а', new[] { "A", "₳", "ᗩ", "α", "A", "α", "ѧ", "Å", "∀", "Λ", "Ā" } },
                        { 'б', new[] { "Б", "δ" } },
                        { 'в', new[] { "Β", "β", "฿", "v" } },
                        { 'г', new[] { "Γ", "Ļ", "γ", "G", "g", "Ģ" } },
                        { 'д', new[] { "Δ", "D", "▲", } },
                        { 'е', new[] { "Ε", "ε", "∑", "ع", "Ҿ" } },
                        { 'ё', new[] { "Ε", "ε", "∑", "ع", "Ҿ" } },
                        { 'ж', new[] { "Ж", "ʥ", "ਅ", "ਐ" } },
                        { 'з', new[] { "Ζ", "Ȝ", "ʓ" } },
                        { 'и', new[] { "Ν", "И", "Й" } },
                        { 'й', new[] { "Ν", "Ñ", "И" } },
                        { 'к', new[] { "Κ", "κ", "ƙ" } },
                        { 'л', new[] { "Λ", "λ" } },
                        { 'м', new[] { "Μ", "μ" } },
                        { 'н', new[] { "Н", "Ħ", "Ƕ" } },
                        { 'о', new[] { "Ο", "ο", "Ǿ", "Ѻ" } },
                        { 'п', new[] { "Π", "π", "ח" } },
                        { 'р', new[] { "Ρ", "ρ", "Þ" } },
                        { 'с', new[] { "ς", "σ", "Ͼ", "Ͽ" } },
                        { 'т', new[] { "T", "τ", "†", "Ŧ", "7", "Ϯ" } },
                        { 'у', new[] { "Υ", "ƴ", "ѱ", "ץ" } },
                        { 'ф', new[] { "Φ", "φ" } },
                        { 'х', new[] { "Χ", "χ", "×", "ϰ" } },
                        { 'ц', new[] { "ψ" } },
                        { 'ч', new[] { "Ч", "Ӵ", "բ" } },
                        { 'ш', new[] { "ω", "Ɯ" } },
                        { 'щ', new[] { "Ϣ", "Ɯ", "ɰ" } },
                        { 'ъ', new[] { "Ъ" } },
                        { 'ы', new[] { "Ы" } },
                        { 'ь', new[] { "Ь", "ȶ" } },
                        { 'э', new[] { "Э", "ξ" } },
                        { 'ю', new[] { "Ю" } },
                        { 'я', new[] { "Я", "☈", "ʁ" } },
                        { ' ', new[] { " " } },
                    };
                }

                throw new NotImplementedException();
            }
        }

        private class CharacterResolver
        {
            public CharacterResolver(Language from, Language to)
            {
                this.From = from;
                this.To = to;
            }

            public Language To { get; }

            public Language From { get; }

            public string Resolve(char character)
            {
                var variations = CharacterResolverData.GetBinding(From, To)[character];
                return variations[Config.Random.Next(0, variations.Length)];
            }
        }

        public string Beautify(string input, Language from, Language to)
        {
            var output = new StringBuilder();
            var characterResolver = new CharacterResolver(from, to);

            foreach (var character in input)
            {
                var beautyCharacter = characterResolver.Resolve(character);
                output.Append(beautyCharacter);
            }

            return output.ToString();
        }
    }
}
