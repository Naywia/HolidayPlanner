using Avalonia.Media;
using HolidayPlanner.Models;
using ReactiveUI;
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

            foreach (VacationRequest request in requests)
            {
                ObservableCollection<bool> bools = new ObservableCollection<bool>();
                foreach (string i in Enum.GetNames(typeof(VacationRequestState)))
                {
                    if (Enum.GetName(request.RequestStatus) == i)
                    {
                        bools.Add(true);
                    }
                    else
                    {
                        bools.Add(false);
                    }
                }
                requests[requests.IndexOf(request)].IsClass = bools;
            }

            bool isLeader = true;
            if (isLeader)
            {

            }
        }
    }
}
