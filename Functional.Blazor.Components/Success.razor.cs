using Microsoft.AspNetCore.Components;

namespace Functional.Blazor.Components
{
	/// <summary>
	/// Displays content if the result is successful. Context is set to the result's success value.
	/// </summary>
	/// <typeparam name="TSuccess">The Result's success type.</typeparam>
	/// <typeparam name="TFailure">The Result's failure type.</typeparam>
	public partial class Success<TSuccess, TFailure>
	{
		/// <summary>
		/// A Result&lt;TSuccess, TFailure&gt;
		/// </summary>
		[Parameter] public Result<TSuccess, TFailure> Result { get; set; }
		[Parameter] public RenderFragment<TSuccess> ChildContent { get; set; }
	}
}
