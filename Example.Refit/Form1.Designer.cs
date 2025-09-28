namespace Example.Refit
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            darkButton1 = new DarkUI.Controls.DarkButton();
            darkButton2 = new DarkUI.Controls.DarkButton();
            SuspendLayout();
            // 
            // darkButton1
            // 
            darkButton1.Location = new Point(233, 190);
            darkButton1.Name = "darkButton1";
            darkButton1.Padding = new Padding(5);
            darkButton1.Size = new Size(75, 23);
            darkButton1.TabIndex = 1;
            darkButton1.Text = "darkButton1";
            // 
            // darkButton2
            // 
            darkButton2.Location = new Point(314, 190);
            darkButton2.Name = "darkButton2";
            darkButton2.Padding = new Padding(5);
            darkButton2.Size = new Size(75, 23);
            darkButton2.TabIndex = 2;
            darkButton2.Text = "darkButton2";
            // 
            // Form1
            // 
            AcceptButton = darkButton1;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(851, 567);
            Controls.Add(darkButton2);
            Controls.Add(darkButton1);
            Name = "Form1";
            Text = "Test Form";
            TitleBarStyle = DarkUI.Data.Enums.DarkTitleBarStyle.Standard;
            ResumeLayout(false);
        }

        #endregion

        private DarkUI.Controls.DarkButton darkButton1;
        private DarkUI.Controls.DarkButton darkButton2;
    }
}
