using DarkUI.Config;
using DarkUI.Data.Enums.Docking;

namespace Example
{
    partial class DockProperties
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlMain = new System.Windows.Forms.Panel();
            panel4 = new System.Windows.Forms.Panel();
            btnCloseAll = new DarkUI.Controls.DarkButton();
            btnShowError = new DarkUI.Controls.DarkButton();
            btnShowSuccess = new DarkUI.Controls.DarkButton();
            btnShowWarning = new DarkUI.Controls.DarkButton();
            darkTitle4 = new DarkUI.Controls.DarkTitle();
            btnShowInfo = new DarkUI.Controls.DarkButton();
            panel3 = new System.Windows.Forms.Panel();
            cmbList = new DarkUI.Controls.DarkDropdownList();
            darkTitle3 = new DarkUI.Controls.DarkTitle();
            panel1 = new System.Windows.Forms.Panel();
            darkRadioButton3 = new DarkUI.Controls.DarkRadioButton();
            darkRadioButton2 = new DarkUI.Controls.DarkRadioButton();
            darkRadioButton1 = new DarkUI.Controls.DarkRadioButton();
            darkTitle1 = new DarkUI.Controls.DarkTitle();
            panel2 = new System.Windows.Forms.Panel();
            darkCheckBox3 = new DarkUI.Controls.DarkCheckBox();
            darkCheckBox2 = new DarkUI.Controls.DarkCheckBox();
            darkCheckBox1 = new DarkUI.Controls.DarkCheckBox();
            darkTitle2 = new DarkUI.Controls.DarkTitle();
            darkScrollBar1 = new DarkUI.Controls.DarkScrollBar();
            pnlMain.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(panel4);
            pnlMain.Controls.Add(panel3);
            pnlMain.Controls.Add(panel1);
            pnlMain.Controls.Add(panel2);
            pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlMain.Location = new System.Drawing.Point(0, 25);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new System.Windows.Forms.Padding(10, 10, 5, 10);
            pnlMain.Size = new System.Drawing.Size(265, 425);
            pnlMain.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnCloseAll);
            panel4.Controls.Add(btnShowError);
            panel4.Controls.Add(btnShowSuccess);
            panel4.Controls.Add(btnShowWarning);
            panel4.Controls.Add(darkTitle4);
            panel4.Controls.Add(btnShowInfo);
            panel4.Location = new System.Drawing.Point(10, 264);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(250, 148);
            panel4.TabIndex = 4;
            // 
            // btnCloseAll
            // 
            btnCloseAll.Location = new System.Drawing.Point(3, 115);
            btnCloseAll.Name = "btnCloseAll";
            btnCloseAll.Padding = new System.Windows.Forms.Padding(5);
            btnCloseAll.Size = new System.Drawing.Size(77, 30);
            btnCloseAll.TabIndex = 13;
            btnCloseAll.Text = "Close all";
            btnCloseAll.Click += btnCloseAll_Click;
            // 
            // btnShowError
            // 
            btnShowError.Location = new System.Drawing.Point(86, 72);
            btnShowError.Name = "btnShowError";
            btnShowError.Padding = new System.Windows.Forms.Padding(5);
            btnShowError.Size = new System.Drawing.Size(77, 37);
            btnShowError.TabIndex = 12;
            btnShowError.Text = "Show Error";
            btnShowError.Click += btnShowError_Click;
            // 
            // btnShowSuccess
            // 
            btnShowSuccess.Location = new System.Drawing.Point(86, 29);
            btnShowSuccess.Name = "btnShowSuccess";
            btnShowSuccess.Padding = new System.Windows.Forms.Padding(5);
            btnShowSuccess.Size = new System.Drawing.Size(77, 37);
            btnShowSuccess.TabIndex = 10;
            btnShowSuccess.Text = "Show Success";
            btnShowSuccess.Click += btnShowSuccess_Click;
            // 
            // btnShowWarning
            // 
            btnShowWarning.Location = new System.Drawing.Point(3, 72);
            btnShowWarning.Name = "btnShowWarning";
            btnShowWarning.Padding = new System.Windows.Forms.Padding(5);
            btnShowWarning.Size = new System.Drawing.Size(77, 37);
            btnShowWarning.TabIndex = 11;
            btnShowWarning.Text = "Show Warning";
            btnShowWarning.Click += btnShowWarning_Click;
            // 
            // darkTitle4
            // 
            darkTitle4.Dock = System.Windows.Forms.DockStyle.Top;
            darkTitle4.Location = new System.Drawing.Point(0, 0);
            darkTitle4.Name = "darkTitle4";
            darkTitle4.Size = new System.Drawing.Size(250, 26);
            darkTitle4.TabIndex = 8;
            darkTitle4.Text = "Toast Notifications";
            // 
            // btnShowInfo
            // 
            btnShowInfo.ButtonStyle = DarkUI.Data.Enums.DarkButtonStyle.Flat;
            btnShowInfo.Location = new System.Drawing.Point(3, 29);
            btnShowInfo.Name = "btnShowInfo";
            btnShowInfo.Padding = new System.Windows.Forms.Padding(5);
            btnShowInfo.Size = new System.Drawing.Size(77, 37);
            btnShowInfo.TabIndex = 9;
            btnShowInfo.Text = "Show Info";
            btnShowInfo.Click += btnShowInfo_Click;
            // 
            // panel3
            // 
            panel3.AutoSize = true;
            panel3.Controls.Add(cmbList);
            panel3.Controls.Add(darkTitle3);
            panel3.Dock = System.Windows.Forms.DockStyle.Top;
            panel3.Location = new System.Drawing.Point(10, 196);
            panel3.Name = "panel3";
            panel3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            panel3.Size = new System.Drawing.Size(250, 62);
            panel3.TabIndex = 3;
            // 
            // cmbList
            // 
            cmbList.Dock = System.Windows.Forms.DockStyle.Top;
            cmbList.Location = new System.Drawing.Point(0, 26);
            cmbList.Name = "cmbList";
            cmbList.Size = new System.Drawing.Size(250, 26);
            cmbList.TabIndex = 8;
            cmbList.Text = "darkDropdownList1";
            // 
            // darkTitle3
            // 
            darkTitle3.Dock = System.Windows.Forms.DockStyle.Top;
            darkTitle3.Location = new System.Drawing.Point(0, 0);
            darkTitle3.Name = "darkTitle3";
            darkTitle3.Size = new System.Drawing.Size(250, 26);
            darkTitle3.TabIndex = 7;
            darkTitle3.Text = "Lists";
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(darkRadioButton3);
            panel1.Controls.Add(darkRadioButton2);
            panel1.Controls.Add(darkRadioButton1);
            panel1.Controls.Add(darkTitle1);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(10, 103);
            panel1.Name = "panel1";
            panel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            panel1.Size = new System.Drawing.Size(250, 93);
            panel1.TabIndex = 2;
            // 
            // darkRadioButton3
            // 
            darkRadioButton3.AutoSize = true;
            darkRadioButton3.Dock = System.Windows.Forms.DockStyle.Top;
            darkRadioButton3.Enabled = false;
            darkRadioButton3.Location = new System.Drawing.Point(0, 64);
            darkRadioButton3.Name = "darkRadioButton3";
            darkRadioButton3.Size = new System.Drawing.Size(250, 19);
            darkRadioButton3.TabIndex = 6;
            darkRadioButton3.TabStop = true;
            darkRadioButton3.Text = "Disabled radiobutton";
            // 
            // darkRadioButton2
            // 
            darkRadioButton2.AutoSize = true;
            darkRadioButton2.Dock = System.Windows.Forms.DockStyle.Top;
            darkRadioButton2.Location = new System.Drawing.Point(0, 45);
            darkRadioButton2.Name = "darkRadioButton2";
            darkRadioButton2.Size = new System.Drawing.Size(250, 19);
            darkRadioButton2.TabIndex = 5;
            darkRadioButton2.TabStop = true;
            darkRadioButton2.Text = "Radiobutton";
            // 
            // darkRadioButton1
            // 
            darkRadioButton1.AutoSize = true;
            darkRadioButton1.Dock = System.Windows.Forms.DockStyle.Top;
            darkRadioButton1.Location = new System.Drawing.Point(0, 26);
            darkRadioButton1.Name = "darkRadioButton1";
            darkRadioButton1.Size = new System.Drawing.Size(250, 19);
            darkRadioButton1.TabIndex = 4;
            darkRadioButton1.TabStop = true;
            darkRadioButton1.Text = "Radiobutton";
            // 
            // darkTitle1
            // 
            darkTitle1.Dock = System.Windows.Forms.DockStyle.Top;
            darkTitle1.Location = new System.Drawing.Point(0, 0);
            darkTitle1.Name = "darkTitle1";
            darkTitle1.Size = new System.Drawing.Size(250, 26);
            darkTitle1.TabIndex = 7;
            darkTitle1.Text = "Radio buttons";
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.Controls.Add(darkCheckBox3);
            panel2.Controls.Add(darkCheckBox2);
            panel2.Controls.Add(darkCheckBox1);
            panel2.Controls.Add(darkTitle2);
            panel2.Dock = System.Windows.Forms.DockStyle.Top;
            panel2.Location = new System.Drawing.Point(10, 10);
            panel2.Name = "panel2";
            panel2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            panel2.Size = new System.Drawing.Size(250, 93);
            panel2.TabIndex = 1;
            // 
            // darkCheckBox3
            // 
            darkCheckBox3.AutoSize = true;
            darkCheckBox3.Checked = true;
            darkCheckBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            darkCheckBox3.Dock = System.Windows.Forms.DockStyle.Top;
            darkCheckBox3.Enabled = false;
            darkCheckBox3.Location = new System.Drawing.Point(0, 64);
            darkCheckBox3.Name = "darkCheckBox3";
            darkCheckBox3.Size = new System.Drawing.Size(250, 19);
            darkCheckBox3.TabIndex = 6;
            darkCheckBox3.Text = "Disabled checked checkbox";
            // 
            // darkCheckBox2
            // 
            darkCheckBox2.AutoSize = true;
            darkCheckBox2.Dock = System.Windows.Forms.DockStyle.Top;
            darkCheckBox2.Enabled = false;
            darkCheckBox2.Location = new System.Drawing.Point(0, 45);
            darkCheckBox2.Name = "darkCheckBox2";
            darkCheckBox2.Size = new System.Drawing.Size(250, 19);
            darkCheckBox2.TabIndex = 5;
            darkCheckBox2.Text = "Disabled checkbox";
            // 
            // darkCheckBox1
            // 
            darkCheckBox1.AutoSize = true;
            darkCheckBox1.Dock = System.Windows.Forms.DockStyle.Top;
            darkCheckBox1.Location = new System.Drawing.Point(0, 26);
            darkCheckBox1.Name = "darkCheckBox1";
            darkCheckBox1.Size = new System.Drawing.Size(250, 19);
            darkCheckBox1.TabIndex = 4;
            darkCheckBox1.Text = "Checkbox";
            // 
            // darkTitle2
            // 
            darkTitle2.Dock = System.Windows.Forms.DockStyle.Top;
            darkTitle2.Location = new System.Drawing.Point(0, 0);
            darkTitle2.Name = "darkTitle2";
            darkTitle2.Size = new System.Drawing.Size(250, 26);
            darkTitle2.TabIndex = 8;
            darkTitle2.Text = "Check boxes";
            // 
            // darkScrollBar1
            // 
            darkScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            darkScrollBar1.Enabled = false;
            darkScrollBar1.Location = new System.Drawing.Point(265, 25);
            darkScrollBar1.Maximum = 5;
            darkScrollBar1.Minimum = 1;
            darkScrollBar1.Name = "darkScrollBar1";
            darkScrollBar1.Size = new System.Drawing.Size(15, 425);
            darkScrollBar1.TabIndex = 1;
            darkScrollBar1.Text = "darkScrollBar1";
            // 
            // DockProperties
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(pnlMain);
            Controls.Add(darkScrollBar1);
            DefaultDockArea = DarkDockArea.Right;
            DockText = "Properties";
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            Icon = Icons.properties_16xLG;
            Name = "DockProperties";
            SerializationKey = "DockProperties";
            Size = new System.Drawing.Size(280, 450);
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel panel1;
        private DarkUI.Controls.DarkRadioButton darkRadioButton3;
        private DarkUI.Controls.DarkRadioButton darkRadioButton2;
        private DarkUI.Controls.DarkRadioButton darkRadioButton1;
        private DarkUI.Controls.DarkTitle darkTitle1;
        private System.Windows.Forms.Panel panel2;
        private DarkUI.Controls.DarkCheckBox darkCheckBox3;
        private DarkUI.Controls.DarkCheckBox darkCheckBox2;
        private DarkUI.Controls.DarkCheckBox darkCheckBox1;
        private DarkUI.Controls.DarkTitle darkTitle2;
        private DarkUI.Controls.DarkScrollBar darkScrollBar1;
        private System.Windows.Forms.Panel panel3;
        private DarkUI.Controls.DarkTitle darkTitle3;
        private DarkUI.Controls.DarkDropdownList cmbList;
        private System.Windows.Forms.Panel panel4;
        private DarkUI.Controls.DarkButton btnShowSuccess;
        private DarkUI.Controls.DarkButton btnShowInfo;
        private DarkUI.Controls.DarkButton btnShowError;
        private DarkUI.Controls.DarkButton btnShowWarning;
        private DarkUI.Controls.DarkTitle darkTitle4;
        private DarkUI.Controls.DarkButton btnCloseAll;
    }
}
