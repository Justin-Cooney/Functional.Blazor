using Microsoft.AspNetCore.Components;

namespace Functional.Blazor.Components
{
	public partial class Success<TSuccess, TFailure>
	{
		[Parameter] public Result<TSuccess, TFailure> Result { get; set; }
		[Parameter] public RenderFragment<TSuccess> ChildContent { get; set; }
	}
}
