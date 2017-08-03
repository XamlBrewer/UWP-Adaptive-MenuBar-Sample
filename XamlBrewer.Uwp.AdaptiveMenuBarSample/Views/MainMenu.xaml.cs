using Mvvm;
using Mvvm.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace XamlBrewer.Uwp.AdaptiveMenuBarSample
{
    public sealed partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            this.InitializeComponent();
            Menu.Items.Add(new MenuItem()
            {
                Glyph = Icon.GetIcon("DialogIcon"),
                Text = "Index",
                NavigationDestination = typeof(MainPage)
            });
            Menu.Items.Add(new MenuItem() { Glyph = Icon.GetIcon("DialogIcon"), Text = "Catalog", NavigationDestination = typeof(MainPage) });
            Menu.Items.Add(new MenuItem() { Glyph = Icon.GetIcon("DialogIcon"), Text = "Grain Bill", NavigationDestination = typeof(MainPage2) });
            Menu.Items.Add(new MenuItem() { Glyph = Icon.GetIcon("DialogIcon"), Text = "Catalog", NavigationDestination = typeof(MainPage) });
            Menu.Items.Add(new MenuItem() { Glyph = Icon.GetIcon("DialogIcon"), Text = "Grain Bill", NavigationDestination = typeof(MainPage2) });
            Menu.Items.Add(new MenuItem() { Glyph = Icon.GetIcon("DialogIcon"), Text = "Catalog", NavigationDestination = typeof(MainPage) });
            Menu.Items.Add(new MenuItem() { Glyph = Icon.GetIcon("DialogIcon"), Text = "Grain Bill", NavigationDestination = typeof(MainPage2) });
        }

        public void SetTab(Type pageType)
        {
            // Lookup destination type in menu(s)
            var item = (from i in Menu.Items
                        where (i as MenuItem).NavigationDestination == pageType
                        select i).FirstOrDefault();
            if (item != null)
            {
                Menu.SelectedItem = item;
            }
            else
            {
                Menu.SelectedIndex = -1;
            }
        }

        private void Menu_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.First() is MenuItem menuItem && menuItem.IsNavigation)
            {
                Navigation.Navigate(menuItem.NavigationDestination);
            }
        }
    }
}
