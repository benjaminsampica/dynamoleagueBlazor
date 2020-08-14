using Microsoft.AspNetCore.Components;
using System;
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

        private void VerifyParameters()
        {
            Name = Name ?? throw new ArgumentNullException(nameof(Name));
            ThumbnailUrl = ThumbnailUrl ?? throw new ArgumentNullException(nameof(ThumbnailUrl));
        }
    }
}
