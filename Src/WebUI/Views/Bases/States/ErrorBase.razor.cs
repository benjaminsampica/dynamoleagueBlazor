using Microsoft.AspNetCore.Components;

namespace WebUI.Views.Bases.States
{
    public partial class ErrorBase : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}