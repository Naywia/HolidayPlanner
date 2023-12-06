using Avalonia.Controls;
using HolidayPlanner.ViewModels;

namespace HolidayPlanner.Views
{
    public partial class SidebarView : UserControl
    {
        public SidebarView()
        {
            InitializeComponent();
            DataContext = new SidebarViewModel();
        }
    }
}
