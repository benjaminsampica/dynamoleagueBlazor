using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Components;
using WebUI.Services;

namespace WebUI.Views.Components
{
    public partial class InlineThumbnailWithText : ComponentBase
    {
        [Inject] public ComponentStateService ComponentStateService { get; set; }
        [Parameter] public string Name { get; set; }
        [Parameter] public string ThumbnailUrl { get; set; }

        protected override void OnInitialized()
        {
            try
            {
                VerifyParameters();
                ComponentStateService.SetContent();
            }
            catch
            {
                ComponentStateService.SetError();
            }
        }

        internal void VerifyParameters()
        {
            Guard.Against.NullOrWhiteSpace(Name, nameof(Name));
            Guard.Against.NullOrWhiteSpace(ThumbnailUrl, nameof(ThumbnailUrl));
        }
    }
}
