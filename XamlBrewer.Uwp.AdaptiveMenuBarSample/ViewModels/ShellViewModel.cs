using Mvvm.Services;
using XamlBrewer.Uwp.AdaptiveMenuBarSample;

namespace Mvvm
{
    internal class ShellViewModel : ViewModelBase
    {
        public ShellViewModel()
        {
            // Build the menus
            Menu.Add(new MenuItem() { Glyph = Icon.GetIcon("SevenDotsIcon"), Text = "Animals", NavigationDestination = typeof(AnimalsPage) });
            Menu.Add(new MenuItem() { Glyph = Icon.GetIcon("FiveDotsIcon"), Text = "Others", NavigationDestination = typeof(OthersPage) });

            SecondMenu.Add(new MenuItem() { Glyph = Icon.GetIcon("InfoIcon"), Text = "About", NavigationDestination = typeof(AboutPage) });
        }
    }
}
