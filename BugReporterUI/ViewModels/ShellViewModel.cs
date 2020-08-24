using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugReporterUI.EventModels;
using Caliburn.Micro;

namespace BugReporterUI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private IEventAggregator _events;
        private MainViewModel _mainVM;
        private SimpleContainer _container;

        public ShellViewModel(IEventAggregator events, MainViewModel mainVM,
            SimpleContainer container)
        {
            _events = events;
            _mainVM = mainVM;
            _container = container;

            _events.Subscribe(this);
            
            ActivateItem(_container.GetInstance<LoginViewModel>());
            
        }

        public void Handle(LogOnEvent message)
        {
            ActivateItem(_mainVM);
        }
    }
}
