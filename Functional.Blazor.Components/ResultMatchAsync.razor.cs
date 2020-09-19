using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Functional.Blazor.Components
{
	public partial class ResultMatchAsync<TSuccess, TFailure> : ComponentBase
	{
		[Parameter] public Task<Result<TSuccess, TFailure>> Result { get; set; }
		[Parameter] public RenderFragment<TSuccess> Success { get; set; }
		[Parameter] public RenderFragment<TFailure> Failure { get; set; }
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
