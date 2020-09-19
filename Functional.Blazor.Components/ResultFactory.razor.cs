using Microsoft.AspNetCore.Components;
using System;

namespace Functional.Blazor.Components
{
	public partial class ResultFactory<TSuccess, TFailure> : ComponentBase
	{
		[Parameter] public Func<Result<TSuccess, TFailure>> Factory { get; set; }
		[Parameter] public RenderFragment<TSuccess> Success { get; set; }
		[Parameter] public RenderFragment<TFailure> Failure { get; set; }
		[Parameter] public bool InitializeWithValue { get; set; } = true;

		private Option<Result<TSuccess, TFailure>> _innerResult = Option.None<Result<TSuccess, TFailure>>();

		protected override void OnInitialized()
		{
			if (InitializeWithValue)
				_innerResult = Option.Some(Factory());
		}

		public void Refresh()
		{
			_innerResult = Option.Some(Factory());
		}
	}
}
