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
        private string username;
        private string username_temp = "oln";
        private string password = "temp";
        private string errorMsg = string.Empty;
        public ReactiveCommand<string, Unit> LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = ReactiveCommand.Create<string>(Login);
        }

        public void Login(string password)
        {
            if ((Username == username_temp) && (password == this.password))
            {
                // Set viewmodel here.
            }
            else
            {
                ErrorMsg = "Forkert login";
            }
        }

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                NotifyPropertyChanged();
            }
        }

        public string ErrorMsg
        {
            get
            {
                return errorMsg;
            }
            set
            {
                errorMsg = value;
                NotifyPropertyChanged();
            }
        }
    }
}
