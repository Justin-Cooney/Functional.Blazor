using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Functional.Blazor.Components
{
	public partial class OptionFactoryAsync<TValue> : ComponentBase
	{
		[Parameter] public Func<Task<Option<TValue>>> Factory { get; set; }
		[Parameter] public RenderFragment<TValue> Some { get; set; }
		[Parameter] public RenderFragment None { get; set; }
		[Parameter] public RenderFragment Loading { get; set; }
		[Parameter] public bool InitializeWithValue { get; set; } = true;

		private Option<Option<TValue>> _innerOption = Option.None<Option<TValue>>();
		private Task<Option<TValue>> _task;

		protected override async Task OnInitializedAsync()
		{
			if (InitializeWithValue)
				await Refresh();
		}

		public async Task Refresh()
		{
			var optionTask = Factory();
			_task = optionTask;
			_innerOption = Functional.Option.None<Option<TValue>>();
			await optionTask;
			if (optionTask == _task)
				_innerOption = Functional.Option.Some(await optionTask);
		}
	}
}
