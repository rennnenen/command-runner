using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommandRunner.Core
{
    /// <summary>
    /// Executes commands on a timer and provides cancellation and logging support.
    /// </summary>
    public class CommandExecutor : IDisposable
    {
        private System.Threading.Timer? timer;
        private bool isRunning = false;
        private string? command;
        private int intervalMinutes;
        private readonly Action<string> logCallback;
        private readonly object lockObj = new object();
        private CancellationTokenSource? cts;
        private Process? runningProcess;
        private bool disposedValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandExecutor"/> class.
        /// </summary>
        /// <param name="logCallback">Callback for logging output and errors.</param>
        public CommandExecutor(Action<string> logCallback)
        {
            this.logCallback = logCallback;
        }

        /// <summary>
        /// Starts executing the specified command at the given interval (in minutes).
        /// </summary>
        /// <param name="command">The command to execute.</param>
        /// <param name="intervalMinutes">The interval in minutes.</param>
        public void Start(string command, int intervalMinutes)
        {
            this.command = command;
            this.intervalMinutes = intervalMinutes;
            cts = new CancellationTokenSource();
            timer = new System.Threading.Timer(async _ => await ExecuteCommandAsync(), null, 0, intervalMinutes * 60 * 1000);
        }

        /// <summary>
        /// Stops command execution and cancels any running process.
        /// </summary>
        public void Stop()
        {
            cts?.Cancel();
            if (runningProcess != null && !runningProcess.HasExited)
            {
                try
                {
                    runningProcess.Kill(true);
                    logCallback($"[INFO] Killed running process (PID: {runningProcess.Id})");
                }
                catch (Exception ex)
                {
                    logCallback($"[ERROR] Failed to kill process: {ex.Message}");
                }
            }
            timer?.Dispose();
            isRunning = false;
        }

        private async Task ExecuteCommandAsync()
        {
            lock (lockObj)
            {
                if (isRunning) return;
                isRunning = true;
            }
            try
            {
                var timestamp = DateTime.Now.ToString("[yyyy-MM-dd hh:mm:ss tt]");
                logCallback($"{timestamp} Running: {command}");
                var psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/C {command}",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                using var process = new Process { StartInfo = psi };
                runningProcess = process;
                var output = new StringBuilder();
                process.OutputDataReceived += (s, e) => { if (e.Data != null) output.AppendLine(e.Data); };
                process.ErrorDataReceived += (s, e) => { if (e.Data != null) output.AppendLine(e.Data); };
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                await process.WaitForExitAsync(cts!.Token);
                logCallback($"{timestamp} Output:\n{output.ToString()}");
            }
            catch (OperationCanceledException)
            {
                logCallback($"[INFO] Command execution cancelled.");
            }
            catch (Exception ex)
            {
                var timestamp = DateTime.Now.ToString("[yyyy-MM-dd hh:mm:ss tt]");
                logCallback($"{timestamp} Error: {ex.Message}");
            }
            finally
            {
                runningProcess = null;
                isRunning = false;
            }
        }

        /// <summary>
        /// Disposes the CommandExecutor and releases resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Stop();
                }
                disposedValue = true;
            }
        }
    }
} 