using Microsoft.AspNetCore.Components;

namespace Functional.Blazor.Components
{
	/// <summary>
	/// Displays different content based on whether the Result has succeeded or failed.
	/// </summary>
	/// <typeparam name="TSuccess">The Result's success type.</typeparam>
	/// <typeparam name="TFailure">The Result's failure type.</typeparam>
	public partial class ResultMatch<TSuccess, TFailure> : ComponentBase
	{
		/// <summary>
		/// A Result&lt;TSuccess, TFailure&gt;
		/// </summary>
		[Parameter] public Result<TSuccess, TFailure> Result { get; set; }
		/// <summary>
		/// Render fragement of content to display if the Result is successful. Context is set to the option's value.
		/// </summary>
		[Parameter] public RenderFragment<TSuccess> Success { get; set; }
		/// <summary>
		/// Render fragement of content to display if the Result is failed. Context is set to the result's failure value.
		/// </summary>
		[Parameter] public RenderFragment<TFailure> Failure { get; set; }
	}
}
