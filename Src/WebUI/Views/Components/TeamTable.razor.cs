using Application.Teams.Queries;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using WebUI.Models.Basics;

namespace WebUI.Views.Components
{
    public partial class TeamTable : ComponentBase, IStatefulComponent
    {
        [CascadingParameter] public ComponentState ComponentState { get; set; }
        [Parameter] public IReadOnlyCollection<TeamListDto> Teams { get; set; }

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

        internal void VerifyParameters()
        {
            Guard.Against.NullOrEmpty(Teams, nameof(Teams));
        }
    }
}
