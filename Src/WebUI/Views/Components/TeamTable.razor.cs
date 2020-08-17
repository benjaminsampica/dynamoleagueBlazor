using Application.Teams.Queries;
using MediatR;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebUI.Models.Basics;

namespace WebUI.Views.Components
{
    public partial class TeamTable : ComponentBase
    {
        [Inject] IMediator Mediator { get; set; }
        public IReadOnlyCollection<TeamListDto> Teams { get; set; } = Array.Empty<TeamListDto>();
        private readonly ComponentStateManager ComponentStateManager = new ComponentStateManager();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await SetTeamsAsync();
                ComponentStateManager.SetContent();
            }
            catch
            {
                ComponentStateManager.SetError();
            }
        }

        private async Task SetTeamsAsync()
        {
            Teams = await Mediator.Send(new GetTeamsListQuery());
        }
    }
}
