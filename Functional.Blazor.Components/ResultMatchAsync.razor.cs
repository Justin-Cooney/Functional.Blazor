using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Functional.Blazor.Components
{
	/// <summary>
	/// Displays different content based on whether the task has succeeded, failed, or has not yet completed.
	/// </summary>
	/// <typeparam name="TSuccess">The Result's success type.</typeparam>
	/// <typeparam name="TFailure">The Result's failure type.</typeparam>
	public partial class ResultMatchAsync<TSuccess, TFailure> : ComponentBase
	{
		/// <summary>
		/// A Task&lt;Result&lt;TSuccess, TFailure&gt;&gt;
		/// </summary>
		[Parameter] public Task<Result<TSuccess, TFailure>> Result { get; set; }
		/// <summary>
		/// Render fragement of content to display if the Result is successful. Context is set to the option's value.
		/// </summary>
		[Parameter] public RenderFragment<TSuccess> Success { get; set; }
		/// <summary>
		/// Render fragement of content to display if the Result is failed. Context is set to the result's failure value.
		/// </summary>
		[Parameter] public RenderFragment<TFailure> Failure { get; set; }
		/// <summary>
		/// Render fragement of content to display if the Task has not yet completed.
		/// </summary>
		[Parameter] public RenderFragment Loading { get; set; }

		private Option<Result<TSuccess, TFailure>> _innerResult = Functional.Option.None<Result<TSuccess, TFailure>>();

		protected override Task OnInitializedAsync() => UpdateOption();

		protected override Task OnParametersSetAsync() => UpdateOption();

		private async Task UpdateOption()
		{
			var resultTask = Result;
			_innerResult = Functional.Option.None<Result<TSuccess, TFailure>>();
			await resultTask;
			if (resultTask == Result)
				_innerResult = Functional.Option.Some(await resultTask);
		}
	}
}
