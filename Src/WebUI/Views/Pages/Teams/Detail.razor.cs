using Application.Teams.Queries;
using Ardalis.GuardClauses;
using MediatR;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using WebUI.Services;

namespace WebUI.Views.Pages.Teams
{
    public partial class Detail : ComponentBase
    {
        [Inject] public ComponentStateService ComponentStateService { get; set; }
        [Inject] private IMediator Mediator { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Parameter] public int Id { get; set; }

        private TeamDetailsDto ViewModel { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                VerifyParameters();
                await SetViewModelAsync();

                if (ViewModel == null)
                {
                    NavigationManager.NavigateTo("/NotFound");
                }
                ComponentStateService.SetContent();
            }
            catch
            {
                ComponentStateService.SetError();
            }

        }

        private void VerifyParameters()
        {
            Guard.Against.Default(Id, nameof(Id));
        }

        private async Task SetViewModelAsync()
        {
            ViewModel = await Mediator.Send(new GetTeamDetailsQuery(Id));
        }
    }
}
