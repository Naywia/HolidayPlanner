using System;
using Avalonia.Controls;
using HolidayPlanner.ViewModels;

namespace HolidayPlanner.Views
{
    public partial class VacationRequestView : UserControl
    {
        public VacationRequestView()
        {
            InitializeComponent();
            DataContext = new VacationRequestViewModel();
            startDatePicker.SelectedDate = new DateTimeOffset(DateTime.Now);
            endDatePicker.SelectedDate = new DateTimeOffset(DateTime.Now);
        }
    }
}
