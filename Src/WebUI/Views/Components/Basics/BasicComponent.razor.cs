using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Components;
using WebUI.Models.Basics;
using WebUI.Services;

namespace WebUI.Views.Components.Basics
{
    public partial class BasicComponent : ComponentBase
    {
        [Inject] public ComponentStateService ComponentStateService { get; set; }
        [Parameter] public RenderFragment Loading { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public RenderFragment Error { get; set; }
        [Parameter] public ComponentState ParentComponentState { get; set; }

        protected override void OnParametersSet()
        {
            ComponentStateService.SetState(ParentComponentState);
            if (!ParentComponentState.HasError())
            {
                try
                {
                    VerifyInternalParameters();
                }
                catch
                {
                    ComponentStateService.SetError();

                    StateHasChanged();
                }
            }
        }

        protected void VerifyInternalParameters()
        {
            Guard.Against.Null(ChildContent, nameof(ChildContent));
        }
    }
}
