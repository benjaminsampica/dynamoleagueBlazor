using Microsoft.AspNetCore.Components;

namespace WebUI.Views.Bases.Navs
{
    public partial class AnchorButtonBase : ComponentBase
    {
        [Parameter] public string OutlineClass { get; set; }
        [Parameter] public string Title { get; set; }
        [Parameter] public string Href { get; set; }
        [Parameter] public string Icon { get; set; }
        [Parameter] public string Text { get; set; }
    }
}
