using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Functional.Blazor.Components
{
	/// <summary>
	/// Loads and displays a result from a factory method. When the component's Refresh() method is called the factory method will be re-executed and content will be displayed for the new Task&lt;Result&lt;TSuccess, TFailure&gt;&gt;&gt;.
	/// </summary>
	/// <typeparam name="TSuccess">The Result's success type.</typeparam>
	/// <typeparam name="TFailure">The Result's failure type.</typeparam>
	public partial class ResultFactoryAsync<TSuccess, TFailure> : ComponentBase
	{
		/// <summary>
		/// A Func&lt;Task&lt;Result&lt;TSuccess, TFailure&gt;&gt;&gt;
		/// </summary>
		[Parameter] public Func<Task<Result<TSuccess, TFailure>>> Factory { get; set; }
		/// <summary>
		/// Render fragement of content to display if the Result is successful. Context is set to the option's value.
		/// </summary>
		[Parameter] public RenderFragment<TSuccess> Success { get; set; }
		/// <summary>
		/// Render fragement of content to display if the Result is failed. Context is set to the result's failure value.
		/// </summary>
		[Parameter] public RenderFragment<TFailure> Failure { get; set; }
		/// <summary>
		/// Render fragement of content to display if the current factory Task has not yet completed.
		/// </summary>
		[Parameter] public RenderFragment Loading { get; set; }
		/// <summary>
		/// If true then factory method will be executed upon component intialization. Otherwise the component will display blank content until its Refresh() method is called.
		/// </summary>
		[Parameter] public bool InitializeWithValue { get; set; } = true;
		
		private bool _isInitialized = false;
		private Option<Result<TSuccess, TFailure>> _innerResult = Option.None<Result<TSuccess, TFailure>>();
		private Task<Result<TSuccess, TFailure>> _task;

		protected override async Task OnInitializedAsync()
		{
			if (InitializeWithValue)
				await Refresh();
		}

		/// <summary>
		/// Refreshes the component with a new result task provided by the factory method.
		/// </summary>
		public async Task Refresh()
		{
			_isInitialized = true;
			var resultTask = Factory();
			_task = resultTask;
			_innerResult = Functional.Option.None<Result<TSuccess, TFailure>>();
			await resultTask;
			if (resultTask == _task)
				_innerResult = Functional.Option.Some(await resultTask);
		}
	}
}
