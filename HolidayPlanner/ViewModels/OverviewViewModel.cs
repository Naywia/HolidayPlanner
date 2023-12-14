using HolidayPlanner.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayPlanner.ViewModels
{
    public class OverviewViewModel : ViewModelBase
    {
        private ObservableCollection<VacationRequest> requests;
        private string name = "Navn ikke fundet";

        public ObservableCollection<VacationRequest> Requests
        {
            get { return requests; }
            set { requests = value; }
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                NotifyPropertyChanged();
            }
        }

        public OverviewViewModel()
        {
            requests = MainWindowViewModel.employeeRepo.GetEmployeeVacationRequests(Session.Employee.Id);
            name = $"{Session.Employee.FirstName} {Session.Employee.LastName}";

            bool isLeader = true;
            if (isLeader)
            {

            }
        }
    }
}
