using System.Collections.Generic;

namespace HolidayPlanner.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        private ViewModelBase contentViewModel;
        private List<ViewModelBase> contentViewModels = new();

        public MainViewModel()
        {
            contentViewModels.Add(new LoginViewModel());
            contentViewModels.Add(new MainViewViewModel());
            contentViewModel = contentViewModels[0];
        }

        public ViewModelBase ContentViewModel
        {
            get => contentViewModel;
            set
            {
                contentViewModel = value;
                NotifyPropertyChanged();
            }
        }

        public List<ViewModelBase> ContentViewModels
        {
            get { return contentViewModels; }
        }
    }
}
