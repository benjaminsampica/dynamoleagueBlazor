using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Components;
using WebUI.Views.Bases.Navs.Interfaces;

namespace WebUI.Views.Bases.Navs
{
    public partial class AnchorButtonBase : ComponentBase, INavItem
    {
        [Parameter] public string OutlineClass { get; set; }
        [Parameter] public string Title { get; set; }
        [Parameter] public string Href { get; set; }
        [Parameter] public string Icon { get; set; }
        [Parameter] public string Text { get; set; }

        internal string GetMargin() => string.IsNullOrWhiteSpace(Text) ? string.Empty : "mr-1";

        protected override void OnParametersSet()
        {
            VerifyParameters();
        }

        internal void VerifyParameters()
        {
            OutlineClass = Guard.Against.NullOrWhiteSpace(OutlineClass, nameof(OutlineClass));
            Title = Guard.Against.NullOrWhiteSpace(Title, nameof(Title));
            Href = Guard.Against.NullOrWhiteSpace(Href, nameof(Href));
            Icon = Guard.Against.NullOrWhiteSpace(Icon, nameof(Icon));
        }
    }
}
