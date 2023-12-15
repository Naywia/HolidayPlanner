using System;
using System.Collections.Generic;
using HolidayPlanner.Models;
using ReactiveUI;

namespace HolidayPlanner.ViewModels
{
    public class VacationRequestViewModel : ViewModelBase
    {
        public List<VacationType> VacationTypes { get; set; } = MainWindowViewModel.vacationTypeRepo.GetVacationTypes();

        private DateTimeOffset startDate;
        public DateTimeOffset StartDate
        {
            get => startDate;
            set
            {
                startDate = value;
                Console.WriteLine($"startDate: {value}");
                NotifyPropertyChanged();
            }
        }

        private DateTimeOffset endDate = new();
        public DateTimeOffset EndDate
        {
            get => endDate;
            set
            {
                endDate = value;
                Console.WriteLine($"endDate: {value}");
                NotifyPropertyChanged();
            }
        }

        private String message = String.Empty;
        public String Message
        {
            get => message;
            set
            {
                message = value;
                NotifyPropertyChanged();
            }
        }
        

        private VacationType selectedType;
        public VacationType SelectedType
        {
            get => selectedType;
            set
            {
                selectedType = value;
                NotifyPropertyChanged();
            }
        }
        
        public void SubmitVacationRequest()
        {
            Int32 id = MainWindowViewModel.vacationRequestRepo.GetRequestListCount();
            VacationRequest vacationRequest = new(id, StartDate.DateTime, EndDate.DateTime, SelectedType, Message);
            MainWindowViewModel.vacationRequestRepo.AddVacationRequest(vacationRequest);
        }
    }
}