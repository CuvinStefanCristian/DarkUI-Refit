using DarkUI.Config;
using DarkUI.Data.Enums;
using DarkUI.Data.Enums.Toast;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DarkUI.Forms
{
    internal partial class DarkToastForm : DarkForm
    {
        #region Field Region

        public ToastPosition ToastPosition;

        int _duration;
        bool _useFadeInAnim;
        Severity _toastSeverity;
        Color _toastColor;

        Point _startingPoint;
        int _elapsedTime; // Added field to track elapsed time

        #endregion

        #region Constructor Region

        public DarkToastForm(Severity toastSeverity, ToastPosition toastPosition, string title, string message, int duration, int animSpeed, bool useFadeInAnim)
        {
            if (useFadeInAnim)
                Opacity = 0;

            switch (toastSeverity)
            {
                case Severity.Info:
                    _toastColor = Colors.Info;
                    break;
                case Severity.Warning:
                    _toastColor = Colors.Warning;
                    break;
                case Severity.Error:
                    _toastColor = Colors.Error;
                    break;
                case Severity.Success:
                    _toastColor = Colors.Success;
                    break;
                default:
                    _toastColor = Colors.Info;
                    break;
            }

            InitializeComponent();

            _toastSeverity = toastSeverity;
            ToastPosition = toastPosition;
            lbTitle.Text = title;

            Width = 400; // Adjusted width for better appearance
            Height = 100; // Adjusted height for better appearance
            StartPosition = FormStartPosition.Manual;

            AdjustFormHeight(CreateGraphics().MeasureString(message, new Font("Arial", 12), messagePanel.Width), messagePanel.Width - 20);

            _duration = duration;
            animTimer.Interval = animSpeed;
            durtionTimer.Interval = animSpeed;
            _useFadeInAnim = useFadeInAnim;

            ComputePosition();
            SetIcon();

            Shown += ShowAnimation;
            messagePanel.Paint += (sender, e) => DrawMessage(e.Graphics, message);
            loadingPanel.Paint += (sender, e) => DrawDuration(e.Graphics);
        }

        #endregion

        #region Events Region

        private void ShowAnimation(object sender, EventArgs e)
        {
            if(_useFadeInAnim)
                durtionTimer.Start();

            animTimer.Start();
        }

        private void Animation(object sender, System.EventArgs e)
        {
            if (_useFadeInAnim)
            {
                // fade in the ToastForm
                Opacity += 0.01;

                if (Opacity == 1)
                {
                    animTimer.Stop();
                }
            }
            else
            {
                // Move the ToastForm up or down
                if (ToastPosition == ToastPosition.TopLeft || ToastPosition == ToastPosition.TopRight)
                {
                    if (Location.Y < _startingPoint.Y)
                        Location = new Point(Location.X, Location.Y + 10);
                    else
                    {
                        durtionTimer.Start();
                        animTimer.Stop();
                    }
                }
                else
                {
                    if (Location.Y > _startingPoint.Y)
                        Location = new Point(Location.X, Location.Y - 10);
                    else
                    {
                        durtionTimer.Start();
                        animTimer.Stop();
                    }
                }
            }
        }

        /// <summary>
        /// Closes the form after the duration has passed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Duration(object sender, EventArgs e)
        {
            _elapsedTime += durtionTimer.Interval;
            loadingPanel.Refresh(); // Use Refresh instead of Invalidate to reduce flickering

            if (_elapsedTime >= _duration)
                Close();
        }

        private void lbClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Methods Region

        /// <summary>
        /// Calculates the position of the Toast based on ToastPosition and Screen size and sets the starting point with the maxHeight.
        /// The position also takes into consideration the animation type (if the animation is not of type "FadeIn" then the position must be offset outside the screen).
        /// </summary>
        private void ComputePosition()
        {
            var screen = Screen.FromControl(this);
            var screenBounds = screen.WorkingArea;

            switch (ToastPosition)
            {
                case ToastPosition.TopLeft:
                    _startingPoint = new Point(screenBounds.Left, screenBounds.Top);
                    break;
                case ToastPosition.TopRight:
                    _startingPoint = new Point(screenBounds.Right - Width, screenBounds.Top);
                    break;
                case ToastPosition.BottomLeft:
                    _startingPoint = new Point(screenBounds.Left, screenBounds.Bottom - Height);
                    break;
                case ToastPosition.BottomRight:
                    _startingPoint = new Point(screenBounds.Right - Width, screenBounds.Bottom - Height);
                    break;
            }

            if (_useFadeInAnim)
                Location = new Point(_startingPoint.X, _startingPoint.Y);
            else if (ToastPosition == ToastPosition.TopLeft || ToastPosition == ToastPosition.TopRight)
                Location = new Point(_startingPoint.X, _startingPoint.Y - Height);
            else
                Location = new Point(_startingPoint.X, _startingPoint.Y + Height);

            //_maxTranslateHight = (Height * 2) + 10;
        }

        private void SetIcon()
        {
            switch (_toastSeverity)
            {
                case Severity.Info:
                    pbIcon.Image = MessageBoxIcons.info;
                    break;
                case Severity.Warning:
                    pbIcon.Image = MessageBoxIcons.warning;
                    break;
                case Severity.Error:
                    pbIcon.Image = MessageBoxIcons.error;
                    break;
                case Severity.Success:
                    pbIcon.Image = MessageBoxIcons.success;
                    break;
                default:
                    pbIcon.Visible = false;
                    tableLayoutPanel2.ColumnStyles[0].Width = 0;
                    return;
            }

            // Scale the icon to fit within the form
            pbIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pbIcon.Size = new Size(40, 40); // Adjusted size for better appearance
        }

        /// <summary>
        /// Adjusts the form height based on the text size and the width of the messagePanel.
        /// </summary>
        /// <param name="textSize"></param>
        /// <param name="rectWidth"></param>
        private void AdjustFormHeight(SizeF textSize, int rectWidth)
        {
            var totalLength = textSize.Width + pbIcon.Width;
            if (totalLength > rectWidth)
            {
                int lines = (int)Math.Ceiling(totalLength / rectWidth);
                Height += (int)(textSize.Height * lines) / 2;
            }
        }

        #endregion

        #region Paint Region

        /// <summary>
        /// Draws the message text on the messagePanel.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="message"></param>
        private void DrawMessage(Graphics g, string message)
        {
            using Font font = new Font("Arial", 12);
            using Brush brush = new SolidBrush(Color.White);
            StringFormat format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            Rectangle rect = new(10, 10, messagePanel.Width - 20, messagePanel.Height - 20);
            SizeF textSize = g.MeasureString(message, font, rect.Width);

            g.DrawString(message, font, brush, rect, format);
        }

        /// <summary>
        /// Draws the duration bar on the loadingPanel calculated based on the duration and controlled by the duration timer.
        /// </summary>
        /// <param name="g"></param>
        private void DrawDuration(Graphics g)
        {
            int width = (int)((_elapsedTime / (float)_duration) * loadingPanel.Width);
            using Brush brush = new SolidBrush(_toastColor);
            g.FillRectangle(brush, 0, 0, width, loadingPanel.Height);
        }

        #endregion
    }
}
