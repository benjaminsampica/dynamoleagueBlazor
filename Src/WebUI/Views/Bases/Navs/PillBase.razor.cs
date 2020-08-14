using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using WebUI.Views.Bases.Navs.Interfaces;

namespace WebUI.Views.Bases.Navs
{
    public partial class PillBase : ComponentBase, INavItem
    {
        [Parameter] public string Text { get; set; }
        [Parameter] public string Icon { get; set; }
        [Parameter] public EventCallback<MouseEventArgs> OnClickEventCallback { get; set; }

        protected override void OnParametersSet()
        {
            VerifyParameters();
        }

        internal void VerifyParameters()
        {
            Guard.Against.NullOrWhiteSpace(Text, nameof(Text));
            Guard.Against.NullOrWhiteSpace(Icon, nameof(Icon));
        }
    }
}
