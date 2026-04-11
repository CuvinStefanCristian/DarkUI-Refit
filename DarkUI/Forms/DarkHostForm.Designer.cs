using DarkUI.Data.Enums;

namespace DarkUI.Forms
{
    partial class DarkHostForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dockPanel = new DarkUI.Docking.DarkDockPanel();
            SuspendLayout();
            // 
            // dockPanel
            // 
            dockPanel.BackColor = System.Drawing.Color.FromArgb(60, 63, 65);
            dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            dockPanel.HostFormText = null;
            dockPanel.Location = new System.Drawing.Point(2, 30);
            dockPanel.Name = "dockPanel";
            dockPanel.Size = new System.Drawing.Size(844, 535);
            dockPanel.TabIndex = 0;
            // 
            // DarkHostForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(848, 567);
            Controls.Add(dockPanel);
            Name = "DarkHostForm";
            Text = "DarkHostForm";
            TitleBarStyle = DarkTitleBarStyle.ToolWindow;
            FormClosing += DarkHostForm_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private Docking.DarkDockPanel dockPanel;
    }
}