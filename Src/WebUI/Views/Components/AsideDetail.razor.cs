using Microsoft.AspNetCore.Components;
using System;
using WebUI.Models.Basics;
using WebUI.Views.Bases.Navs;

namespace WebUI.Views.Components
{
    public partial class AsideDetail : ComponentBase, IStatefulComponent
    {
        [CascadingParameter] public ComponentState ComponentState { get; set; }
        [Parameter] public RenderFragment DetailsContent { get; set; }
        [Parameter] public RenderFragment<PillBase> LinksContent { get; set; }
        [Parameter] public string Title { get; set; }
        [Parameter] public string ImageUrl { get; set; }

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
            DetailsContent = DetailsContent ?? throw new ArgumentNullException(nameof(DetailsContent));
            Title = Title ?? throw new ArgumentNullException(nameof(Title));
            ImageUrl = ImageUrl ?? throw new ArgumentNullException(nameof(ImageUrl));
        }
    }
}
