using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Functional.Blazor.Components
{
	/// <summary>
	/// Displays different content based on whether the task has some value, is empty, or has not yet completed.
	/// </summary>
	/// <typeparam name="TValue">Type of the Option's value</typeparam>
	public partial class OptionMatchAsync<TValue> : ComponentBase
	{
		/// <summary>
		/// A Task&lt;Option&lt;T&gt;&gt;
		/// </summary>
		[Parameter] public Task<Option<TValue>> Option { get; set; }
		/// <summary>
		/// Render fragement of content to display if the Option contains some value. Context is set to the option's value.
		/// </summary>
		[Parameter] public RenderFragment<TValue> Some { get; set; }
		/// <summary>
		/// Render fragement of content to display if the Option is empty.
		/// </summary>
		[Parameter] public RenderFragment None { get; set; }
		/// <summary>
		/// Render fragement of content to display if the Task has not yet completed.
		/// </summary>
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
