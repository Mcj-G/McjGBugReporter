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
        private ProjectModel _selectedProject;
        public ProjectModel SelectedProject
        {
            get { return _selectedProject; }
            set 
            { 
                _selectedProject = value;
                NotifyOfPropertyChange(() => SelectedProject);
                NotifyOfPropertyChange(() => CanSubmit);
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
        private CategoryModel _selectedCategory;
        public CategoryModel SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                NotifyOfPropertyChange(() => SelectedCategory);
                NotifyOfPropertyChange(() => CanSubmit);
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
        private PriorityModel _selectedPriority;
        public PriorityModel SelectedPriority
        {
            get { return _selectedPriority; }
            set
            {
                _selectedPriority = value;
                NotifyOfPropertyChange(() => SelectedPriority);
                NotifyOfPropertyChange(() => CanSubmit);
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
        private FrequencyModel _selectedFrequency;
        public FrequencyModel SelectedFrequency
        {
            get { return _selectedFrequency; }
            set
            {
                _selectedFrequency = value;
                NotifyOfPropertyChange(() => SelectedFrequency);
                NotifyOfPropertyChange(() => CanSubmit);
            }
        }

        private string _topic;
        public string Topic
        {
            get { return _topic; }
            set 
            { 
                _topic = value;
                NotifyOfPropertyChange(() => Topic);
                NotifyOfPropertyChange(() => CanSubmit);
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set 
            { 
                _description = value;
                NotifyOfPropertyChange(() => Description);
                NotifyOfPropertyChange(() => CanSubmit);
            }
        }

        public bool CanSubmit 
        {
            get
            {
                bool output = false;

                if (SelectedProject != null && SelectedFrequency != null &&
                    SelectedCategory !=null && SelectedPriority != null &&
                    Topic?.Length > 0 && Description?.Length > 0)
                {
                    output = true;
                }

                return output;
            }
        }

        public async Task Submit()
        {

        }




    }
}
