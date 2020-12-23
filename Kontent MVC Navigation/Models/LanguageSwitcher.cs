using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Kontent_MVC_Navigation.Models
{
    public class LanguageSwitcher
    {
        public CultureInfo CurrentUICulture { get; set; }
        public List<CultureInfo> SupportedCultures { get; set; }
        public string CurrentController { get; set; }
        public string CurrentAction { get; set; }
        public string CurrentPath { get; set; }
    }
}
