using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugReporterUI.EventModels;
using Caliburn.Micro;

namespace BugReporterUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>, IHandle<NewReportEvent>, IHandle<ReportListEvent>
    {
        private IEventAggregator _events;
        private MainViewModel _mainVM;
        private NewReportViewModel _newReportVM;
        private ReportListViewModel _reportListVM;
        private SimpleContainer _container;

        public ShellViewModel(IEventAggregator events, MainViewModel mainVM,
            NewReportViewModel newReportVM, ReportListViewModel reportListVM,
            SimpleContainer container)
        {
            _events = events;
            _mainVM = mainVM;
            _newReportVM = newReportVM;
            _reportListVM = reportListVM;
            _container = container;

            _events.Subscribe(this);
            
            ActivateItem(_container.GetInstance<LoginViewModel>());
            
        }
        public void ExitApplication()
        {
            TryClose();
        }

        public void BackToMainView()
        {
            ActivateItem(_mainVM);
        }

        public void Handle(LogOnEvent message)
        {
            ActivateItem(_mainVM);
        }

        public void Handle(NewReportEvent message)
        {
            ActivateItem(_newReportVM);
        }

        public void Handle(ReportListEvent message)
        {
            ActivateItem(_reportListVM);
        }
    }
}
