using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace XamlBrewer.Uwp.AdaptiveMenuBarSample
{
    /// <summary>
    /// The Gemini details page.
    /// </summary>
    public sealed partial class GeminiPage : Page
    {
        public GeminiPage()
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
