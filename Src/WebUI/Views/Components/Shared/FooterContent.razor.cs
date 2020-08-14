using Common;
using Microsoft.AspNetCore.Components;

namespace WebUI.Views.Components.Shared
{
    public partial class FooterContent : ComponentBase
    {
        [Inject] IDateTimeProvider DateTimeProvider { get; set; }

        private int CurrentYear { get; set; }

        protected override void OnInitialized()
        {
            CurrentYear = DateTimeProvider.Today.Year;
        }
    }
}
