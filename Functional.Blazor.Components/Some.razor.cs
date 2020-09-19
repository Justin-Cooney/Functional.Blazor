using Microsoft.AspNetCore.Components;

namespace Functional.Blazor.Components
{
	public partial class Some<TValue> : ComponentBase
	{
		[Parameter] public Option<TValue> Option { get; set; }
		[Parameter] public RenderFragment<TValue> ChildContent { get; set; }
	}
}
