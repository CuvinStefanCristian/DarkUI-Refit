using DarkUI.Data.Enums;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DarkUI.Forms
{
    public partial class DarkMessageBox : DarkDialog
    {
        #region Field Region

        private string _message;
        private int _maximumWidth = 350;

        #endregion

        #region Property Region

        [Description("Determines the maximum width of the message box when it autosizes around the displayed message.")]
        [DefaultValue(350)]
        public int MaximumWidth
        {
            get { return _maximumWidth; }
            set
            {
                _maximumWidth = value;
                CalculateSize();
            }
        }

        #endregion

        #region Constructor Region

        public DarkMessageBox()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
        }

        public DarkMessageBox(string message, string title, DarkMessageBoxIcon icon, DarkDialogButton buttons)
            : this()
        {
            Text = title;
            _message = message;

            DialogButtons = buttons;
            SetIcon(icon);

            picIcon.ClientSize = new Size(48, 48);
            picIcon.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public DarkMessageBox(string message)
            : this(message, null, DarkMessageBoxIcon.None, DarkDialogButton.Ok)
        { }

        public DarkMessageBox(string message, string title)
            : this(message, title, DarkMessageBoxIcon.None, DarkDialogButton.Ok)
        { }

        public DarkMessageBox(string message, string title, DarkDialogButton buttons)
            : this(message, title, DarkMessageBoxIcon.None, buttons)
        { }

        public DarkMessageBox(string message, string title, DarkMessageBoxIcon icon)
            : this(message, title, icon, DarkDialogButton.Ok)
        { }

        #endregion

        #region Static Method Region

        public static DialogResult ShowInformation(string message, string caption, DarkDialogButton buttons = DarkDialogButton.Ok)
        {
            return ShowDialog(message, caption, DarkMessageBoxIcon.Information, buttons);
        }

        public static DialogResult ShowWarning(string message, string caption, DarkDialogButton buttons = DarkDialogButton.Ok)
        {
            return ShowDialog(message, caption, DarkMessageBoxIcon.Warning, buttons);
        }

        public static DialogResult ShowError(string message, string caption, DarkDialogButton buttons = DarkDialogButton.Ok)
        {
            return ShowDialog(message, caption, DarkMessageBoxIcon.Error, buttons);
        }

        private static DialogResult ShowDialog(string message, string caption, DarkMessageBoxIcon icon, DarkDialogButton buttons)
        {
            using (var dlg = new DarkMessageBox(message, caption, icon, buttons))
            {
                var result = dlg.ShowDialog();
                return result;
            }
        }

        #endregion

        #region Method Region

        private void SetIcon(DarkMessageBoxIcon icon)
        {
            switch (icon)
            {
                case DarkMessageBoxIcon.None:
                    picIcon.Visible = false;
                    lblText.Left = 10;
                    break;
                case DarkMessageBoxIcon.Information:
                    picIcon.Image = MessageBoxIcons.info;
                    break;
                case DarkMessageBoxIcon.Warning:
                    picIcon.Image = MessageBoxIcons.warning;
                    break;
                case DarkMessageBoxIcon.Error:
                    picIcon.Image = MessageBoxIcons.error;
                    break;
            }
        }

        private void CalculateSize()
        {
            int padding = 15; // Standard spacing for your margins
            int buttonHeight = 30; // Adjust this if your custom buttons are taller

            lblText.Text = string.Empty;
            lblText.AutoSize = true;
            lblText.Text = _message;

            // 1. CALCULATE REQUIRED WIDTH
            // The width needs to fit: (Icon + Text) OR (Buttons). Whichever is wider.
            int contentWidth = picIcon.Right + padding + lblText.Width + padding;
            int requiredWidth = Math.Max(contentWidth, TotalButtonSize + (padding * 2));

            int finalClientWidth = Math.Min(requiredWidth, _maximumWidth); // Cap it at your max width

            // 2. HANDLE TEXT WRAPPING & POSITIONING
            if (contentWidth > _maximumWidth)
            {
                // Multi-line scenario: Text is too long, we need to wrap it
                lblText.AutoSize = false;
                lblText.AutoUpdateHeight = true;
                lblText.Width = finalClientWidth - picIcon.Right - (padding * 2);
            }
            else
            {
                // Single-line scenario: Center the text vertically next to the icon
                lblText.Top = picIcon.Top + (picIcon.Height / 2) - (lblText.Height / 2);
            }

            // 3. CALCULATE REQUIRED HEIGHT
            // The top section must fit whichever is taller: the icon OR the text
            int contentHeight = Math.Max(picIcon.Height, lblText.Height);

            // Total internal height = Top margin + Content + Middle margin + Buttons + Bottom margin
            int finalClientHeight = picIcon.Top + contentHeight + padding + buttonHeight + padding;

            // 4. ENFORCE ABSOLUTE MINIMUMS
            // Ensures the dialog never looks awkwardly tiny, even for a simple "Ok" message
            finalClientWidth = Math.Max(finalClientWidth, 260);
            finalClientHeight = Math.Max(finalClientHeight, 100);

            // 5. APPLY THE SIZE
            // Using ClientSize instead of Size guarantees the internal math is perfect, 
            // regardless of whether the user is on Windows 10 or 11 (which have different border sizes).
            this.ClientSize = new Size(finalClientWidth, finalClientHeight);
        }

        #endregion

        #region Event Handler Region

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            CalculateSize();
        }

        #endregion
    }
}
