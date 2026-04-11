using DarkUI.Config;
using DarkUI.Controls;
using DarkUI.Data.Enums;
using DarkUI.Win32;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DarkUI.Forms
{
    public class DarkMetroForm : DarkForm
    {
        #region Field Region

        private bool _flatBorder, _allowResize = true, _allowMoving = true;
        private const int _borderWidth = 2;
        private const int resizeAreaSize = 10;
        private Size _formSize;
        private DarkTitleBar _titleBar;
        private DarkTitleBarStyle _titleBarStyle = DarkTitleBarStyle.Standard;

        [DllImport("user32.dll")]
        protected static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        protected static extern bool ReleaseCapture();

        #endregion

        #region Property Region

        [Category("Appearance")]
        [Description("Determines whether a single pixel border should be rendered around the form.")]
        [DefaultValue(false)]
        public bool FlatBorder
        {
            get { return _flatBorder; }
            set
            {
                _flatBorder = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("Determines whether the form can be resized by the user.")]
        [DefaultValue(true)]
        public bool AllowResize
        {
            get => _allowResize;
            set
            {
                _allowResize = value;

                if (value)
                    FormBorderStyle = FormBorderStyle.Sizable;
                else
                    FormBorderStyle = FormBorderStyle.FixedSingle;

                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("Determines whether the form can be moved by the user.")]
        [DefaultValue(true)]
        public bool AllowMoving
        {
            get => _allowMoving;
            set
            {
                _allowMoving = value;

                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("Sets the style of the Default TitleBar")]
        [DefaultValue(DarkTitleBarStyle.Standard)]
        public DarkTitleBarStyle TitleBarStyle
        {
            get => _titleBarStyle;
            set
            {
                _titleBarStyle = value;
                if (value != DarkTitleBarStyle.None)
                    AddTitleBar();

                Invalidate();
            }
        }

        #endregion

        #region Constructor Region

        public DarkMetroForm()
        {
            BackColor = Colors.GreyBackground;
            Padding = new Padding(_borderWidth);

            Resize += Resize_Form;
            Load += (sender, args) => _formSize = ClientSize;
        }

        #endregion

        #region Paint Region

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            if (!_flatBorder)
                return;

            var g = e.Graphics;

            using (var p = new Pen(Colors.DarkBorder))
            {
                var modRect = new Rectangle(ClientRectangle.Location, new Size(ClientRectangle.Width - 1, ClientRectangle.Height - 1));
                g.DrawRectangle(p, modRect);
            }
        }

        #endregion

        #region Events

        private void Resize_Form(object sender, EventArgs e)
        {
            if (!_allowResize)
                return;

            _formSize = ClientSize;

            switch (this.WindowState)
            {
                case FormWindowState.Maximized:
                    this.Padding = new Padding(8);
                    break;
                case FormWindowState.Normal:
                    if (Padding.Top != _borderWidth)
                        this.Padding = new Padding(_borderWidth);
                    break;
            }
        }

        public void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            Drag(sender, e);
        }

        public void Minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        public void Maximize_Click(object sender, EventArgs e)
        {
            WindowState = WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
        }

        public void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Methods

        public void AddTitleBar()
        {
            _titleBar = new(this, _titleBarStyle)
            {
                Dock = DockStyle.Top
            };

            Controls.Add(_titleBar);
        }

        public void Drag(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && AllowMoving)
            {
                ReleaseCapture();
                _ = SendMessage(Handle, 0x112, 0xf012, 0);
            }
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // DarkMetroForm
            // 
            ClientSize = new Size(284, 261);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DarkMetroForm";
            ResumeLayout(false);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == (int)WM.NCHITTEST)
            { //If the windows m is WM_NCHITTEST
                base.WndProc(ref m);
                if (this.WindowState == FormWindowState.Normal)//Resize the form if it is in normal state
                {
                    if ((int)m.Result == (int)WMR.HTCLIENT)//If the result of the m (mouse pointer) is in the client area of the window
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32()); //Gets screen point coordinates(X and Y coordinate of the pointer)                           
                        Point clientPoint = this.PointToClient(screenPoint); //Computes the location of the screen point into client coordinates                          
                        if (clientPoint.Y <= resizeAreaSize)//If the pointer is at the top of the form (within the resize area- X coordinate)
                        {
                            if (clientPoint.X <= resizeAreaSize) //If the pointer is at the coordinate X=0 or less than the resizing area(X=10) in 
                                m.Result = (IntPtr)(int)WMR.HTTOPLEFT; //Resize diagonally to the left
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize))//If the pointer is at the coordinate X=11 or less than the width of the form(X=Form.Width-resizeArea)
                                m.Result = (IntPtr)(int)WMR.HTTOP; //Resize vertically up
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)(int)WMR.HTTOPRIGHT;
                        }
                        else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize)) //If the pointer is inside the form at the Y coordinate(discounting the resize area size)
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize horizontally to the left
                                m.Result = (IntPtr)(int)WMR.HTLEFT;
                            else if (clientPoint.X > (this.Width - resizeAreaSize))//Resize horizontally to the right
                                m.Result = (IntPtr)(int)WMR.HTRIGHT;
                        }
                        else
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize diagonally to the left
                                m.Result = (IntPtr)(int)WMR.HTBOTTOMLEFT;
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize)) //Resize vertically down
                                m.Result = (IntPtr)(int)WMR.HTBOTTOM;
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)(int)WMR.HTBOTTOMRIGHT;
                        }
                    }
                }
                return;
            }

            //Remove border and keep snap window
            if (m.Msg == (int)WM.NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }
            //Keep form size when it is minimized and restored. Since the form is resized because it takes into account the size of the title bar and borders.
            if (m.Msg == (int)WM.SYSCOMMAND)
            {
                /// <see cref="https://docs.microsoft.com/en-us/windows/win32/menurc/wm-syscommand"/>
                /// Quote:
                /// In WM_SYSCOMMAND messages, the four low - order bits of the wParam parameter 
                /// are used internally by the system.To obtain the correct result when testing 
                /// the value of wParam, an application must combine the value 0xFFF0 with the 
                /// wParam value by using the bitwise AND operator.
                int wParam = (m.WParam.ToInt32() & 0xFFF0);
                if (wParam == (int)WM.SC_MINIMIZE)  //Before
                    _formSize = this.ClientSize;
                if (wParam == (int)WM.SC_RESTORE)// Restored form(Before)
                    this.Size = _formSize;
            }
            base.WndProc(ref m);
        }

        #endregion
    }
}
