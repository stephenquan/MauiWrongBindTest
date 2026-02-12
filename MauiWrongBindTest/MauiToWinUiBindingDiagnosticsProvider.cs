using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace MauiWrongBindTest;

partial class MauiToWinUiBindingDiagnosticsProvider : ILoggerProvider
{
    public ILogger CreateLogger(string categoryName)
        => (categoryName == "Microsoft.Maui.Controls.Xaml.Diagnostics.BindingDiagnostics")
            ? new MauiToWinUiBindingDiagnosticsLogger()
            : NullLogger.Instance;
    public void Dispose() { }
}
