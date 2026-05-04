using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Multilingual1.Models.ViewModels
{
    public class PageLanguageLogsVM
    {
        public string CurrentVersion { get; set; }

        public List<PageLanguageLogsVM> PageLanguageLogsList { get; set; }
    }
}