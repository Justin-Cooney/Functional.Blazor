using Bunit;
using FluentAssertions;
using Xunit;

namespace Functional.Blazor.Components.Tests
{
	public class ResultMatchTests
	{
		private const int SUCCESS = 1337;
		private const string FAILURE = "error";

		[Fact]
		public void DisplaysSuccessValueWhenResultIsSuccess()
		{
			using var context = new TestContext();
			var cut = context.RenderComponent<ResultMatch<int, string>>(parameters => parameters
				.Add(c => c.Result, Result.Success<int, string>(SUCCESS))
				.Add(c => c.Success, i => $"<p>{i}</p>")
				.Add(c => c.Failure, s => $"<p>{s}</p>"));

			cut.Markup.Should().Contain(SUCCESS.ToString());
		}

		[Fact]
		public void DisplaysFailureValueWhenResultIsFaulted()
		{
			using var context = new TestContext();
			var cut = context.RenderComponent<ResultMatch<int, string>>(parameters => parameters
				.Add(c => c.Result, Result.Failure<int, string>(FAILURE))
				.Add(c => c.Success, i => $"<p>{i}</p>")
				.Add(c => c.Failure, s => $"<p>{s}</p>"));

			cut.Markup.Should().Contain(FAILURE);
		}
	}
}