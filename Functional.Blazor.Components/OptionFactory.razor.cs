using Microsoft.AspNetCore.Components;
using System;

namespace Functional.Blazor.Components
{
	public partial class OptionFactory<TValue> : ComponentBase
	{
		[Parameter] public Func<Option<TValue>> Factory { get; set; }
		[Parameter] public RenderFragment<TValue> Some { get; set; }
		[Parameter] public RenderFragment None { get; set; }
		[Parameter] public bool InitializeWithValue { get; set; } = true;

		private Option<Option<TValue>> _innerOption = Option.None<Option<TValue>>();

		protected override void OnInitialized()
		{
			if (InitializeWithValue)
				_innerOption = Option.Some(Factory());
		}

		public void Refresh()
		{
			_innerOption = Option.Some(Factory());
		}
	}
}
