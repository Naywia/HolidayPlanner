using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayPlanner.ViewModels
{
    public class OverviewViewModel : ViewModelBase
    {
        private string title = "Oversigt over ferieønsker";
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
    }
}
