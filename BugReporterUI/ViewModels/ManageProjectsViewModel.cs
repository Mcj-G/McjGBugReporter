using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFBR.Library.API;
using WPFBR.Library.Models;

namespace BugReporterUI.ViewModels
{
    public class ManageProjectsViewModel : Screen
    {

        private IProjectEndpoint _projectEndpoint;
        public ManageProjectsViewModel(IProjectEndpoint projectEndpoint)
        {
            _projectEndpoint = projectEndpoint;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadProjectList();
        }

        private async Task LoadProjectList()
        {
            var list = await _projectEndpoint.GetAll();
            ProjectList = new BindingList<ProjectModel>(list);
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
                UpdateProjectName = SelectedProject?.Name;
                UpdateProjectVersion = SelectedProject?.Version;
                NotifyOfPropertyChange(() => SelectedProject);
                NotifyOfPropertyChange(() => UpdateProjectName);
                NotifyOfPropertyChange(() => UpdateProjectVersion);
                NotifyOfPropertyChange(() => CanUpdateProject);
            }
        }


        private string _updateProjectName;
        public string UpdateProjectName
        {
            get { return _updateProjectName; }
            set 
            { 
                _updateProjectName = value;
                NotifyOfPropertyChange(() => UpdateProjectName);
                NotifyOfPropertyChange(() => CanUpdateProject);
            }
        }

        private string _updateProjectVersion;
        public string UpdateProjectVersion
        {
            get { return _updateProjectVersion; }
            set 
            { 
                _updateProjectVersion = value;
                NotifyOfPropertyChange(() => UpdateProjectVersion);
                NotifyOfPropertyChange(() => CanUpdateProject);
            }
        }

        private string _newProjectName;
        public string NewProjectName
        {
            get { return _newProjectName; }
            set 
            { 
                _newProjectName = value;
                NotifyOfPropertyChange(() => NewProjectName);
                NotifyOfPropertyChange(() => CanAddNewProject);
            }
        }

        private string _newProjectVersion;
        public string NewProjectVersion
        {
            get { return _newProjectVersion; }
            set 
            { 
                _newProjectVersion = value;
                NotifyOfPropertyChange(() => NewProjectVersion);
                NotifyOfPropertyChange(() => CanAddNewProject);
            }
        }

        public bool CanUpdateProject
        {
            get
            {
                bool output = false;

                if (UpdateProjectName != null && UpdateProjectVersion != null
                    && UpdateProjectName != "" && UpdateProjectVersion != ""
                    && SelectedProject != null)
                {
                    output = true;
                }

                return output;
            }
        }

        public bool CanAddNewProject 
        {
            get
            {
                bool output = false;

                if (NewProjectName != null && NewProjectVersion != null
                    && NewProjectName != "" && NewProjectVersion != "")
                {
                    output = true;
                }

                return output;
            }
        }

        public async Task UpdateProject()
        {
            MessageBoxResult messageBoxResult = MessageBox.Show(
                "Are you sure you want to update selected project with this data:" + Environment.NewLine
                + $"Project name: { UpdateProjectName }" + Environment.NewLine
                + $"Project version: { UpdateProjectVersion }", 
                "Update confirmarion.", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                ProjectModel model = new ProjectModel
                {
                    Id = SelectedProject.Id,
                    Name = UpdateProjectName,
                    Version = UpdateProjectVersion
                };

                await _projectEndpoint.UpdateProject(model);

                MessageBox.Show("Project updated.", "Mcjg Bug Reporter", MessageBoxButton.OK, MessageBoxImage.Information);

                SelectedProject = null;
                await LoadProjectList();
            }
        }

        public async Task DeleteProject()
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to delete this project",
                "Update confirmarion.", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                await _projectEndpoint.DeleteProject(SelectedProject.Id);

                MessageBox.Show("Project deleted.", "Mcjg Bug Reporter", MessageBoxButton.OK, MessageBoxImage.Information);

                await LoadProjectList();
            }
        }

        public async Task AddNewProject()
        {
            MessageBoxResult messageBoxResult = MessageBox.Show(
                "Are you sure you want to create new project with this data:" + Environment.NewLine
                + $"Project name: { NewProjectName }" + Environment.NewLine
                + $"Project version: { NewProjectVersion }",
                "Update confirmarion.", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                ProjectModel model = new ProjectModel
                {
                    Id = 0,
                    Name = NewProjectName,
                    Version = NewProjectVersion
                };

                await _projectEndpoint.PostProject(model);

                MessageBox.Show("Project created.", "Mcjg Bug Reporter", MessageBoxButton.OK, MessageBoxImage.Information);

                SelectedProject = null;
                NewProjectName = null;
                NewProjectVersion = null;
                await LoadProjectList();
            }
        }
    }
}
