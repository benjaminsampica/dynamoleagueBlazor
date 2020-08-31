using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Components;
using System;
using WebUI.Services;
using WebUI.Views.Bases.Navs;

namespace WebUI.Views.Components
{
    public partial class AsideDetail : ComponentBase
    {
        [Inject] public ComponentStateService ComponentStateService { get; set; }
        /// <summary>
        ///     Do not use this in tandem with <see cref="DetailsContent"/>.
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }
        /// <summary>
        ///     Do not use this in tandem with <see cref="ChildContent"/>.
        /// </summary>
        [Parameter] public RenderFragment DetailsContent { get; set; }
        [Parameter] public RenderFragment<PillBase> LinksContent { get; set; }
        [Parameter] public string Title { get; set; }
        [Parameter] public string ImageUrl { get; set; }

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
            if (ChildContent == null && DetailsContent == null)
            {
                throw new ArgumentNullException(nameof(ChildContent), "Either ChildContent and DetailsContent must be supplied.");
            }
            Guard.Against.NullOrWhiteSpace(Title, nameof(Title));
            Guard.Against.NullOrWhiteSpace(ImageUrl, nameof(ImageUrl));
        }
    }
}
