using Ardalis.GuardClauses;
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

        protected override void OnParametersSet()
        {
            VerifyParameters();
        }

        internal void VerifyParameters()
        {
            Guard.Against.NullOrEmpty(Title, nameof(Title));
            Guard.Against.Null(Items, nameof(Items));
            Guard.Against.Null(HeaderColumns, nameof(HeaderColumns));
            Guard.Against.Null(BodyColumns, nameof(BodyColumns));
        }
    }
}
