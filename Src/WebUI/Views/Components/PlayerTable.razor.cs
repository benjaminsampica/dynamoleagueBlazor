using Application.Teams.Queries;
using Ardalis.GuardClauses;
using MediatR;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebUI.Services;

namespace WebUI.Views.Components
{
    public partial class PlayerTable : ComponentBase
    {
        [Inject] public ComponentStateService ComponentStateService { get; set; }
        [Inject] IMediator Mediator { get; set; }
        [Parameter] public int TeamId { get; set; }
        private IReadOnlyCollection<PlayerListDto> Players { get; set; } = Array.Empty<PlayerListDto>();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                VerifyParameters();
                await SetPlayersAsync();
                ComponentStateService.SetContent();
            }
            catch
            {
                ComponentStateService.SetError();
            }
        }

        private async Task SetPlayersAsync()
        {
            Players = await Mediator.Send(new GetPlayersListQuery(TeamId));
        }

        internal void VerifyParameters()
        {
            Guard.Against.Default(TeamId, nameof(TeamId));
        }
    }
}
