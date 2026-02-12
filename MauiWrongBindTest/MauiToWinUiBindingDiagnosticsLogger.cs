// MauiToWinUiBindingDiagnosticsLogger.cs

using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;

namespace MauiWrongBindTest;

partial class MauiToWinUiBindingDiagnosticsLogger : ILogger
{
	[GeneratedRegex(@"^'(.*?)' property not found on '(.*?)', target property: '(.*)\.(.*?)'$")]
	public static partial Regex MauiBindingDiagnosticsRegex();
	public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
	{
		if (state?.ToString() is string msg && MauiBindingDiagnosticsRegex().Match(msg) is Match match && match.Success)
		{
			string sourcePath = match.Groups[1].Value;
			string sourceType = match.Groups[2].Value;
			string targetType = match.Groups[3].Value;
			string targetProperty = match.Groups[4].Value;
			System.Diagnostics.Debug.WriteLine(new StringBuilder()
				.Append("Error: BindingExpression path error: '")
				.Append(sourcePath)
				.Append("' property not found on '")
				.Append(sourceType)
				.Append("'. BindingExpression: Path='")
				.Append(sourcePath)
				.Append("' DataItem='")
				.Append(sourceType)
				.Append("'; target element is '")
				.Append(targetType)
				.Append("' (Name='null'); target property is '")
				.Append(targetProperty)
				.Append("' (type ' ')").ToString());
		}
	}
	public bool IsEnabled(LogLevel logLevel) => true;
	public IDisposable? BeginScope<TState>(TState state) where TState : notnull
		=> NullScope.Instance;
	sealed partial class NullScope : IDisposable
	{
		public static readonly NullScope Instance = new();
		public void Dispose() { }
	}
}
