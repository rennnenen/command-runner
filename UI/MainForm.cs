using System;
using System.Windows.Forms;
using CommandRunner.Core;
using CommandRunner.UI;
using System.IO;
using System.Drawing;

namespace CommandRunner.UI
{
    public partial class MainForm : Form
    {
        public string CommandText => textBoxCommand.Text;
        public int IntervalMinutes => (int)numericUpDownInterval.Value;

        private TrayIcon trayIcon;
        private CommandExecutor executor;
        private bool isStarted = false;
        private System.Windows.Forms.Timer uiTimer;
        private int secondsUntilNextRun;

        public MainForm()
        {
            InitializeComponent();
            trayIcon = new TrayIcon();
            executor = new CommandExecutor(AppendLog);
            trayIcon.StartClicked += (s, ev) => StartExecution();
            trayIcon.StopClicked += (s, ev) => StopExecution();
            trayIcon.SettingsClicked += (s, ev) => ShowSettings();
            trayIcon.ExitClicked += (s, ev) => Application.Exit();
            this.FormClosing += MainForm_FormClosing;
            // Load settings
            textBoxCommand.Text = Properties.Settings.Default.Command;
            numericUpDownInterval.Value = Properties.Settings.Default.Interval > 0 ? Properties.Settings.Default.Interval : 1;
            // UI timer for countdown
            uiTimer = new System.Windows.Forms.Timer();
            uiTimer.Interval = 1000;
            uiTimer.Tick += UiTimer_Tick;
            labelCountdown.Text = "Next command in: -- seconds";
            // Set custom icon for the window
            var iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app.ico");
            if (File.Exists(iconPath))
            {
                this.Icon = new Icon(iconPath);
            }
            else
            {
                MessageBox.Show($"Icon not found: {iconPath}", "Icon Debug", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Save settings
            Properties.Settings.Default.Command = textBoxCommand.Text;
            Properties.Settings.Default.Interval = (int)numericUpDownInterval.Value;
            Properties.Settings.Default.Save();
            base.OnFormClosing(e);
        }

        private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void ShowSettings()
        {
            this.Invoke(new Action(() => { this.Show(); this.WindowState = FormWindowState.Normal; this.BringToFront(); }));
        }

        private void StartExecution()
        {
            if (isStarted) return;
            if (string.IsNullOrWhiteSpace(CommandText))
            {
                MessageBox.Show("Please enter a command to execute.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (IntervalMinutes <= 0)
            {
                MessageBox.Show("Interval must be a positive number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            executor.Start(CommandText, IntervalMinutes);
            NotifyCommandStarted();
            isStarted = true;
            trayIcon.SetStartEnabled(false);
            trayIcon.SetStopEnabled(true);
            buttonStartStop.Text = "Stop";
            secondsUntilNextRun = IntervalMinutes * 60;
            labelCountdown.Text = $"Next command in: {secondsUntilNextRun} seconds";
            labelCountdown.Visible = true;
            uiTimer.Start();
            labelStatus.Text = "Status: Running";
            labelStatus.ForeColor = System.Drawing.Color.DarkGreen;
            trayIcon.SetStatus(true);
        }

        private void StopExecution()
        {
            if (!isStarted) return;
            executor.Stop();
            isStarted = false;
            trayIcon.SetStartEnabled(true);
            trayIcon.SetStopEnabled(false);
            buttonStartStop.Text = "Start";
            labelCountdown.Visible = false;
            uiTimer.Stop();
            NotifyCommandStopped();
            labelStatus.Text = "Status: Stopped";
            labelStatus.ForeColor = System.Drawing.Color.DarkRed;
            trayIcon.SetStatus(false);
        }

        private void buttonStartStop_Click(object sender, EventArgs e)
        {
            if (!isStarted) StartExecution();
            else StopExecution();
        }

        public void AppendLog(string text)
        {
            if (textBoxLog.InvokeRequired)
            {
                textBoxLog.Invoke(new Action(() => AppendLog(text)));
                return;
            }
            textBoxLog.AppendText(text + Environment.NewLine);
        }

        public void ClearLog()
        {
            textBoxLog.Clear();
        }

        private void buttonClearLogs_Click(object sender, EventArgs e)
        {
            ClearLog();
        }

        private void UiTimer_Tick(object? sender, EventArgs e)
        {
            if (!isStarted) return;
            secondsUntilNextRun--;
            if (secondsUntilNextRun <= 0)
            {
                secondsUntilNextRun = IntervalMinutes * 60;
                NotifyCommandExecuted();
            }
            if (labelCountdown.Visible)
                labelCountdown.Text = $"Next command in: {secondsUntilNextRun} seconds";
        }

        private void NotifyCommandExecuted()
        {
            trayIcon.ShowNotification("Command Executed", $"Executed: {CommandText}");
        }

        private void NotifyCommandStarted()
        {
            trayIcon.ShowNotification("Execution Started", $"Started: {CommandText}");
        }

        private void NotifyCommandStopped()
        {
            trayIcon.ShowNotification("Execution Stopped", $"Stopped: {CommandText}");
        }
    }
} 