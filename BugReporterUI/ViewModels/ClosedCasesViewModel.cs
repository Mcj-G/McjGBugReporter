using BugReporterUI.EventModels;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBR.Library.API;
using WPFBR.Library.Models;

namespace BugReporterUI.ViewModels
{
    public class ClosedCasesViewModel : Screen
    {
        private IBugEndpoint _bugEndpoint;
        private IEventAggregator _events;

        public ClosedCasesViewModel(IBugEndpoint bugEndpoint, IEventAggregator events)
        {
            _bugEndpoint = bugEndpoint;
            _events = events;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadReports();
        }

        private async Task LoadReports()
        {
            var reports = await _bugEndpoint.GetAll();

            reports = reports.Where(x => x.StatusName == "Closed").ToList();

            Reports = new BindingList<BugDisplayModel>(reports);
        }

        private BindingList<BugDisplayModel> _reports;
        public BindingList<BugDisplayModel> Reports
        {
            get { return _reports; }
            set
            {
                _reports = value;
                NotifyOfPropertyChange(() => Reports);
            }
        }

        private BugDisplayModel _selectedReport;
        public BugDisplayModel SelectedReport
        {
            get { return _selectedReport; }
            set
            {
                _selectedReport = value;
                NotifyOfPropertyChange(() => SelectedReport);
                NotifyOfPropertyChange(() => CanOpenSelected);

            }
        }

        public bool CanOpenSelected
        {
            get
            {
                bool output = false;
                if (SelectedReport != null)
                {
                    output = true;
                }
                return output;
            }
        }

        public void OpenSelected()
        {
            _events.PublishOnUIThread(new OpenReportEvent { Report = SelectedReport });
        }


        private List<string> _filterCB;
        public List<string> FilterCB
        {
            get
            {
                List<string> list = new List<string>
                {
                    "Id",
                    "Assigned user",
                    "Category",
                    "Project",
                    "Status"
                };
                _filterCB = list;
                return _filterCB;
            }
            set
            {
                _filterCB = value;
                NotifyOfPropertyChange(() => FilterCB);
            }
        }

        private string _filter;
        public string Filter
        {
            get { return _filter; }
            set
            {
                _filter = value;
                NotifyOfPropertyChange(() => Filter);
            }
        }

        private string _filterText;
        public string FilterText
        {
            get { return _filterText; }
            set
            {
                _filterText = value;
                NotifyOfPropertyChange(() => FilterText);
            }
        }

        public async Task ApplyFilter()
        {
            if (FilterText == "" || FilterText == null)
            {
                await LoadReports();
                NotifyOfPropertyChange(() => Reports);
            }
            else
            {
                if (Filter == "Id")
                {
                    if (int.TryParse(FilterText, out int value))
                    {
                        await LoadReports();
                        Reports = new BindingList<BugDisplayModel>(Reports.Where(x => x.Id == value).ToList());
                        NotifyOfPropertyChange(() => Reports);
                    }
                    else
                    {
                        await LoadReports();
                        NotifyOfPropertyChange(() => Reports);
                    }

                }
                else if (Filter == "Assigned user")
                {
                    await LoadReports();
                    Reports = new BindingList<BugDisplayModel>(Reports.Where(x => x.AssignedUserMail == FilterText).ToList());
                    NotifyOfPropertyChange(() => Reports);
                }
                else if (Filter == "Category")
                {
                    await LoadReports();
                    Reports = new BindingList<BugDisplayModel>(Reports.Where(x => x.CategoryName == FilterText).ToList());
                    NotifyOfPropertyChange(() => Reports);
                }
                else if (Filter == "Project")
                {
                    await LoadReports();
                    Reports = new BindingList<BugDisplayModel>(Reports.Where(x => x.ProjectName == FilterText).ToList());
                    NotifyOfPropertyChange(() => Reports);
                }
                else if (Filter == "Status")
                {
                    await LoadReports();
                    Reports = new BindingList<BugDisplayModel>(Reports.Where(x => x.StatusName == FilterText).ToList());
                    NotifyOfPropertyChange(() => Reports);
                }
            }

        }
    }
}
