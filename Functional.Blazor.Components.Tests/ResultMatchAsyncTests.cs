using System.Threading.Tasks;
using Bunit;
using FluentAssertions;
using Xunit;

namespace Functional.Blazor.Components.Tests
{
	public class ResultMatchAsyncTests
	{
		private const string LOADING = "loading...";
		private const int SUCCESS = 1337;
		private const string FAILURE = "error";

		[Fact]
		public void DisplaysSuccessValueWhenResultTaskIsNotComplete()
		{
			using var context = new TestContext();
			var cut = context.RenderComponent<ResultMatchAsync<int, string>>(parameters => parameters
				.Add(c => c.Result, new Task<Result<int, string>>(() => Result.Success<int, string>(SUCCESS)))
				.Add(c => c.Loading, $"<p>{LOADING}</p>")
				.Add(c => c.Success, i => $"<p>{i}</p>")
				.Add(c => c.Failure, s => $"<p>{s}</p>"));

			cut.Markup.Should().Contain(LOADING);
		}

		[Fact]
		public void DisplaysSuccessValueWhenResultTaskIsCompleteAndResultIsSuccess()
		{
			using var context = new TestContext();
			var cut = context.RenderComponent<ResultMatchAsync<int, string>>(parameters => parameters
				.Add(c => c.Result, Task.FromResult(Result.Success<int, string>(SUCCESS)))
				.Add(c => c.Loading, $"<p>{LOADING}</p>")
				.Add(c => c.Success, i => $"<p>{i}</p>")
				.Add(c => c.Failure, s => $"<p>{s}</p>"));

			cut.Markup.Should().Contain(SUCCESS.ToString());
		}

		[Fact]
		public void DisplaysFailureValueWhenResultTaskIsCompleteAndResultIsFaulted()
		{
			using var context = new TestContext();
			var cut = context.RenderComponent<ResultMatchAsync<int, string>>(parameters => parameters
				.Add(c => c.Result, Task.FromResult(Result.Failure<int, string>(FAILURE)))
				.Add(c => c.Loading, $"<p>{LOADING}</p>")
				.Add(c => c.Success, i => $"<p>{i}</p>")
				.Add(c => c.Failure, s => $"<p>{s}</p>"));

			cut.Markup.Should().Contain(FAILURE);
		}
	}
}