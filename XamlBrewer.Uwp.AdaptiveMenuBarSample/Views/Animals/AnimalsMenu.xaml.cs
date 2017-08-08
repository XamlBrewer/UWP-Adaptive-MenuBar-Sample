using Mvvm;
using Mvvm.Services;
using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace XamlBrewer.Uwp.AdaptiveMenuBarSample
{
    /// <summary>
    /// A secondary menu to display all animals of the zodiac.
    /// </summary>
    public sealed partial class AnimalsMenu : UserControl
    {
        private WrapGrid _itemsPanel;

        public AnimalsMenu()
        {
            this.InitializeComponent();

            // Populate Menu.
            Menu.Items.Add(new MenuItem() { Glyph = Icon.GetIcon("AriesIcon"), Text = "Aries", NavigationDestination = typeof(AriesPage) });
            Menu.Items.Add(new MenuItem() { Glyph = Icon.GetIcon("CancerIcon"), Text = "Cancer", NavigationDestination = typeof(CancerPage) });
            Menu.Items.Add(new MenuItem() { Glyph = Icon.GetIcon("CapricornIcon"), Text = "Capricorn", NavigationDestination = typeof(CapricornPage) });
            Menu.Items.Add(new MenuItem() { Glyph = Icon.GetIcon("LeoIcon"), Text = "Leo", NavigationDestination = typeof(LeoPage) });
            Menu.Items.Add(new MenuItem() { Glyph = Icon.GetIcon("PiscesIcon"), Text = "Pisces", NavigationDestination = typeof(PiscesPage) });
            Menu.Items.Add(new MenuItem() { Glyph = Icon.GetIcon("ScorpioIcon"), Text = "Scorpio", NavigationDestination = typeof(ScorpioPage) });
            Menu.Items.Add(new MenuItem() { Glyph = Icon.GetIcon("TaurusIcon"), Text = "Taurus", NavigationDestination = typeof(TaurusPage) });

            // Animate Menu.
            GridView.RegisterImplicitAnimations();
        }

        /// <summary>
        /// Highlights the (first) menu item that corresponds to the page.
        /// </summary>
        /// <param name="pageType">Type of the page.</param>
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

        private void GridView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (_itemsPanel == null)
            {
                return;
            }

            // Only react to change in Width.
            if (e.NewSize.Width != e.PreviousSize.Width)
            {
                AdjustItemsPanel();
            }
        }

        private void ItemsPanel_Loaded(object sender, RoutedEventArgs e)
        {
            // Avoid walking the Visual Tree on each Size change.
            _itemsPanel = sender as WrapGrid;

            // Initialize itemsPanel.
            AdjustItemsPanel();
        }

        private void AdjustItemsPanel()
        {
            if (ActualWidth > 800)
            {
                // Two rows.
                _itemsPanel.ItemWidth = ActualWidth / 2;
                _itemsPanel.MinWidth = ActualWidth;
            }
            else
            {
                // One row.
                _itemsPanel.ItemWidth = ActualWidth;
                _itemsPanel.Width = ActualWidth;
            }
        }
    }
}
