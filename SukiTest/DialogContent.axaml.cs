using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using SukiUI.Controls;

namespace SukiTest
{
    public partial class DialogContent : UserControl
    {
        public DialogContent()
        {
            InitializeComponent();
        }

        private void CloseDialog(object sender, RoutedEventArgs e)
        {
            InteractiveContainer.CloseDialog();
        }
    }
}
