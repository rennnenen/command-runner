using System;
using System.Windows.Forms;
using CommandRunner.UI;

namespace CommandRunner.UI
{
    public partial class MainForm : Form
    {
        private System.Windows.Forms.Label labelCommand;
        private System.Windows.Forms.TextBox textBoxCommand;
        private System.Windows.Forms.Label labelInterval;
        private System.Windows.Forms.NumericUpDown numericUpDownInterval;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Button buttonStartStop;
        private System.Windows.Forms.Button buttonClearLogs;
        private System.Windows.Forms.Label labelCountdown;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTop;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButtons;
        private System.Windows.Forms.Label labelFooter;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFooter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelTitleLine;

        private void InitializeComponent()
        {
            // --- Control Instantiation ---
            this.labelCommand = new System.Windows.Forms.Label();
            this.textBoxCommand = new System.Windows.Forms.TextBox();
            this.labelInterval = new System.Windows.Forms.Label();
            this.numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.buttonStartStop = new System.Windows.Forms.Button();
            this.buttonClearLogs = new System.Windows.Forms.Button();
            this.labelCountdown = new System.Windows.Forms.Label();
            this.tableLayoutPanelTop = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.labelFooter = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.tableLayoutPanelFooter = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelTitleLine = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).BeginInit();
            this.SuspendLayout();

            // --- labelCommand ---
            this.labelCommand.AutoSize = true;
            this.labelCommand.Name = "labelCommand";
            this.labelCommand.Size = new System.Drawing.Size(61, 15);
            this.labelCommand.TabIndex = 0;
            this.labelCommand.Text = "Command:";
            this.labelCommand.TextAlign = System.Drawing.ContentAlignment.BottomRight;

            // --- textBoxCommand ---
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxCommand.TabIndex = 1;

            // --- labelInterval ---
            this.labelInterval.AutoSize = true;
            this.labelInterval.Name = "labelInterval";
            this.labelInterval.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelInterval.TabIndex = 2;
            this.labelInterval.Text = "Interval (min):";
            this.labelInterval.TextAlign = System.Drawing.ContentAlignment.BottomLeft;

            // --- numericUpDownInterval ---
            this.numericUpDownInterval.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.numericUpDownInterval.Maximum = new decimal(new int[] {1440, 0, 0, 0});
            this.numericUpDownInterval.Name = "numericUpDownInterval";
            this.numericUpDownInterval.Width = 80;
            this.numericUpDownInterval.MaximumSize = new System.Drawing.Size(80, 0);
            this.numericUpDownInterval.MinimumSize = new System.Drawing.Size(40, 0);
            this.numericUpDownInterval.TabIndex = 3;
            this.numericUpDownInterval.Value = new decimal(new int[] {1, 0, 0, 0});

            // --- textBoxLog ---
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLog.TabIndex = 2;
            this.textBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLog.BackColor = System.Drawing.Color.White;

            // --- buttonStartStop ---
            this.buttonStartStop.Location = new System.Drawing.Point(12, 330);
            this.buttonStartStop.Name = "buttonStartStop";
            this.buttonStartStop.Size = new System.Drawing.Size(100, 30);
            this.buttonStartStop.TabIndex = 6;
            this.buttonStartStop.Text = "Start";
            this.buttonStartStop.UseVisualStyleBackColor = true;
            this.buttonStartStop.Click += new System.EventHandler(this.buttonStartStop_Click);

            // --- buttonClearLogs ---
            this.buttonClearLogs.Location = new System.Drawing.Point(479, 330);
            this.buttonClearLogs.Name = "buttonClearLogs";
            this.buttonClearLogs.Size = new System.Drawing.Size(100, 30);
            this.buttonClearLogs.TabIndex = 7;
            this.buttonClearLogs.Text = "Clear Logs";
            this.buttonClearLogs.UseVisualStyleBackColor = true;
            this.buttonClearLogs.Click += new System.EventHandler(this.buttonClearLogs_Click);

            // --- labelCountdown ---
            this.labelCountdown.MinimumSize = new System.Drawing.Size(160, 0);
            this.labelCountdown.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelCountdown.Location = new System.Drawing.Point(12, 44);
            this.labelCountdown.Name = "labelCountdown";
            this.labelCountdown.Size = new System.Drawing.Size(200, 15);
            this.labelCountdown.TabIndex = 8;
            this.labelCountdown.Text = "Next command in: -- seconds";
            this.labelCountdown.Visible = false;

