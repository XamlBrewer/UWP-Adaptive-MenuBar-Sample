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
        private WrapGrid _vsw;

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
            // Menu.Items.Add(new MenuItem() { Glyph = Icon.GetIcon("DialogIcon"), Text = "Grain Bill", NavigationDestination = typeof(MainPage2) });

            StackPanel.RegisterImplicitAnimations();
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

        private void StackPanel_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (_vsw == null)
            {
                return;
            }

            if (e.NewSize.Width != e.PreviousSize.Width)
            {
                // Only react on change in Width.
                if (e.NewSize.Width > 800)
                {
                    _vsw.ItemWidth = e.NewSize.Width / 2;
                }
                else
                {
                    _vsw.ItemWidth = e.NewSize.Width;
                }

                //Title.Width = _vsw.ItemWidth;
            }
        }

        private void VSW_Loaded(object sender, RoutedEventArgs e)
        {
            // Avoid walking the Visual Tree on each Size change.
            _vsw = sender as WrapGrid;
        }
    }
}
