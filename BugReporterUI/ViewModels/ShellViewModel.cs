﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugReporterUI.EventModels;
using Caliburn.Micro;
using WPFBR.Library.Models;

namespace BugReporterUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>, 
        IHandle<NewReportEvent>, IHandle<ReportListEvent>, IHandle<OpenReportEvent>, 
        IHandle<YourCasesEvent>, IHandle<ClosedCasesEvent>
    {
        private IEventAggregator _events;
        private MainViewModel _mainVM;
        private NewReportViewModel _newReportVM;
        private ReportListViewModel _reportListVM;
        private ReportViewModel _reportVM;
        private YourCasesViewModel _yourCasesVM;
        private ClosedCasesViewModel _closedCasesVM;
        private ManageProjectsViewModel _manageProjectsVM;
        private SimpleContainer _container;
        private ILoggedInUserModel _loggedUser;

        public ShellViewModel(IEventAggregator events, MainViewModel mainVM,
            NewReportViewModel newReportVM, ReportListViewModel reportListVM,
            ReportViewModel reportVM, YourCasesViewModel yourCasesVM, 
            ClosedCasesViewModel closedCasesVM, ManageProjectsViewModel manageProjectsVM,
            SimpleContainer container, ILoggedInUserModel loggedUser)
        {
            _events = events;
            _mainVM = mainVM;
            _newReportVM = newReportVM;
            _reportListVM = reportListVM;
            _reportVM = reportVM;
            _yourCasesVM = yourCasesVM;
            _closedCasesVM = closedCasesVM;
            _manageProjectsVM = manageProjectsVM;
            _container = container;
            _loggedUser = loggedUser;
            _events.Subscribe(this);
            
            ActivateItem(_container.GetInstance<LoginViewModel>());
            
        }

        public bool IsLoggedIn
        {
            get
            {
                bool output = false;

                if (string.IsNullOrWhiteSpace(_loggedUser.Token) == false)
                {
                    output = true;
                }

                return output;
            }
        }

        public void ExitApplication()
        {
            TryClose();
        }

        public void BackToMainView()
        {
            ActivateItem(_mainVM);
        }

        public void ManageProjects()
        {
            ActivateItem(_manageProjectsVM);
        }

        public void Handle(LogOnEvent message)
        {
            ActivateItem(_mainVM);
            NotifyOfPropertyChange(() => IsLoggedIn);
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

        public void Handle(ClosedCasesEvent message)
        {
            ActivateItem(_closedCasesVM);
        }
    }
}
