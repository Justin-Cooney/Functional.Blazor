using Microsoft.AspNetCore.Components;

namespace Functional.Blazor.Components
{
	public partial class OptionMatch<TValue> : ComponentBase
	{
		[Parameter] public Option<TValue> Option { get; set; }
		[Parameter] public RenderFragment<TValue> Some { get; set; }
		[Parameter] public RenderFragment None { get; set; }
	}
}
