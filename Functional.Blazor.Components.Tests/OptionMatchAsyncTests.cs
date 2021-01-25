using System.Threading.Tasks;
using Bunit;
using FluentAssertions;
using Xunit;

namespace Functional.Blazor.Components.Tests
{
	public class OptionMatchAsyncTests
	{
		private const string LOADING = "loading...";
		private const string VALUE = "the option holds a value";
		private const string NO_VALUE = "the option does not hold a value";

		[Fact]
		public void DisplaysLoadingWhenOptionTaskNotComplete()
		{
			using var context = new TestContext();
			var cut = context.RenderComponent<OptionMatchAsync<string>>(parameters => parameters
				.Add(c => c.Option, new Task<Option<string>>(() => Option.Some(VALUE)))
				.Add(c => c.Loading, $"<p>{LOADING}</p>")
				.Add(c => c.Some, s => $"<p>{s}</p>")
				.Add(c => c.None, $"<p>{NO_VALUE}</p>"));

			cut.Markup.Should().Contain(LOADING);
		}

		[Fact]
		public void DisplaysValueWhenOptionTaskIsCompleteAndOptionHasValue()
		{
			using var context = new TestContext();
			var cut = context.RenderComponent<OptionMatchAsync<string>>(parameters => parameters
				.Add(c => c.Option, Task.FromResult(Option.Some(VALUE)))
				.Add(c => c.Loading, $"<p>{LOADING}</p>")
				.Add(c => c.Some, s => $"<p>{s}</p>")
				.Add(c => c.None, $"<p>{NO_VALUE}</p>"));

			cut.Markup.Should().Contain(VALUE);
		}

		[Fact]
		public void DisplaysFallbackWhenOptionTaskIsCompleteAndOptionHasNoValue()
		{
			using var context = new TestContext();
			var cut = context.RenderComponent<OptionMatchAsync<string>>(parameters => parameters
				.Add(c => c.Option, Task.FromResult(Option.None<string>()))
				.Add(c => c.Loading, $"<p>{LOADING}</p>")
				.Add(c => c.Some, s => $"<p>{s}</p>")
				.Add(c => c.None, $"<p>{NO_VALUE}</p>"));

			cut.Markup.Should().Contain(NO_VALUE);
		}
	}
}