using Microsoft.AspNetCore.Components;
using System;

namespace Functional.Blazor.Components
{
	/// <summary>
	/// Loads and displays a result from a factory method. When the component's Refresh() method is called the factory method will be re-executed and content will be displayed for the new Result&lt;TSuccess, TFailure&gt;.
	/// </summary>
	/// <typeparam name="TSuccess">The Result's success type.</typeparam>
	/// <typeparam name="TFailure">The Result's failure type.</typeparam>
	public partial class ResultFactory<TSuccess, TFailure> : ComponentBase
	{
		/// <summary>
		/// A Func&lt;Result&lt;TSuccess, TFailure&gt;&gt;
		/// </summary>
		[Parameter] public Func<Result<TSuccess, TFailure>> Factory { get; set; }
		/// <summary>
		/// Render fragement of content to display if the Result is successful. Context is set to the option's value.
		/// </summary>
		[Parameter] public RenderFragment<TSuccess> Success { get; set; }
		/// <summary>
		/// Render fragement of content to display if the Result is failed. Context is set to the result's failure value.
		/// </summary>
		[Parameter] public RenderFragment<TFailure> Failure { get; set; }
		/// <summary>
		/// If true then factory method will be executed upon component intialization. Otherwise the component will display blank content until its Refresh() method is called.
		/// </summary>
		[Parameter] public bool InitializeWithValue { get; set; } = true;

		private Option<Result<TSuccess, TFailure>> _innerResult = Option.None<Result<TSuccess, TFailure>>();

		protected override void OnInitialized()
		{
			if (InitializeWithValue)
				_innerResult = Option.Some(Factory());
		}

		/// <summary>
		/// Refreshes the component with a new result provided by the factory method.
		/// </summary>
		public void Refresh()
		{
			_innerResult = Option.Some(Factory());
		}
	}
}
