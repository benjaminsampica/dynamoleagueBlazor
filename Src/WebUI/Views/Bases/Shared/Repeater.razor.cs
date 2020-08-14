using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace WebUI.Views.Bases.Shared
{
    public partial class Repeater<T> : ComponentBase
    {
        [Parameter]
        public IEnumerable<T> Items { get; set; }

        [Parameter]
        public RenderFragment<RenderFragment> RepeaterContainerTemplate { get; set; } = new RenderFragment<RenderFragment>(fragment => fragment);

        [Parameter]
        public RenderFragment<T> ItemTemplate { get; set; }

        [Parameter]
        public RenderFragment ItemSeparatorTemplate { get; set; }

        protected override void OnParametersSet()
        {
            ItemTemplate = ItemTemplate ?? throw new ArgumentNullException(nameof(ItemTemplate));
        }
    }
}
