namespace WebUI.Models.Basics
{
    public static class ComponentStateExtensions
    {
        public static bool HasError(this ComponentState componentState) => componentState == ComponentState.Error;
    }
}
