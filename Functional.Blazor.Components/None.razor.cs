using Microsoft.AspNetCore.Components;

namespace Functional.Blazor.Components
{
	public partial class None<TValue> : ComponentBase
	{
		[Parameter] public Option<TValue> Option { get; set; }
		[Parameter] public RenderFragment ChildContent { get; set; }
	}
}
