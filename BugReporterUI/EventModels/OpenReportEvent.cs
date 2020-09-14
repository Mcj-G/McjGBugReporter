using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBR.Library.Models;

namespace BugReporterUI.EventModels
{
    public class OpenReportEvent
    {
        public BugDisplayModel Report { get; set; }
    }
}
