using Application.Teams.Queries;
using MediatR;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace WebUI.Views.Pages.Teams
{
    public partial class Detail : ComponentBase
    {
        [Inject] private IMediator Mediator { get; }
        [Inject] private NavigationManager NavigationManager { get; }

        [Parameter] public int Id { get; set; }

        private TeamDetailsDto ViewModel { get; set; }

        protected override void OnParametersSet()
        {
            Id = Id != default ? Id : throw new ArgumentNullException(nameof(Id));
        }

        protected override async Task OnInitializedAsync()
        {
            ViewModel = await Mediator.Send(new GetTeamDetailsQuery(Id));
            if (ViewModel == null)
            {
                NavigationManager.NavigateTo("/404");
            }
        }
    }
}
