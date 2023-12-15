
using System.Collections.Generic;
using System;
using Avalonia.Interactivity;
using HolidayPlanner.Models;

namespace HolidayPlanner.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public static VacationTypeRepo vacationTypeRepo = new();
        public static VacationRequestRepo vacationRequestRepo = new(vacationTypeRepo);
        public static EmployeeRepo employeeRepo = new(vacationRequestRepo);

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
