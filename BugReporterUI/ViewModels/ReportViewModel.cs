﻿using BugReporterUI.EventModels;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFBR.Library.API;
using WPFBR.Library.Models;

namespace BugReporterUI.ViewModels
{
    public class ReportViewModel : Screen, IHandle<OpenReportEvent>
    {
        private IEventAggregator _events;
        private ICommentEndpoint _commentEndpoint;
        private IStatusEndpoint _statusEndpoint;
        private IBugEndpoint _bugEndpoint;
        private ILoggedInUserModel _loggedUser;

        public ReportViewModel(IEventAggregator events, ICommentEndpoint commentEndpoint,
            IStatusEndpoint statusEndpoint, IBugEndpoint bugEndpoint,
            ILoggedInUserModel loggedUser)
        {
            _events = events;
            _commentEndpoint = commentEndpoint;
            _statusEndpoint = statusEndpoint;
            _bugEndpoint = bugEndpoint;
            _loggedUser = loggedUser;
            _events.Subscribe(this);
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);

            await LoadData();
        }

        private async Task LoadData()
        {
            CommentsList = await _commentEndpoint.GetById(Report.Id);
            StatusList = await _statusEndpoint.GetAll();
            StatusList = StatusList.Where(x => x.Name != "New").ToList();
        }

        private async Task RefreshReport()
        {
            var reportList = await _bugEndpoint.GetAll();
            Report = reportList.Where(x => x.Id == Report.Id).FirstOrDefault();
        }

        private BugDisplayModel _report;
        public BugDisplayModel Report
        {
            get { return _report; }
            set 
            { 
                _report = value;
                NotifyOfPropertyChange(() => Report);
            }
        }

        private List<StatusModel> _statusList;
        public List<StatusModel> StatusList
        {
            get { return _statusList; }
            set 
            { 
                _statusList = value;
                NotifyOfPropertyChange(() => StatusList);
            }
        }

        private StatusModel _newStatus;
        public StatusModel NewStatus
        {
            get { return _newStatus; }
            set 
            { 
                _newStatus = value;
                NotifyOfPropertyChange(() => NewStatus);
                NotifyOfPropertyChange(() => CanChangeStatus);
            }
        }



        private string _newComment;
        public string NewComment
        {
            get { return _newComment; }
            set 
            { 
                _newComment = value;
                NotifyOfPropertyChange(() => NewComment);
                NotifyOfPropertyChange(() => CanAddComment);
            }
        }

        private List<CommentModel> _commentsList;
        public List<CommentModel> CommentsList
        {
            get { return _commentsList; }
            set 
            { 
                _commentsList = value;
                NotifyOfPropertyChange(() => CommentsList);
            }
        }

        public void BackToAll()
        {
            _events.PublishOnUIThread(new ReportListEvent());
        }

        public async Task Assign()
        {
            string bugId = Report.Id.ToString();
            string userId = _loggedUser.Id;
            List<string> idList = new List<string>
            {
                bugId,
                userId
            };

            await _bugEndpoint.UpdateAssignedUser(idList);

            await AddNewComment($"{ _loggedUser.EmailAddress } is now assigned to this case",
                "You are now assigned to this case.");

            await RefreshReport();
        }

        public void YourCases()
        {
            _events.PublishOnUIThread(new YourCasesEvent());
        }

        public bool CanChangeStatus 
        { 
            get
            {
                bool output = false;

                if (NewStatus != null)
                {
                    output = true;
                }

                return output;
            }
        }
        public async Task ChangeStatus()
        {
            await _statusEndpoint.UpdateStatus(Report.Id, NewStatus.Id);

            await AddNewComment($"Status changed to { NewStatus.Name } by { _loggedUser.EmailAddress }", "Status changed!");

            await RefreshReport();
        }

        public bool CanAddComment 
        {
            get
            {
                bool output = false;
                if (NewComment != null && NewComment != "")
                {
                    output = true;
                }
                return output;
            }
        }
        public async Task AddComment()
        {
            await AddNewComment(NewComment, "Comment added!");

            NewComment = null;

            NotifyOfPropertyChange(() => CommentsList);
            NotifyOfPropertyChange(() => NewComment);
            NotifyOfPropertyChange(() => CanAddComment);
        }

        private async Task AddNewComment(string content, string msg)
        {
            content = $"{ DateTime.Now.ToShortDateString() }: { content }";

            CommentModel comment = new CommentModel
            {
                BugId = Report.Id,
                Content = content
            };

            await _commentEndpoint.PostComment(comment);

            MessageBox.Show($"{ msg }", "Mcjg Bug Reporter", MessageBoxButton.OK, MessageBoxImage.Information);

            await LoadData();
        }

        public void Handle(OpenReportEvent message)
        {
            Report = message.Report;
        }
    }
}
