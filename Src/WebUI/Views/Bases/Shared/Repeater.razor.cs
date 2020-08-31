using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace WebUI.Views.Bases.Shared
{
    public partial class Repeater<T> : ComponentBase
    {
        [Parameter] public IEnumerable<T> Items { get; set; }

        [Parameter] public RenderFragment<RenderFragment> RepeaterContainerTemplate { get; set; } = new RenderFragment<RenderFragment>(fragment => fragment);

        [Parameter] public RenderFragment<T> ItemTemplate { get; set; }

        protected override void OnInitialized()
        {
            VerifyParameters();
        }

        internal void VerifyParameters()
        {
            Guard.Against.Null(ItemTemplate, nameof(ItemTemplate));
            Guard.Against.Null(Items, nameof(Items));
        }
    }
}
