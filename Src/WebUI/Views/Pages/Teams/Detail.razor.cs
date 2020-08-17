using Application.Teams.Queries;
using MediatR;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using WebUI.Models.Basics;

namespace WebUI.Views.Pages.Teams
{
    public partial class Detail : ComponentBase
    {
        [Inject] private IMediator Mediator { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }

        [Parameter] public int Id { get; set; }

        public ComponentState ComponentState { get; set; }

        private TeamDetailsDto ViewModel { get; set; }

        protected override void OnParametersSet()
        {
            Id = Id != default ? Id : throw new ArgumentNullException(nameof(Id));
        }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await SetViewModelAsync();

                if (ViewModel == null)
                {
                    NavigationManager.NavigateTo("/NotFound");
                }
                else
                {
                    ComponentState = ComponentState.Content;
                }
            }
            catch
            {
                ComponentState = ComponentState.Error;
                StateHasChanged();

                throw;
            }

        }

        private async Task SetViewModelAsync()
        {
            ViewModel = await Mediator.Send(new GetTeamDetailsQuery(Id));
        }
    }
}
