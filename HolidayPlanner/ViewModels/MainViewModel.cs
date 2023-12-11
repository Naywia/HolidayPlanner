
﻿using System.Collections.Generic;
﻿using System;
using Avalonia.Interactivity;

namespace HolidayPlanner.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        private ViewModelBase contentViewModel;
        private List<ViewModelBase> contentViewModels = new();

        public MainViewModel()
        {
            contentViewModels.Add(new LoginViewModel());
            contentViewModels.Add(new LoginViewModel());
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
    public static readonly Action<Object?, RoutedEventArgs> Thing = (sender, e) => {  };
}
