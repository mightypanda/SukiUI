using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Notifications;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using SukiUI.Controls;
using SukiUI.MessageBox;

using Avalonia.Media;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.VisualTree;
using System.Linq;
using Avalonia.Controls.Primitives;
using SukiUI.Controls.TouchInput.TouchNumericPad;

namespace SukiTest
{
    public enum Genders
    {
        Male, Female
    }
    public class Person
    {
        [Category("Data")]
        public string Name { get; set; } = "Charles";
        [Category("Data")]
        public int Age { get; set; } = 20;
        [Category("Data")]
        public bool Adult { get; set; } = true;

        public double JustADouble { get; set; } = 20;
        
        
        public bool Woman { get; set; } = false;
        public bool Man { get; set; } = true;

        public Genders Genre { get; set; } = Genders.Male;

        public Person Partner { get; set; } = null;

        public List<int> ListOfInts { get; set; } = new List<int>() { 1,2,3,4,5,6,7,8,9,10};
    }
    public partial class MainWindow : Window
    {
        private ObservableCollection<Person> liste { get; set; }= new ObservableCollection<Person>() {
            new Person(){Name = "jean", Age = 17, Adult = false}, new Person(){Name = "Anne", Age = 25, Woman = true, Man = false},
            new Person(){Name = "jean", Age = 17, Adult = false}, new Person(){Name = "Anne", Age = 25, Woman = true, Man = false}};

        private WindowNotificationManager notificationManager;
   

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                this.FindControl<DataGrid>("myDG").ItemsSource = liste;

                this.FindControl<Stepper>("stepstep").Steps = new ObservableCollection<string>() { "one", "two", "thre", "four", "five" };
                this.FindControl<Stepper>("stepstep").Index = 2;
           


                 this.FindControl<PropertyGrid>("propertyGrid").Item = new Person() { Adult = true, Age = 20,Name = "Billy", Partner = new Person() };

                 this.FindControl<ListBox>("listTest").ItemsSource = new ObservableCollection<string>() { "one", "two", "thre", "four", "five" };
                 
            }
            catch { }

           

#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void ShowInfoBox(object sender, RoutedEventArgs e)
        {
            MessageBox.Info(this, "Info", "Here is a random Information message");
            
            
        }

        private void ShowDialog(object sender, RoutedEventArgs e)
        {
           InteractiveContainer.ShowDialog(new DialogContent());
        }
        private void ShowSuccessBox(object sender, RoutedEventArgs e)
        {
          
            MessageBox.Success(this, "Congratulations", "Here is a random success message, youpee !", WindowStartupLocation.CenterScreen);
        }

        private void ShowDangerBox(object sender, RoutedEventArgs e)
        {
            MessageBox.Error(this, "Error", "This is an Error message that need to be read because it is dangerous to ... ");
        }

        private void ShowNotification(object sender, RoutedEventArgs e)
        {
            if(notificationManager == null)
                notificationManager = new WindowNotificationManager(this);
            
            try
            {
                var notif = new Avalonia.Controls.Notifications.Notification("title", "message");
                notificationManager.Position = NotificationPosition.BottomRight;
                notificationManager.Show(notif);


            }catch(Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        private void CloseHandler(object sender, RoutedEventArgs e)
        {
            Window hostWindow = (Window)this.VisualRoot;
            hostWindow.Close();
        }

        private void Button_OnClickProgress(object? sender, RoutedEventArgs e)
        {
            this.FindControl<CircleProgressBar>("myProgressBar").Value = 50; 
            this.FindControl<TextBlock>("TextPercent").Text =  "50"; 
        }

        private void Button_OnClickProgressBar(object? sender, RoutedEventArgs e)
        {
            this.FindControl<ProgressBar>("myProgressBarLine").Value = 60;
            this.FindControl<PercentProgressBar>("myPercentProgress").Value = 100;

        }
        private void Button_OnClick(object? sender, RoutedEventArgs e)
        {
            this.FindControl<Stepper>("stepstep").Index--;
        }

        private void nextStep(object? sender, RoutedEventArgs e)
        {
            this.FindControl<Stepper>("stepstep").Index++;
        }

        private void ButtonChangeOpacity(object? sender, RoutedEventArgs e)
        {
            var loading = this.FindControl<Loading>("MyLoading");
            loading.Opacity = Math.Abs(loading.Opacity - 1);
        }

        private int i = 1;
        private void ChangeTheme(object? sender, RoutedEventArgs e)
        {
            if(i%2 == 0)
                SukiUI.ColorTheme.LoadDarkTheme(Application.Current);
            else
                SukiUI.ColorTheme.LoadLightTheme(Application.Current);
            
            i++;
        }

        private void BusyMe(object? sender, RoutedEventArgs e)
        {
            this.FindControl<BusyArea>("myBusyArea").IsBusy = true;
        }

        private void GoTo50(object? sender, RoutedEventArgs e)
        {
            this.FindControl<PercentProgressBar>("myPercentProgress").Value = 50;
        }
    }
}