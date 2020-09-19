using Microsoft.AspNetCore.Components;

namespace Functional.Blazor.Components
{
	public partial class ResultMatch<TSuccess, TFailure> : ComponentBase
	{
		[Parameter] public Result<TSuccess, TFailure> Result { get; set; }
		[Parameter] public RenderFragment<TSuccess> Success { get; set; }
		[Parameter] public RenderFragment<TFailure> Failure { get; set; }
	}
}
