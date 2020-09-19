using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Functional.Blazor.Components
{
	/// <summary>
	/// Loads and displays an option from a factory method. When the component's Refresh() method is called the factory method will be re-executed and content will be displayed for the new Task&lt;Option&lt;T&gt;&gt;&gt;.
	/// </summary>
	/// <typeparam name="TValue">Type of the Option's value</typeparam>
	public partial class OptionFactoryAsync<TValue> : ComponentBase
	{
		/// <summary>
		/// A Func&lt;Task&lt;Option&lt;T&gt;&gt;&gt;
		/// </summary>
		[Parameter] public Func<Task<Option<TValue>>> Factory { get; set; }
		/// <summary>
		/// Render fragement of content to display if the Option contains some value. Context is set to the option's value.
		/// </summary>
		[Parameter] public RenderFragment<TValue> Some { get; set; }
		/// <summary>
		/// Render fragement of content to display if the Option is empty.
		/// </summary>
		[Parameter] public RenderFragment None { get; set; }
		/// <summary>
		/// Render fragement of content to display if the current factory Task has not yet completed.
		/// </summary>
		[Parameter] public RenderFragment Loading { get; set; }
		/// <summary>
		/// If true then factory method will be executed upon component intialization. Otherwise the component will display blank content until its Refresh() method is called.
		/// </summary>
		[Parameter] public bool InitializeWithValue { get; set; } = true;

		private bool _isInitialized = false;
		private Option<Option<TValue>> _innerOption = Option.None<Option<TValue>>();
		private Task<Option<TValue>> _task;

		protected override async Task OnInitializedAsync()
		{
			if (InitializeWithValue)
				await Refresh();
		}

		/// <summary>
		/// Refreshes the component with a new option task provided by the factory method.
		/// </summary>
		public async Task Refresh()
		{
			_isInitialized = true;
			var optionTask = Factory();
			_task = optionTask;
			_innerOption = Functional.Option.None<Option<TValue>>();
			await optionTask;
			if (optionTask == _task)
				_innerOption = Functional.Option.Some(await optionTask);
		}
	}
}
