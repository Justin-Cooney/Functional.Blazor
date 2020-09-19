using Microsoft.AspNetCore.Components;

namespace Functional.Blazor.Components
{
	/// <summary>
	/// Displays content if the option is empty.
	/// </summary>
	/// <typeparam name="TValue">Type of the Option's value</typeparam>
	public partial class None<TValue> : ComponentBase
	{
		/// <summary>
		/// An Option&lt;TValue&gt;
		/// </summary>
		[Parameter] public Option<TValue> Option { get; set; }
		[Parameter] public RenderFragment ChildContent { get; set; }
	}
}
