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
        private ObservableCollection<VacationRequest> requests = new()
        {
            new(
                1,
                new DateTime(2022, 8, 8, 8, 0, 0),
                new DateTime(2022, 8, 26, 16, 0, 0),
                new VacationType (1, "Holiday"),
                "No Message"
            ),
            new(
                2,
                new DateTime(2022, 5, 6, 8, 0, 0),
                new DateTime(2022, 5, 8, 16, 0, 0),
                new VacationType(1, "Holiday"),
                "Sad days"
            ),
            new(
                2,
                new DateTime(2022, 5, 6, 8, 0, 0),
                new DateTime(2022, 5, 8, 16, 0, 0),
                new VacationType(1, "Holiday"),
                "No Message"
            ),
            new(
                3,
                new DateTime(2022, 5, 6, 8, 0, 0),
                new DateTime(2022, 5, 8, 16, 0, 0),
                new VacationType(1, "Holiday"),
                "No Message"
            ),
            new(
                4,
                new DateTime(2022, 5, 6, 8, 0, 0),
                new DateTime(2022, 5, 8, 16, 0, 0),
                new VacationType(1, "Holiday"),
                "No Message"
            ),
            new(
                5,
                new DateTime(2022, 5, 6, 8, 0, 0),
                new DateTime(2022, 5, 8, 16, 0, 0),
                new VacationType(1, "Holiday"),
                "No Message"
            )
        };
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
    }
}
