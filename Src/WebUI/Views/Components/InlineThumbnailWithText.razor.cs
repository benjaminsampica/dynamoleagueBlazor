using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Components;
using System;
using WebUI.Models.Basics;

namespace WebUI.Views.Components
{
    public partial class InlineThumbnailWithText : ComponentBase
    {
        [Parameter] public string Name { get; set; }
        [Parameter] public string ThumbnailUrl { get; set; }
        private readonly ComponentStateManager ComponentStateManager = new ComponentStateManager();

        protected override void OnParametersSet()
        {
            try
            {
                VerifyParameters();
                ComponentStateManager.SetContent();
            }
            catch
            {
                ComponentStateManager.SetError();
            }
        }

        internal void VerifyParameters()
        {
            Guard.Against.NullOrWhiteSpace(Name, nameof(Name));
            Guard.Against.NullOrWhiteSpace(ThumbnailUrl, nameof(ThumbnailUrl));
        }
    }
}
