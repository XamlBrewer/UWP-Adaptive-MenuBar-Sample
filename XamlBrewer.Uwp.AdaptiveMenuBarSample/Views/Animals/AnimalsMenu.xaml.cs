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
    public sealed partial class AnimalsMenu : UserControl
    {
        private WrapGrid _vsw;

        public AnimalsMenu()
        {
            this.InitializeComponent();
            Menu.Items.Add(new MenuItem()
            {
                Glyph = Icon.GetIcon("AriesIcon"),
                Text = "Aries",
                NavigationDestination = typeof(AriesPage)
            });
            Menu.Items.Add(new MenuItem() { Glyph = Icon.GetIcon("CancerIcon"), Text = "Cancer", NavigationDestination = typeof(CancerPage) });
            Menu.Items.Add(new MenuItem() { Glyph = Icon.GetIcon("CapricornIcon"), Text = "Capricorn", NavigationDestination = typeof(CapricornPage) });
            Menu.Items.Add(new MenuItem() { Glyph = Icon.GetIcon("LeoIcon"), Text = "Leo", NavigationDestination = typeof(LeoPage) });
            Menu.Items.Add(new MenuItem() { Glyph = Icon.GetIcon("PiscesIcon"), Text = "Pisces", NavigationDestination = typeof(PiscesPage) });
            Menu.Items.Add(new MenuItem() { Glyph = Icon.GetIcon("ScorpioIcon"), Text = "Scorpio", NavigationDestination = typeof(ScorpioPage) });
            Menu.Items.Add(new MenuItem() { Glyph = Icon.GetIcon("TaurusIcon"), Text = "Taurus", NavigationDestination = typeof(TaurusPage) });

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
