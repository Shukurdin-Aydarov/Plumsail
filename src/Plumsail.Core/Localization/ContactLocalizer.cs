using System.Collections.Generic;
using System.Globalization;
using Microsoft.Extensions.Localization;

using Plumsail.Core.Models;

namespace Plumsail.Core.Localization
{
    public class ContactLocalizer : IStringLocalizer<Contact>
    {
        public static readonly string NameRequired = "Name is required";
        public static readonly string SurnameRequired = "Surname is required";
        public static readonly string GenderRequired = "Gender is required";
        public static readonly string BirthDateInvalid = "Date of birth is invalid";

        private readonly Dictionary<string, string> messages = new Dictionary<string, string>
        {
            { NameRequired, NameRequired },
            { SurnameRequired, SurnameRequired },
            { GenderRequired, GenderRequired },
            { BirthDateInvalid, BirthDateInvalid }
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
