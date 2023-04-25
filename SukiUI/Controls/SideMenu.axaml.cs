using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Material.Icons;
using System;
using System.Collections.Generic;
using Avalonia.VisualTree;
using System.Linq;
using Avalonia.Interactivity;

namespace SukiUI.Controls
{

    public partial class SideMenu : UserControl
    {
        public SideMenu()
        {
            InitializeComponent();
        }

        private void PaneIsClosing(object sender, CancelRoutedEventArgs ev)
        {
            ((SideMenuModel)this.DataContext).MenuVisibility = false;
        }

    }
}