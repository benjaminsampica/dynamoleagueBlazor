using Microsoft.AspNetCore.Components;

namespace WebUI.Models.Basics
{
    public interface IStatefulComponent
    {
        /// <summary>
        ///     Components inheriting this should decorate it with a <see cref="ParameterAttribute"/> or <see cref="CascadingParameterAttribute"/> if not directly managing the state.
        /// </summary>
        abstract ComponentState ComponentState { get; set; }
    }
}
