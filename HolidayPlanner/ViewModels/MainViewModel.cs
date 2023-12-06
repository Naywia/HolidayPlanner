using ReactiveUI;

namespace HolidayPlanner.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        private ViewModelBase contentViewModel;

        public MainViewModel()
        {
            contentViewModel = new LoginViewModel();
        }

        public ViewModelBase ContentViewModel
        {
            get => contentViewModel;
            set => this.RaiseAndSetIfChanged(ref contentViewModel, value);
        }
    }
}
