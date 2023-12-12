
using System.Collections.Generic;
using System;
using Avalonia.Interactivity;

namespace HolidayPlanner.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase contentViewModel;
        private List<ViewModelBase> contentViewModels = new();

        public MainWindowViewModel()
        {
            contentViewModels.Add(new LoginViewModel());
            contentViewModels.Add(new MainViewModel());
            contentViewModel = contentViewModels[0];
        }

        public ViewModelBase ContentViewModel
        {
            get => contentViewModel;
            set
            {
                contentViewModel = value;
                NotifyPropertyChanged();
            }
        }

        public List<ViewModelBase> ContentViewModels
        {
            get { return contentViewModels; }
        }
    }
}
