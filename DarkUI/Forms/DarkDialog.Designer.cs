﻿using DarkUI.Controls;
using DarkUI.Data.Enums;

namespace DarkUI.Forms
{
    partial class DarkDialog
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
            pnlFooter = new System.Windows.Forms.Panel();
            flowInner = new System.Windows.Forms.FlowLayoutPanel();
            btnOk = new DarkButton();
            btnCancel = new DarkButton();
            btnClose = new DarkButton();
            btnYes = new DarkButton();
            btnNo = new DarkButton();
            btnAbort = new DarkButton();
            btnRetry = new DarkButton();
            btnIgnore = new DarkButton();
            pnlFooter.SuspendLayout();
            flowInner.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFooter
            // 
            pnlFooter.Controls.Add(flowInner);
            pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnlFooter.Location = new System.Drawing.Point(2, 488);
            pnlFooter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new System.Drawing.Size(923, 52);
            pnlFooter.TabIndex = 1;
            // 
            // flowInner
            // 
            flowInner.Controls.Add(btnOk);
            flowInner.Controls.Add(btnCancel);
            flowInner.Controls.Add(btnClose);
            flowInner.Controls.Add(btnYes);
            flowInner.Controls.Add(btnNo);
            flowInner.Controls.Add(btnAbort);
            flowInner.Controls.Add(btnRetry);
            flowInner.Controls.Add(btnIgnore);
            flowInner.Dock = System.Windows.Forms.DockStyle.Right;
            flowInner.Location = new System.Drawing.Point(149, 0);
            flowInner.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            flowInner.Name = "flowInner";
            flowInner.Padding = new System.Windows.Forms.Padding(12, 12, 12, 12);
            flowInner.Size = new System.Drawing.Size(774, 52);
            flowInner.TabIndex = 10014;
            // 
            // btnOk
            // 
            btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnOk.Location = new System.Drawing.Point(12, 12);
            btnOk.Margin = new System.Windows.Forms.Padding(0);
            btnOk.Name = "btnOk";
            btnOk.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            btnOk.Size = new System.Drawing.Size(88, 30);
            btnOk.TabIndex = 3;
            btnOk.Text = "Ok";
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(100, 12);
            btnCancel.Margin = new System.Windows.Forms.Padding(0);
            btnCancel.Name = "btnCancel";
            btnCancel.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            btnCancel.Size = new System.Drawing.Size(88, 30);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            // 
            // btnClose
            // 
            btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnClose.Location = new System.Drawing.Point(188, 12);
            btnClose.Margin = new System.Windows.Forms.Padding(0);
            btnClose.Name = "btnClose";
            btnClose.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            btnClose.Size = new System.Drawing.Size(88, 30);
            btnClose.TabIndex = 5;
            btnClose.Text = "Close";
            // 
            // btnYes
            // 
            btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            btnYes.Location = new System.Drawing.Point(276, 12);
            btnYes.Margin = new System.Windows.Forms.Padding(0);
            btnYes.Name = "btnYes";
            btnYes.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            btnYes.Size = new System.Drawing.Size(88, 30);
            btnYes.TabIndex = 6;
            btnYes.Text = "Yes";
            // 
            // btnNo
            // 
            btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            btnNo.Location = new System.Drawing.Point(364, 12);
            btnNo.Margin = new System.Windows.Forms.Padding(0);
            btnNo.Name = "btnNo";
            btnNo.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            btnNo.Size = new System.Drawing.Size(88, 30);
            btnNo.TabIndex = 7;
            btnNo.Text = "No";
            // 
            // btnAbort
            // 
            btnAbort.DialogResult = System.Windows.Forms.DialogResult.Abort;
            btnAbort.Location = new System.Drawing.Point(452, 12);
            btnAbort.Margin = new System.Windows.Forms.Padding(0);
            btnAbort.Name = "btnAbort";
            btnAbort.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            btnAbort.Size = new System.Drawing.Size(88, 30);
            btnAbort.TabIndex = 8;
            btnAbort.Text = "Abort";
            // 
            // btnRetry
            // 
            btnRetry.DialogResult = System.Windows.Forms.DialogResult.Retry;
            btnRetry.Location = new System.Drawing.Point(540, 12);
            btnRetry.Margin = new System.Windows.Forms.Padding(0);
            btnRetry.Name = "btnRetry";
            btnRetry.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            btnRetry.Size = new System.Drawing.Size(88, 30);
            btnRetry.TabIndex = 9;
            btnRetry.Text = "Retry";
            // 
            // btnIgnore
            // 
            btnIgnore.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            btnIgnore.Location = new System.Drawing.Point(628, 12);
            btnIgnore.Margin = new System.Windows.Forms.Padding(0);
            btnIgnore.Name = "btnIgnore";
            btnIgnore.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            btnIgnore.Size = new System.Drawing.Size(88, 30);
            btnIgnore.TabIndex = 10;
            btnIgnore.Text = "Ignore";
            // 
            // DarkDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(927, 542);
            Controls.Add(pnlFooter);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "DarkDialog";
            Text = "DarkDialog";
            TitleBarStyle = DarkTitleBarStyle.ToolWindow;
            pnlFooter.ResumeLayout(false);
            flowInner.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.FlowLayoutPanel flowInner;
    }
}