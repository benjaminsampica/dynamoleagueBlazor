using Application.Teams.Queries;
using MediatR;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebUI.Models.Basics;

namespace WebUI.Views.Pages.Teams
{
    public partial class Index : ComponentBase, IStatefulComponent
    {
        [Inject] IMediator Mediator { get; set; }

        private IReadOnlyCollection<TeamListDto> Teams { get; set; }

        public ComponentState ComponentState { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await SetTeamsAsync();

                ComponentState = ComponentState.Content;
            }
            catch
            {
                ComponentState = ComponentState.Error;
                StateHasChanged();

                throw;
            }
        }

        private async Task SetTeamsAsync()
        {
            Teams = await Mediator.Send(new GetTeamsListQuery());
        }
    }
}
