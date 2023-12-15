using System;
using Avalonia.Interactivity
using HolidayPlanner.Models;

namespace HolidayPlanner.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public static readonly Action<Object?, RoutedEventArgs> Thing = (sender, e) => { };
    }

    public static VacationTypeRepo vacationTypeRepo = new();
    public static VacationRequestRepo vacationRequestRepo = new(vacationTypeRepo);





}
