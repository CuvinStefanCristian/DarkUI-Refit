using DarkUI.Config;
using DarkUI.Data.Enums;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DarkUI.Controls
{
    [ToolboxItem(true)]
    public partial class DarkCircularProgress : Panel
    {
        #region Field Region

        private int _value, _speed;
        private bool _isIndeterminate = false;

        private Color _color;
        private Severity _severity;

        private int _padding, _size, _centerX, _centerY, _radius;

        #endregion

        #region Property Region

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int Value
        {
            get { return _value; }
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException("Value", "Value must be between 0 and 100");
                _value = value;

                Invalidate();
            }
        }

        [Category("Behavior")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int Speed
        {
            get { return _speed; }
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("Speed", "Speed must be greater than 0");
                _speed = value;
            }
        }

        [Category("Behaviour")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool IsIndeterminate
        {
            get { return _isIndeterminate; }
            set
            {
                _isIndeterminate = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(typeof(Color), "DodgerBlue")]
        public Color Color
        {
            get { return _color; }
            set
            {
                _color = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Severity Severity
        {
            get { return _severity; }
            set
            {
                _severity = value;
                switch (_severity)
                {
                    case Severity.Info:
                        _color = Colors.Info;
                        break;
                    case Severity.Warning:
                        _color = Colors.Warning;
                        break;
                    case Severity.Error:
                        _color = Colors.Error;
                        break;
                    case Severity.Success:
                        _color = Colors.Success;
                        break;
                    default:
                        _color = Colors.BlueSelection;
                        break;
                }
                Invalidate();
            }
        }

        #endregion

        #region Constructor Region

        public DarkCircularProgress()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            _speed = 5;

            SizeChanged += (sender, e) => CalculateBounds();
        }

        #endregion

        #region Method Region

        private void CalculateBounds()
        {
            // Calculate center and size with padding
            _padding = 10; // Adjust padding as needed
            _size = Math.Min(Width, Height) - _padding * 2;
            _centerX = Width / 2;
            _centerY = Height / 2;
            _radius = _size / 2;
        }

        #endregion

        #region Paint Region

        // Paints the control progress
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (_isIndeterminate)
            {
                DrawIndeterminate(e.Graphics);
            }
            else
            {
                DrawDeterminate(e.Graphics);
            }
        }

        /// <summary>
        /// Draws the indeterminate progress
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawIndeterminate(Graphics graphics)
        {
            // Use high quality rendering
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Calculate the current angle based on time, applying speed
            // Higher speed value means faster rotation
            int animationOffset = (int)(DateTime.Now.TimeOfDay.TotalMilliseconds * _speed / 50) % 360;

            // Create a pen with specified color or default if not set
            using (Pen progressPen = new Pen(_color != Color.Empty ? _color : Color.DodgerBlue, 4))
            {
                // Draw a quarter of a circle (90 degrees)
                Rectangle drawRect = new Rectangle(_centerX - _radius, _centerY - _radius, _size, _size);
                graphics.DrawArc(progressPen, drawRect, animationOffset, 90);
            }

            // Trigger repaint to animate
            if (DesignMode == false)
                this.BeginInvoke(new Action(() => { this.Invalidate(); }));
        }

        private void DrawDeterminate(Graphics graphics)
        {
            // Use high quality rendering
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Calculate center and size with padding
            int padding = 10; // Adjust padding as needed
            int size = Math.Min(Width, Height) - padding * 2;
            int centerX = Width / 2;
            int centerY = Height / 2;
            int radius = size / 2;

            // Calculate the angle based on the current value (0-360 degrees)
            float angle = 360f * _value / 100f;

            // Create a pen with specified color or default if not set
            using (Pen progressPen = new Pen(_color != Color.Empty ? _color : Color.DodgerBlue, 4))
            {
                // Draw the progress arc
                Rectangle drawRect = new Rectangle(centerX - radius, centerY - radius, size, size);
                graphics.DrawArc(progressPen, drawRect, -90, angle); // Start from top (negative 90 degrees)
            }
        }

        #endregion
    }
}
