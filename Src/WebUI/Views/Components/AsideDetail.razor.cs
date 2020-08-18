﻿using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Components;
using System;
using WebUI.Models.Basics;
using WebUI.Views.Bases.Navs;

namespace WebUI.Views.Components
{
    public partial class AsideDetail : ComponentBase
    {
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
            if (ChildContent == null && DetailsContent == null)
            {
                throw new ArgumentNullException(nameof(ChildContent), "Either ChildContent and DetailsContent must be supplied.");
            }
            Guard.Against.NullOrWhiteSpace(Title, nameof(Title));
            Guard.Against.NullOrWhiteSpace(ImageUrl, nameof(ImageUrl));
        }
    }
}
