using System;
using System.Collections.Generic;
using System.Globalization;
using Kentico.Kontent.Delivery.Abstractions;

namespace KenticoKontentModels
{
    public partial class Page
    {
        // Capitalize Kontent codenames to meet localized-route tag helper case requirements
        TextInfo ti = new CultureInfo("en-US", false).TextInfo;
        public string PageCodename => ti.ToTitleCase(System.Codename);
    }
}