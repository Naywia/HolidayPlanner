using Avalonia.Interactivity;
using HolidayPlanner.Models;
using System;

namespace HolidayPlanner.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public static readonly Action<Object?, RoutedEventArgs> Thing = (sender, e) => { };

        public static VacationTypeRepo vacationTypeRepo = new();
        public static VacationRequestRepo VacationRequestRepo = new(vacationTypeRepo);
        public static EmployeeRepo employeeRepo = new(VacationRequestRepo);
    }
}
