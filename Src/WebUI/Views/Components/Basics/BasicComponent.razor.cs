using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Components;
using WebUI.Models.Basics;

namespace WebUI.Views.Components.Basics
{
    public partial class BasicComponent : ComponentBase, IStatefulComponent
    {
        [Parameter] public RenderFragment Loading { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public RenderFragment Error { get; set; }
        [CascadingParameter] public ComponentState ComponentState { get; set; }

        protected override void OnParametersSet()
        {
            try
            {
                VerifyParameters();
            }
            catch
            {
                ComponentState = ComponentState.Error;
                StateHasChanged();

                throw;
            }
        }

        internal void VerifyParameters()
        {
            Guard.Against.Null(ChildContent, nameof(ChildContent));
        }
    }
}
