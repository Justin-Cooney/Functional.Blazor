using Microsoft.AspNetCore.Components;
using System;

namespace Functional.Blazor.Components
{
	/// <summary>
	/// Loads and displays an option from a factory method. When the component's Refresh() method is called the factory method will be re-executed and content will be displayed for the new Option&lt;T&gt;&gt;.
	/// </summary>
	/// <typeparam name="TValue">Type of the Option's value</typeparam>
	public partial class OptionFactory<TValue> : ComponentBase
	{
		/// <summary>
		/// A Func&lt;Option&lt;T&gt;&gt;
		/// </summary>
		[Parameter] public Func<Option<TValue>> Factory { get; set; }
		/// <summary>
		/// Render fragement of content to display if the Option contains some value. Context is set to the option's value.
		/// </summary>
		[Parameter] public RenderFragment<TValue> Some { get; set; }
		/// <summary>
		/// Render fragement of content to display if the Option is empty.
		/// </summary>
		[Parameter] public RenderFragment None { get; set; }
		/// <summary>
		/// If true then factory method will be executed upon component intialization. Otherwise the component will display blank content until its Refresh() method is called.
		/// </summary>
		[Parameter] public bool InitializeWithValue { get; set; } = true;

		private Option<Option<TValue>> _innerOption = Option.None<Option<TValue>>();

		protected override void OnInitialized()
		{
			if (InitializeWithValue)
				_innerOption = Option.Some(Factory());
		}

		/// <summary>
		/// Refreshes the component with a new option provided by the factory method.
		/// </summary>
		public void Refresh()
		{
			_innerOption = Option.Some(Factory());
		}
	}
}
