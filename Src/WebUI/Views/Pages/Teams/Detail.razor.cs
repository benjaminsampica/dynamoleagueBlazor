using Application.Teams.Queries;
using Ardalis.GuardClauses;
using MediatR;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using WebUI.Models.Basics;

namespace WebUI.Views.Pages.Teams
{
    public partial class Detail : ComponentBase
    {
        [Inject] private IMediator Mediator { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Parameter] public int Id { get; set; }

        private readonly ComponentStateManager ComponentStateManager = new ComponentStateManager();
        private TeamDetailsDto ViewModel { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await SetViewModelAsync();

                if (ViewModel == null)
                {
                    NavigationManager.NavigateTo("/NotFound");
                }
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
