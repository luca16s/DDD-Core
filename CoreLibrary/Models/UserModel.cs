using System.Collections.Generic;

namespace CoreLibrary.Models
{
    public class UserModel : BaseEntity
    {
        public List<string> BusinessPhones { get; set; }

        public string DisplayName { get; set; }

        public string GivenName { get; set; }

        public object JobTitle { get; set; }

        public string Mail { get; set; }

        public string MobilePhone { get; set; }

        public object OfficeLocation { get; set; }

        public string Photo { get; set; }

        public string PreferredLanguage { get; set; }

        public string Surname { get; set; }

        public string UserPrincipalName { get; set; }
    }
}