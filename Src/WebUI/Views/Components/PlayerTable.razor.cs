using Application.Teams.Queries;
using Ardalis.GuardClauses;
using MediatR;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebUI.Models.Basics;

namespace WebUI.Views.Components
{
    public partial class PlayerTable : ComponentBase
    {
        [Inject] IMediator Mediator { get; set; }
        [Parameter] public int TeamId { get; set; }
        private readonly ComponentStateManager ComponentStateManager = new ComponentStateManager();
        private IReadOnlyCollection<PlayerListDto> Players { get; set; } = Array.Empty<PlayerListDto>();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await SetPlayersAsync();
            }
            catch
            {
                ComponentStateManager.SetError();
            }
        }

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
