using Microsoft.AspNetCore.Components;

namespace WebUI.Components.Navs.Interfaces
{
    public interface INavItem
    {
        [Parameter] public string Text { get; set; }
        [Parameter] public string Icon { get; set; }
    }
}
