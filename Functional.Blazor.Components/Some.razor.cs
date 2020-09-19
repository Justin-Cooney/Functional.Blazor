using Microsoft.AspNetCore.Components;

namespace Functional.Blazor.Components
{
	/// <summary>
	/// Displays content if the option contains some value. Context is set to the option's value.
	/// </summary>
	/// <typeparam name="TValue">Type of the Option's value</typeparam>
	public partial class Some<TValue> : ComponentBase
	{
		/// <summary>
		/// An Option&lt;TValue&gt;
		/// </summary>
		[Parameter] public Option<TValue> Option { get; set; }
		[Parameter] public RenderFragment<TValue> ChildContent { get; set; }
	}
}