            // --- tableLayoutPanelTop ---
            this.tableLayoutPanelTop.ColumnCount = 3;
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F)); // Command
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2F)); // Spacer
            this.tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize)); // Interval
            this.tableLayoutPanelTop.RowCount = 2;
            this.tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize)); // Labels
            this.tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize)); // Inputs
            this.tableLayoutPanelTop.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanelTop.Name = "tableLayoutPanelTop";
            this.tableLayoutPanelTop.Size = new System.Drawing.Size(567, 50);
            this.tableLayoutPanelTop.TabIndex = 0;
            this.tableLayoutPanelTop.Anchor = System.Windows.Forms.AnchorStyles.Top;
            // Add labels to row 0 (top right of inputs)
            this.tableLayoutPanelTop.Controls.Add(this.labelCommand, 0, 0);
            this.tableLayoutPanelTop.Controls.Add(this.labelInterval, 2, 0);
            // Add inputs to row 1
            this.tableLayoutPanelTop.Controls.Add(this.textBoxCommand, 0, 1);
            this.tableLayoutPanelTop.Controls.Add(this.numericUpDownInterval, 2, 1);


            // --- flowLayoutPanelButtons ---
            this.flowLayoutPanelButtons.Location = new System.Drawing.Point(12, 340);
            this.flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            this.flowLayoutPanelButtons.Size = new System.Drawing.Size(567, 30);
            this.flowLayoutPanelButtons.TabIndex = 1;
            this.flowLayoutPanelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanelButtons.Controls.Add(this.buttonClearLogs);
            this.flowLayoutPanelButtons.Controls.Add(this.buttonStartStop);

            // --- labelStatus ---
            this.labelStatus.AutoSize = true;
            this.labelStatus.Text = "Status: Stopped";
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelStatus.Location = new System.Drawing.Point(12, 370);
            this.labelStatus.Size = new System.Drawing.Size(100, 15);
            this.labelStatus.TabIndex = 10;

            // --- labelFooter ---
            this.labelFooter.AutoSize = true;
            this.labelFooter.Text = "github.com/rennnenen";
            this.labelFooter.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.labelFooter.ForeColor = System.Drawing.Color.Gray;
            this.labelFooter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelFooter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFooter.Location = new System.Drawing.Point(450, 370);
            this.labelFooter.Size = new System.Drawing.Size(230, 15);
            this.labelFooter.TabIndex = 9;

            // --- tableLayoutPanelFooter ---
            this.tableLayoutPanelFooter.ColumnCount = 3;
            this.tableLayoutPanelFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tableLayoutPanelFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tableLayoutPanelFooter.RowCount = 1;
            this.tableLayoutPanelFooter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanelFooter.Height = 28;
            this.tableLayoutPanelFooter.Location = new System.Drawing.Point(8, 370);
            this.tableLayoutPanelFooter.Size = new System.Drawing.Size(575, 24);
            this.tableLayoutPanelFooter.TabIndex = 100;
            this.tableLayoutPanelFooter.Padding = new System.Windows.Forms.Padding(8, 0, 8, 8);
            this.tableLayoutPanelFooter.Controls.Add(this.labelStatus, 0, 0);
            this.tableLayoutPanelFooter.Controls.Add(this.labelCountdown, 1, 0);
            this.tableLayoutPanelFooter.Controls.Add(this.labelFooter, 2, 0);
            this.labelStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelCountdown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFooter.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelCountdown.Text = "Next command in: -- seconds";
            this.labelCountdown.Visible = false;

            // --- labelTitle ---
            this.labelTitle.AutoSize = true;
            this.labelTitle.Text = "Command Runner";
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitle.Margin = new System.Windows.Forms.Padding(0, 12, 0, 4);

            // --- labelTitleLine ---
            this.labelTitleLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelTitleLine.Height = 2;
            this.labelTitleLine.Dock = System.Windows.Forms.DockStyle.Top;

            // --- tableLayoutPanelMain ---
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.RowCount = 6;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize)); // Title
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F)); // Line
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize)); // Top controls
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F)); // Log
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize)); // Buttons
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize)); // Footer
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(591, 382);
            this.tableLayoutPanelMain.TabIndex = 0;
            this.tableLayoutPanelMain.Controls.Add(this.labelTitle, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelTitleLine, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelTop, 0, 2);
            this.tableLayoutPanelMain.Controls.Add(this.textBoxLog, 0, 3);
            this.tableLayoutPanelMain.Controls.Add(this.flowLayoutPanelButtons, 0, 4);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelFooter, 0, 5);
            this.tableLayoutPanelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelFooter.Dock = System.Windows.Forms.DockStyle.Fill;

            // --- MainForm ---
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 382);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MainForm";
            this.Text = "Command Runner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
} 