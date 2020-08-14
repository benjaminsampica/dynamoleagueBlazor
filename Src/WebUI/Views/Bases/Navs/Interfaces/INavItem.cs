using Microsoft.AspNetCore.Components;

namespace WebUI.Views.Bases.Navs.Interfaces
{
    public interface INavItem
    {
        [Parameter] public string Text { get; set; }
        [Parameter] public string Icon { get; set; }
    }
}
