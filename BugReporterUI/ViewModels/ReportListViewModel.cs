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
    public class ReportListViewModel :Screen
    {
        private IBugEndpoint _bugEndpoint;
        public ReportListViewModel(IBugEndpoint bugEndpoint)
        {
            _bugEndpoint = bugEndpoint;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadReports();
        }

        private async Task LoadReports()
        {
            var reports = await _bugEndpoint.GetAll();

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
