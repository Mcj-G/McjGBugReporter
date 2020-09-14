using BugReporterUI.EventModels;
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

        public ReportViewModel(IEventAggregator events, ICommentEndpoint commentEndpoint)
        {
            _events = events;
            _commentEndpoint = commentEndpoint;

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

        private List<string> _statusList;
        public List<string> StatusList
        {
            get { return _statusList; }
            set 
            { 
                _statusList = value;
                NotifyOfPropertyChange(() => StatusList);
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

        }

        public void Assign()
        {

        }

        public void YourCases()
        {

        }

        public void ChangeStatus()
        {

        }

        public bool CanAddComment 
        {
            get
            {
                bool output = false;
                if (NewComment != null || NewComment != "")
                {
                    output = true;
                }
                return output;
            }
        }
        public async Task AddComment()
        {
            CommentModel comment = new CommentModel
            {
                BugId = Report.Id,
                Content = NewComment
            };

            await _commentEndpoint.PostComment(comment);

            MessageBox.Show("Comment added!", "Mcjg Bug Reporter", MessageBoxButton.OK, MessageBoxImage.Information);

            NewComment = null;

            await LoadData();

            NotifyOfPropertyChange(() => CommentsList);
            NotifyOfPropertyChange(() => NewComment);
            NotifyOfPropertyChange(() => CanAddComment);
        }

        public void Handle(OpenReportEvent message)
        {
            Report = message.Report;
        }
    }
}
