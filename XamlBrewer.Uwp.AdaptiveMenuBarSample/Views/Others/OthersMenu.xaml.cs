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
    public sealed partial class OthersMenu : UserControl
    {
        private WrapGrid _vsw;

        public OthersMenu()
        {
            this.InitializeComponent();
            Menu.Items.Add(new MenuItem()
            {
                Glyph = Icon.GetIcon("AquariusIcon"),
                Text = "Aquarius",
                NavigationDestination = typeof(AquariusPage)
            });
            Menu.Items.Add(new MenuItem() { Glyph = Icon.GetIcon("GeminiIcon"), Text = "Gemini", NavigationDestination = typeof(GeminiPage) });
            Menu.Items.Add(new MenuItem() { Glyph = Icon.GetIcon("LibraIcon"), Text = "Libra", NavigationDestination = typeof(LibraPage) });
            Menu.Items.Add(new MenuItem() { Glyph = Icon.GetIcon("SagittariusIcon"), Text = "Sagittarius", NavigationDestination = typeof(SagittariusPage) });
            Menu.Items.Add(new MenuItem() { Glyph = Icon.GetIcon("VirgoIcon"), Text = "Virgo", NavigationDestination = typeof(VirgoPage) });

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

            // Only react to change in Width.
            if (e.NewSize.Width != e.PreviousSize.Width)
            {
                AdjustItemTemplate();
            }
        }

        private void VSW_Loaded(object sender, RoutedEventArgs e)
        {
            // Avoid walking the Visual Tree on each Size change.
            _vsw = sender as WrapGrid;

            // Initialize item template.
            AdjustItemTemplate();
        }

        private void AdjustItemTemplate()
        {
            if (ActualWidth > 800)
            {
                _vsw.ItemWidth = ActualWidth / 2;
                _vsw.MinWidth = ActualWidth;
            }
            else
            {
                _vsw.ItemWidth = ActualWidth;
                _vsw.Width = ActualWidth;
            }
        }
    }
}
