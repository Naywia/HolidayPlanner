using Avalonia.Controls;
using HolidayPlanner.ViewModels;

namespace HolidayPlanner.Views
{
    public partial class OverviewView : UserControl
    {
        public OverviewView()
        {
            InitializeComponent();
            DataContext = new OverviewViewModel();
        }
    }
}
