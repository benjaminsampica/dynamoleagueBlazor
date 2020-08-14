using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Components;
using WebUI.Models.Basics;

namespace WebUI.Views.Components
{
    public partial class InlineThumbnailWithText : ComponentBase, IStatefulComponent
    {
        [CascadingParameter] public ComponentState ComponentState { get; set; }
        [Parameter] public string Name { get; set; }
        [Parameter] public string ThumbnailUrl { get; set; }

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
            Name = Guard.Against.NullOrWhiteSpace(Name, nameof(Name)); ;
            ThumbnailUrl = Guard.Against.NullOrWhiteSpace(ThumbnailUrl, nameof(ThumbnailUrl)); ;
        }
    }
}
