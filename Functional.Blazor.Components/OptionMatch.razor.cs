using Microsoft.AspNetCore.Components;

namespace Functional.Blazor.Components
{
	/// <summary>
	/// Displays different content based on whether the Option has some value or is empty.
	/// </summary>
	/// <typeparam name="TValue">Type of the Option's value</typeparam>
	public partial class OptionMatch<TValue> : ComponentBase
	{
		/// <summary>
		/// An Option&lt;T&gt;
		/// </summary>
		[Parameter] public Option<TValue> Option { get; set; }
		/// <summary>
		/// Render fragement of content to display if the Option contains some value. Context is set to the option's value.
		/// </summary>
		[Parameter] public RenderFragment<TValue> Some { get; set; }
		/// <summary>
		/// Render fragement of content to display if the Option is empty.
		/// </summary>
		[Parameter] public RenderFragment None { get; set; }
	}
}
