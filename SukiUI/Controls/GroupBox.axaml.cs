using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SukiUI.Controls
{
    public partial class GroupBox : UserControl
    {
        public GroupBox()
        {
            InitializeComponent();
        }

        public static readonly StyledProperty<string> HeaderProperty =
        AvaloniaProperty.Register<CircleProgressBar, string>(nameof(Header), defaultValue: "Header");

        public string Header
        {
            get { return GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value ); }
        }
    }
}
