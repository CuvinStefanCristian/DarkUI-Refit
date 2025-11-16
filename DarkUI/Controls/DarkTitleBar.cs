using DarkUI.Data.Enums;
using DarkUI.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DarkUI.Controls
{
    public class DarkTitleBar : Panel
    {
        #region Field Region
        DarkForm _form;

        private PictureBox pbIcon;
        private DarkLabel lbTitle;
        private DarkButton btnClose;
        private DarkButton btnMaximize;
        private DarkButton btnMinimize;

        private Point _mouseDownLocation;
        private bool _mouseDown;
        private const int DragThreshold = 5; // Pixels to move before starting drag
        #endregion

        public DarkTitleBar(DarkForm form, DarkTitleBarStyle titleBarStyle)
        {
            _form = form;

            InitializeComponent();

            form.Load += DarkDefaultTitleBar_Load;

            if (_form.AllowMoving)
            {
                // Use MouseDown/MouseMove/MouseUp instead of just MouseDown
                MouseDown += TitleBar_MouseDown;
                MouseMove += TitleBar_MouseMove;
                MouseUp += TitleBar_MouseUp;

                pbIcon.MouseDown += TitleBar_MouseDown;
                pbIcon.MouseMove += TitleBar_MouseMove;
                pbIcon.MouseUp += TitleBar_MouseUp;

                lbTitle.MouseDown += TitleBar_MouseDown;
                lbTitle.MouseMove += TitleBar_MouseMove;
                lbTitle.MouseUp += TitleBar_MouseUp;
            }

            DoubleClick += _form.Maximize_Click;
            pbIcon.DoubleClick += _form.Maximize_Click;
            lbTitle.DoubleClick += _form.Maximize_Click;
            btnClose.Click += _form.Close_Click;

            if (titleBarStyle == DarkTitleBarStyle.Standard)
            {
                btnMaximize.Click += _form.Maximize_Click;
                btnMaximize.Visible = true;

                btnMinimize.Click += _form.Minimize_Click;
                btnMinimize.Visible = true;
            }
        }

        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _mouseDown = true;
                _mouseDownLocation = e.Location;
            }
        }

        private void TitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (_mouseDown && e.Button == MouseButtons.Left)
            {
                // Only start dragging if mouse has moved beyond threshold
                int deltaX = Math.Abs(e.Location.X - _mouseDownLocation.X);
                int deltaY = Math.Abs(e.Location.Y - _mouseDownLocation.Y);

                if (deltaX > DragThreshold || deltaY > DragThreshold)
                {
                    _mouseDown = false; // Reset flag to prevent multiple drag starts
                    _form.Drag(sender, e);
                }
            }
        }

        private void TitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseDown = false;
        }

        private void DarkDefaultTitleBar_Load(object sender, EventArgs e)
        {
            lbTitle.Text = _form.Text;

            // Set the icon from the form
            if (_form.Icon != null && _form.ShowIcon)
            {
                pbIcon.Image = _form.Icon.ToBitmap();
                pbIcon.Visible = true;
            }
            else
            {
                pbIcon.Visible = false;
            }
        }

        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager("DarkUI.Icons.DockIcons", typeof(DockIcons).Assembly);
            pbIcon = new PictureBox();
            lbTitle = new DarkLabel();
            btnClose = new DarkButton();
            btnMaximize = new DarkButton();
            btnMinimize = new DarkButton();
            ((System.ComponentModel.ISupportInitialize)(pbIcon)).BeginInit();
            SuspendLayout();
            // 
            // panel
            //
            AutoSize = false;
            BackColor = System.Drawing.Color.FromArgb(60, 63, 65);
            ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            Controls.AddRange(lbTitle, pbIcon, btnMinimize, btnMaximize, btnClose);
            Location = new System.Drawing.Point(0, 0);
            Name = "panel";
            Padding = new Padding(5, 0, 1, 0);
            //
            // pbIcon
            //
            pbIcon.BackColor = System.Drawing.Color.FromArgb(60, 63, 65);
            pbIcon.Dock = DockStyle.Left;
            pbIcon.Name = "pbIcon";
            pbIcon.Size = new System.Drawing.Size(24, 24);
            pbIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            pbIcon.TabStop = false;
            pbIcon.Visible = _form.ShowIcon;
            //
            // lbTitle
            // 
            lbTitle.AutoSize = false; // Changed to false for better control
            lbTitle.BackColor = System.Drawing.Color.FromArgb(60, 63, 65);
            lbTitle.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            lbTitle.Name = "lbTitle";
            lbTitle.Height = 28; // Match the title bar height
            lbTitle.Padding = new Padding(5, 0, 0, 0); // Add left padding
            lbTitle.Text = "<TITLE>";
            lbTitle.Dock = DockStyle.Fill; // Fill the remaining space
            lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // btnClose
            // 
            btnClose.BackColor = System.Drawing.Color.FromArgb(60, 63, 65);
            btnClose.ButtonStyle = DarkButtonStyle.Flat;
            btnClose.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            btnClose.Image = (System.Drawing.Image)resources.GetObject("Close_vs");
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(28, 28); // Made square
            btnClose.Text = string.Empty;
            btnClose.Dock = DockStyle.Right;
            btnClose.TextImageRelation = TextImageRelation.Overlay;
            // 
            // btnMaximize
            // 
            btnMaximize.BackColor = System.Drawing.Color.FromArgb(60, 63, 65);
            btnMaximize.ButtonStyle = DarkButtonStyle.Flat;
            btnMaximize.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            btnMaximize.Image = (System.Drawing.Image)resources.GetObject("PlanePreview");
            btnMaximize.Name = "btnMaximize";
            btnMaximize.Size = new System.Drawing.Size(28, 28); // Made square
            btnMaximize.Text = string.Empty;
            btnMaximize.Visible = false;
            btnMaximize.Dock = DockStyle.Right;
            btnMaximize.TextImageRelation = TextImageRelation.Overlay;
            btnMaximize.Visible = _form.MaximizeBox;
            // 
            // btnMinimize
            // 
            btnMinimize.BackColor = System.Drawing.Color.FromArgb(60, 63, 65);
            btnMinimize.ButtonStyle = DarkButtonStyle.Flat;
            btnMinimize.ForeColor = System.Drawing.Color.FromArgb(220, 220, 220);
            btnMinimize.Image = (System.Drawing.Image)resources.GetObject("RemoveNoColor");
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new System.Drawing.Size(28, 28); // Made square
            btnMinimize.Text = string.Empty;
            btnMinimize.Visible = false;
            btnMinimize.Dock = DockStyle.Right;
            btnMinimize.TextImageRelation = TextImageRelation.Overlay;
            btnMinimize.Visible = _form.MinimizeBox;
            //
            // DarkDefaultTitleBar
            // 
            Size = new System.Drawing.Size(729, 28);
            ((System.ComponentModel.ISupportInitialize)(pbIcon)).EndInit();
            PerformLayout();
            ResumeLayout(false);
        }
    }
}
