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

        private string title = "Oversigt over ferieønsker";
        private ObservableCollection<VacationRequest> requests;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public ObservableCollection<VacationRequest> Requests
        {
            get { return requests; }
            set { requests = value; }
        }

        public OverviewViewModel()
        {
            requests = MainViewModel.employeeRepo.GetEmployeeVacationRequests(1);

            bool isLeader = true;
            if (isLeader)
            {

            }
        }
    }
}
