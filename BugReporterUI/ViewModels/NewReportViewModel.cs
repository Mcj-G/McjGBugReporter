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
    public class NewReportViewModel : Screen
    {
        private IListsEndpoint _listsEndpoint;

        public NewReportViewModel(IListsEndpoint listsEndpoint)
        {
            _listsEndpoint = listsEndpoint;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadLists();
        }

        private async Task LoadLists()
        {
            var lists = await _listsEndpoint.GetLists();
            ProjectList = new BindingList<ProjectModel>(lists.ProjectList);
            CategoryList = new BindingList<CategoryModel>(lists.CategoryList);
            PriorityList = new BindingList<PriorityModel>(lists.PriorityList);
            FrequencyList = new BindingList<FrequencyModel>(lists.FrequencyList);
        }

        private BindingList<ProjectModel> _projectList;
        public BindingList<ProjectModel> ProjectList
        {
            get { return _projectList; }
            set 
            { 
                _projectList = value;
                NotifyOfPropertyChange(() => ProjectList);
            }
        }

        private BindingList<CategoryModel> _categoryList;
        public BindingList<CategoryModel> CategoryList
        {
            get { return _categoryList; }
            set 
            { 
                _categoryList = value;
                NotifyOfPropertyChange(() => CategoryList);
            }
        }

        private BindingList<PriorityModel> _priorityList;
        public BindingList<PriorityModel> PriorityList
        {
            get { return _priorityList; }
            set 
            { 
                _priorityList = value;
                NotifyOfPropertyChange(() => PriorityList);
            }
        }


        private BindingList<FrequencyModel> _frequencyList;
        public BindingList<FrequencyModel> FrequencyList
        {
            get { return _frequencyList; }
            set 
            { 
                _frequencyList = value;
                NotifyOfPropertyChange(() => FrequencyList);
            }
        }






    }
}
