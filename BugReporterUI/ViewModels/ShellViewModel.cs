using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugReporterUI.EventModels;
using Caliburn.Micro;

namespace BugReporterUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>, 
        IHandle<NewReportEvent>, IHandle<ReportListEvent>, IHandle<OpenReportEvent>, 
        IHandle<YourCasesEvent>
    {
        private IEventAggregator _events;
        private MainViewModel _mainVM;
        private NewReportViewModel _newReportVM;
        private ReportListViewModel _reportListVM;
        private ReportViewModel _reportVM;
        private YourCasesViewModel _yourCasesVM;
        private SimpleContainer _container;

        public ShellViewModel(IEventAggregator events, MainViewModel mainVM,
            NewReportViewModel newReportVM, ReportListViewModel reportListVM,
            ReportViewModel reportVM, YourCasesViewModel yourCasesVM, SimpleContainer container)
        {
            _events = events;
            _mainVM = mainVM;
            _newReportVM = newReportVM;
            _reportListVM = reportListVM;
            _reportVM = reportVM;
            _yourCasesVM = yourCasesVM;
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

        public void Handle(OpenReportEvent message)
        {
            ActivateItem(_reportVM);
        }

        public void Handle(YourCasesEvent message)
        {
            ActivateItem(_yourCasesVM);
        }
    }
}
