using Microsoft.AspNetCore.Components;

namespace WebUI.Views.Bases.States
{
    public partial class LoadingBase : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
