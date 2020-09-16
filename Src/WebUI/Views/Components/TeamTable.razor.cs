using Application.Teams.Queries;
using MediatR;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebUI.Services;

namespace WebUI.Views.Components
{
    public partial class TeamTable : ComponentBase
    {
        [Inject] public ComponentStateService ComponentStateService { get; set; }
        [Inject] IMediator Mediator { get; set; }
        public IReadOnlyCollection<TeamListDto> Teams { get; set; } = Array.Empty<TeamListDto>();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await SetTeamsAsync();
                ComponentStateService.SetContent();
            }
            catch (Exception e)
            {
                e = e;
                ComponentStateService.SetError();
            }
        }

        private async Task SetTeamsAsync()
        {
            Teams = await Mediator.Send(new GetTeamsListQuery());
        }
    }
}
