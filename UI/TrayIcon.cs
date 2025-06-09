using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace CommandRunner.UI
{
    /// <summary>
    /// Provides a system tray icon with context menu for controlling the application.
    /// </summary>
    public class TrayIcon : IDisposable
    {
        private NotifyIcon notifyIcon;
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem startMenuItem;
        private ToolStripMenuItem stopMenuItem;
        private ToolStripMenuItem settingsMenuItem;
        private ToolStripMenuItem exitMenuItem;
        public event EventHandler? StartClicked;
        public event EventHandler? StopClicked;
        public event EventHandler? SettingsClicked;
        public event EventHandler? ExitClicked;
        private bool disposedValue;
        private Icon trayIconImage;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrayIcon"/> class.
        /// </summary>
        public TrayIcon()
        {
            contextMenu = new ContextMenuStrip();
            startMenuItem = new ToolStripMenuItem("Start");
            stopMenuItem = new ToolStripMenuItem("Stop") { Enabled = false };
            settingsMenuItem = new ToolStripMenuItem("Settings");
            exitMenuItem = new ToolStripMenuItem("Exit");

            contextMenu.Items.AddRange(new ToolStripItem[]
            {
                startMenuItem,
                stopMenuItem,
                settingsMenuItem,
                exitMenuItem
            });

            // Use custom icon if available
            var iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UI", "app.ico");
            trayIconImage = File.Exists(iconPath) ? new Icon(iconPath) : SystemIcons.Application;

            notifyIcon = new NotifyIcon
            {
                Icon = trayIconImage,
                Visible = true,
                ContextMenuStrip = contextMenu,
                Text = "Command Runner"
            };

            notifyIcon.MouseClick += NotifyIcon_MouseClick;
            startMenuItem.Click += (s, e) => StartClicked?.Invoke(this, EventArgs.Empty);
            stopMenuItem.Click += (s, e) => StopClicked?.Invoke(this, EventArgs.Empty);
            settingsMenuItem.Click += (s, e) => SettingsClicked?.Invoke(this, EventArgs.Empty);
            exitMenuItem.Click += (s, e) => ExitClicked?.Invoke(this, EventArgs.Empty);
        }

        private void NotifyIcon_MouseClick(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SettingsClicked?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Enables or disables the Start menu item.
        /// </summary>
        public void SetStartEnabled(bool enabled)
        {
            startMenuItem.Enabled = enabled;
        }
        /// <summary>
        /// Enables or disables the Stop menu item.
        /// </summary>
        public void SetStopEnabled(bool enabled)
        {
            stopMenuItem.Enabled = enabled;
        }

        /// <summary>
        /// Shows a balloon notification from the tray icon.
        /// </summary>
        public void ShowNotification(string title, string message, ToolTipIcon icon = ToolTipIcon.Info)
        {
            notifyIcon.BalloonTipTitle = title;
            notifyIcon.BalloonTipText = message;
            notifyIcon.ShowBalloonTip(2000);
        }

        /// <summary>
        /// Sets the status of the tray icon.
        /// </summary>
        public void SetStatus(bool running)
        {
            notifyIcon.Text = running ? "Command Runner (Running)" : "Command Runner (Stopped)";
        }

        /// <summary>
        /// Disposes the TrayIcon and releases resources.
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
                    notifyIcon.Visible = false;
                    notifyIcon.Dispose();
                    contextMenu.Dispose();
                }
                disposedValue = true;
            }
        }
    }
} 