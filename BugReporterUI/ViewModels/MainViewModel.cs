using BugReporterUI.EventModels;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugReporterUI.ViewModels
{
    public class MainViewModel : Screen
    {
        private IEventAggregator _events;

        public MainViewModel(IEventAggregator events)
        {
            _events = events;
        }

        public void NewReport()
        {
            _events.PublishOnUIThread(new NewReportEvent());
        }

        public void ReportList()
        {
            _events.PublishOnUIThread(new ReportListEvent());
        }

        public void YourCases()
        {
            _events.PublishOnUIThread(new YourCasesEvent());
        }

        public void Manage()
        {

        }
    }
}
