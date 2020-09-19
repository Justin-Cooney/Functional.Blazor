using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Functional.Blazor.Components
{
	public partial class ResultFactoryAsync<TSuccess, TFailure> : ComponentBase
	{
		[Parameter] public Func<Task<Result<TSuccess, TFailure>>> Factory { get; set; }
		[Parameter] public RenderFragment<TSuccess> Success { get; set; }
		[Parameter] public RenderFragment<TFailure> Failure { get; set; }
		[Parameter] public RenderFragment Loading { get; set; }
		[Parameter] public bool InitializeWithValue { get; set; } = true;

		private Option<Result<TSuccess, TFailure>> _innerResult = Option.None<Result<TSuccess, TFailure>>();
		private Task<Result<TSuccess, TFailure>> _task;

		protected override async Task OnInitializedAsync()
		{
			if (InitializeWithValue)
				await Refresh();
		}

		public async Task Refresh()
		{
			var resultTask = Factory();
			_task = resultTask;
			_innerResult = Functional.Option.None<Result<TSuccess, TFailure>>();
			await resultTask;
			if (resultTask == _task)
				_innerResult = Functional.Option.Some(await resultTask);
		}
	}
}
