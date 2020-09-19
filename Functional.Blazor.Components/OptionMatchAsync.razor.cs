using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Functional.Blazor.Components
{
	public partial class OptionMatchAsync<TValue> : ComponentBase
	{
		[Parameter] public Task<Option<TValue>> Option { get; set; }
		[Parameter] public RenderFragment<TValue> Some { get; set; }
		[Parameter] public RenderFragment None { get; set; }
		[Parameter] public RenderFragment Loading { get; set; }

		private Option<Option<TValue>> _innerOption = Functional.Option.None<Option<TValue>>();

		protected override Task OnInitializedAsync() => UpdateOption();

		protected override Task OnParametersSetAsync() => UpdateOption();

		private async Task UpdateOption()
		{
			var optionTask = Option;
			_innerOption = Functional.Option.None<Option<TValue>>();
			await optionTask;
			if (optionTask == Option)
				_innerOption = Functional.Option.Some(await optionTask);
		}
	}
}
