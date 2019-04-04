using System.Collections.Generic;
using System.Globalization;
using Microsoft.Extensions.Localization;

using Plumsail.Core.Models;

namespace Plumsail.Core.Localization
{
    public class PhoneLocalizer : IStringLocalizer<Phone>
    {
        public static readonly string TitleRequired = "Title is required";
        public static readonly string PriceInvalid = "Invalid price";
        public static readonly string ColorRequired = "Color is required";
        public static readonly string ProductionDateInvalid = "Invalid production date";
        public static readonly string MemoryInvalid = "Invalid memory";

        private readonly Dictionary<string, string> messages = new Dictionary<string, string>
        {
            { TitleRequired, TitleRequired },
            { PriceInvalid, PriceInvalid },
            { ColorRequired, ColorRequired },
            { ProductionDateInvalid, ProductionDateInvalid },
            { MemoryInvalid, MemoryInvalid }
        };

        public LocalizedString this[string name] {
            get
            {
                var message = string.Empty;

                if (messages.ContainsKey(name))
                    message = messages[name];

                return new LocalizedString(name, message);
            }
        }

        public LocalizedString this[string name, params object[] arguments] => throw new System.NotImplementedException();

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            throw new System.NotImplementedException();
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            return this;
        }
    }
}
