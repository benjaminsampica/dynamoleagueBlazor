using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Components;
using WebUI.Models.Basics;

namespace WebUI.Views.Components.Basics
{
    public partial class BasicComponent : ComponentBase
    {
        [Parameter] public RenderFragment Loading { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public RenderFragment Error { get; set; }
        [Parameter] public ComponentState ParentComponentState { get; set; }
        private ComponentStateManager ComponentStateManager;

        protected override void OnParametersSet()
        {
            ComponentStateManager = new ComponentStateManager(ParentComponentState);
            if (!ParentComponentState.HasError())
            {
                try
                {
                    VerifyInternalParameters();
                }
                catch
                {
                    ComponentStateManager.SetError();
                    
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
