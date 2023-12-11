using System;
using System.Linq.Expressions;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace HolidayPlanner.Views;

public partial class MainView : UserControl
{
    private CalenderView calenderView = new();
    private VacationRequestView vacationRequestView = new();
    private Button? lastButton = null;
    public MainView()
    {
        InitializeComponent();
        viewbox.Child = vacationRequestView;
    }


    private void Button_OnClick(Object? sender, RoutedEventArgs e)
    {
        if (sender is not Button button) return;
        lastButton?.SetValue(BackgroundProperty, Brushes.Aqua);
        button.SetValue(BackgroundProperty, Brushes.Aquamarine);
        viewbox.Child = button.Content switch
        {
            "Kalender" => calenderView,
            // "Overblik" => OverviewView,
            "Ansøg om ferie" => vacationRequestView,
            _ => viewbox.Child
        };
        lastButton = button;
    }
}
