using CommunityToolkit.Mvvm.ComponentModel;
using ReactiveUI;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HolidayPlanner.ViewModels;

public abstract class ViewModelBase : ObservableObject, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
