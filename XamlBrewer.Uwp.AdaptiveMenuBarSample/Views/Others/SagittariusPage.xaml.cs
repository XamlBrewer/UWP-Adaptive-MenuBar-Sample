using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace XamlBrewer.Uwp.AdaptiveMenuBarSample
{
    /// <summary>
    /// The Sagittarius details page.
    /// </summary>
    public sealed partial class SagittariusPage : Page
    {
        public SagittariusPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Send page type to menu.
            Menu.SetTab(GetType());
            base.OnNavigatedTo(e);
        }
    }
}
