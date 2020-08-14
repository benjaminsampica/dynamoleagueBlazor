using Microsoft.AspNetCore.Components;
using System.Collections.Generic;


namespace WebUI.Views.Bases.Tables
{
    public partial class TableBase<T> : ComponentBase
    {
        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public IEnumerable<T> Items { get; set; }

        [Parameter]
        public RenderFragment HeaderColumns { get; set; }

        [Parameter]
        public RenderFragment<T> BodyColumns { get; set; }
    }
}
