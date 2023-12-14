using HolidayPlanner.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace HolidayPlanner.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string username = string.Empty;
        private string errorMsg = string.Empty;

        public ReactiveCommand<string, Unit> LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = ReactiveCommand.Create<string>(Login);
        }

        public void Login(string password)
        {
            Employee? user = MainViewModel.employeeRepo.GetEmployeeByUsername(Username);
            if ((user != null) && (password == user.Password))
            {
                App.MainViewModel.ContentViewModel = App.MainViewModel.ContentViewModels[1];
            }
            else
            {
                ErrorMsg = "Forkert login";
            }
        }

        public string Username
        {
            get => username;
            set { username = value; NotifyPropertyChanged(); }
        }

        public string ErrorMsg
        {
            get => errorMsg;
            set { errorMsg = value; NotifyPropertyChanged(); }
        }
    }
}
