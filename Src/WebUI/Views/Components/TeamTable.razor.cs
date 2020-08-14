using Application.Teams.Queries;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using WebUI.Models.Basics;

namespace WebUI.Views.Components
{
    public partial class TeamTable : ComponentBase, IStatefulComponent
    {
        [Parameter] public IReadOnlyCollection<TeamListDto> Teams { get; set; }
        [CascadingParameter] public ComponentState ComponentState { get; set; }

        protected override void OnParametersSet()
        {
            VerifyParameters();
        }

        private void VerifyParameters()
        {
            try
            {
                Teams = Teams ?? throw new ArgumentNullException(nameof(Teams));
            }
            catch
            {
                ComponentState = ComponentState.Error;
                StateHasChanged();

                throw;
            
            }
        }
    }
}
