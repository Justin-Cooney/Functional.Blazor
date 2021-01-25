using System;
using Bunit;
using FluentAssertions;
using Xunit;

namespace Functional.Blazor.Components.Tests
{
	public class OptionMatchTests
	{
		private const string VALUE = "the option holds a value";
		private const string NO_VALUE = "the option does not hold a value";

		[Fact]
		public void DisplaysValueWhenOptionHasValue()
		{
			using var context = new TestContext();
			var cut = context.RenderComponent<OptionMatch<string>>(parameters => parameters
				.Add(c => c.Option, Option.Some(VALUE))
				.Add(c => c.Some, s => $"<p>{s}</p>")
				.Add(c => c.None, $"<p>{NO_VALUE}</p>"));

			cut.Markup.Should().Contain(VALUE);
		}

		[Fact]
		public void DisplaysFallbackWhenOptionHasNoValue()
		{
			using var context = new TestContext();
			var cut = context.RenderComponent<OptionMatch<string>>(parameters => parameters
				.Add(c => c.Option, Option.None<string>())
				.Add(c => c.Some, s => $"<p>{s}</p>")
				.Add(c => c.None, $"<p>{NO_VALUE}</p>"));

			cut.Markup.Should().Contain(NO_VALUE);
		}
	}
}
