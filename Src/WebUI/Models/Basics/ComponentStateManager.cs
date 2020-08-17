namespace WebUI.Models.Basics
{
    public sealed class ComponentStateManager
    {
        public ComponentStateManager(ComponentState componentState = ComponentState.Loading)
        {
            ComponentState = componentState;
        }

        private ComponentState ComponentState;

        internal void SetContent() => ComponentState = ComponentState.Content;
        internal void SetLoading() => ComponentState = ComponentState.Loading;
        internal void SetError() => ComponentState = ComponentState.Error;
        internal ComponentState GetCurrentState() => ComponentState;
    }
}
