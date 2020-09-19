using Microsoft.AspNetCore.Components;

namespace Functional.Blazor.Components
{
	public partial class Failure<TSuccess, TFailure>
	{
		[Parameter] public Result<TSuccess, TFailure> Result { get; set; }
		[Parameter] public RenderFragment<TFailure> ChildContent { get; set; }
	}
}
