using Avalonia.Controls;
using HolidayPlanner.ViewModels;

namespace HolidayPlanner.Views
{
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }
    }
}
