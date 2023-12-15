using System;
using System.Collections.Generic;
using HolidayPlanner.Models;
using ReactiveUI;

namespace HolidayPlanner.ViewModels
{
    public class VacationRequestViewModel : ViewModelBase
    {
        private List<VacationRequest> VacationRequests = MainWindowViewModel.vacationRequestRepo.GetVacationRequests();
        public List<VacationType> VacationTypes { get; set; } = MainWindowViewModel.vacationTypeRepo.GetVacationTypes();

        private DateTime startDate;
        public DateTime StartDate
        {
            get => startDate;
            set => this.RaiseAndSetIfChanged(ref startDate, value);
        }

        private DateTime endDate;
        public DateTime EndDate
        {
            get => endDate;
            set => this.RaiseAndSetIfChanged(ref endDate, value);
        }

        private String message = String.Empty;
        public String Message
        {
            get => message;
            set => this.RaiseAndSetIfChanged(ref message, value);
        }
        

        private VacationType selectedType;
        public VacationType SelectedType
        {
            get => selectedType;
            set => selectedType = value;
        }
        
        public void SubmitVacationRequest()
        {
            Int32 id = MainWindowViewModel.vacationRequestRepo.GetRequestListCount();
            VacationRequest vacationRequest = new(id, StartDate, EndDate, SelectedType, Message);
            MainWindowViewModel.vacationRequestRepo.AddVacationRequest(vacationRequest);
        }
    }
}