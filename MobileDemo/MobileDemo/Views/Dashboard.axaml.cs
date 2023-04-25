using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using SukiUI.Controls;
//using LiveChartsCore;
//using LiveChartsCore.SkiaSharpView;
//using LiveChartsCore.SkiaSharpView.Avalonia;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AndroidTest.Views
{
    public partial class Dashboard : UserControl
    {
        private static readonly Lazy<Dashboard> lazy =
            new Lazy<Dashboard>(() => new Dashboard());
        
        public static Dashboard Instance { get { return lazy.Value; } }
        public Dashboard()
        {
            InitializeComponent();

            this.myStep.Steps = new ObservableCollection<string>() { "Ordered", "Sent", "In Progress", "Delivered" };
            this.myStep.Index = 2;

			// this.FindControl<Stepper>("myStep").Steps = new ObservableCollection<string>() { "Ordered", "Sent", "In Progress", "Delivered" };
            // this.FindControl<Stepper>("myStep").Index = 2;

        }

        private void ShowFlyout(object sender, RoutedEventArgs e)
        {

            InteractiveContainer.ShowDialog(
                 new DialogContent()
            );



        }


        private void GoToSettings(object? sender, RoutedEventArgs e)
        {
            MobileStack.Push(new SettingsPage());
        }
    }
}
