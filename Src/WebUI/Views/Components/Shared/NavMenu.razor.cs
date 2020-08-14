using Microsoft.AspNetCore.Components;

namespace WebUI.Views.Components.Shared
{
    public partial class NavMenu : ComponentBase
    {
        private bool CollapseNavMenu = true;
        private string NavMenuCssClass => CollapseNavMenu ? "collapse" : null;

        private void ToggleNavMenu()
        {
            CollapseNavMenu = !CollapseNavMenu;
        }
    }
}
