using WebUI.Models.Basics;

namespace WebUI.Services
{
    public sealed class ComponentStateService
    {
        public ComponentStateService(ComponentState componentState = ComponentState.Loading)
        {
            ComponentState = componentState;
        }

        private ComponentState ComponentState;

        internal void SetState(ComponentState componentState) => ComponentState = componentState;
        internal void SetContent() => ComponentState = ComponentState.Content;
        internal void SetLoading() => ComponentState = ComponentState.Loading;
        internal void SetError() => ComponentState = ComponentState.Error;
        internal ComponentState GetCurrentState() => ComponentState;
    }
}
