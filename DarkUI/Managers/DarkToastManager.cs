using DarkUI.Data.Enums;
using DarkUI.Data.Enums.Toast;
using DarkUI.Data.Models;
using DarkUI.Forms;
using System.Collections.Generic;
using System.Linq;

namespace DarkUI.Managers
{
    /// <summary>
    /// Manages toast notifications.
    /// </summary>
    public static class DarkToastManager
    {
        public static DarkToastOptions DarkToastOptions { get; set; } = new DarkToastOptions();
        public static bool OverrideLastToast { get; set; } = true;

        static List<DarkToastForm> _toasts = [];

        /// <summary>
        /// Shows a toast notification with the specified parameters.
        /// </summary>
        public static void ShowToast(Severity toastSeverity, string title, string message, ToastPosition? toastPosition = null, int? duration = null, int? animSpeed = null, bool? useFadeInAnim = null)
        {
            if (_toasts.Count == DarkToastOptions.MaxToasts)
            {
                if (OverrideLastToast)
                {
                    _toasts[0].Close();
                    _toasts.RemoveAt(0);
                }
                else return;
            }

            var toast = new DarkToastForm(toastSeverity, toastPosition ?? DarkToastOptions.DefaultPosition, title, message,
                duration ?? DarkToastOptions.DefaultDuration, animSpeed ?? (int)DarkToastOptions.DefaultAnimSpeed,
                useFadeInAnim ?? DarkToastOptions.DefaultUseFadeInAnim);

            // Move existing toasts up
            foreach (var existingToast in _toasts)
            {
                if (existingToast.ToastPosition == toast.ToastPosition)
                {
                    if(existingToast.ToastPosition == ToastPosition.TopLeft || existingToast.ToastPosition == ToastPosition.TopRight)
                        existingToast.Location = new System.Drawing.Point(existingToast.Location.X, existingToast.Location.Y + toast.Height);
                    else
                        existingToast.Location = new System.Drawing.Point(existingToast.Location.X, existingToast.Location.Y - toast.Height);
                }
            }

            _toasts.Add(toast);
            toast.FormClosed += ToastClosed;

            toast.Show();
        }

        /// <summary>
        /// Shows an info toast notification.
        /// </summary>
        public static void ShowInfo(string title, string message, int? duration = null, int? animSpeed = null, bool? useFadeInAnim = null)
        {
            ShowToast(Severity.Info, title, message, DarkToastOptions.DefaultPosition, duration, animSpeed, useFadeInAnim);
        }

        /// <summary>
        /// Shows a success toast notification.
        /// </summary>
        public static void ShowSuccess(string title, string message, int? duration = null, int? animSpeed = null, bool? useFadeInAnim = null)
        {
            ShowToast(Severity.Success, title, message, DarkToastOptions.DefaultPosition, duration, animSpeed, useFadeInAnim);
        }

        /// <summary>
        /// Shows a warning toast notification.
        /// </summary>
        public static void ShowWarning(string title, string message, int? duration = null, int? animSpeed = null, bool? useFadeInAnim = null)
        {
            ShowToast(Severity.Warning, title, message, DarkToastOptions.DefaultPosition, duration, animSpeed, useFadeInAnim);
        }

        /// <summary>
        /// Shows an error toast notification.
        /// </summary>
        public static void ShowError(string title, string message, int? duration = null, int? animSpeed = null, bool? useFadeInAnim = null)
        {
            ShowToast(Severity.Error, title, message, DarkToastOptions.DefaultPosition, duration, animSpeed, useFadeInAnim);
        }

        /// <summary>
        /// Closes all currently displayed toast notifications.
        /// </summary>
        public static void CloseAllToasts()
        {
            var toastsCopy = _toasts.ToList();
            foreach (var toast in toastsCopy)
                toast.Close();
        }

        /// <summary>
        /// Event handler for when a toast notification is closed.
        /// </summary>
        private static void ToastClosed(object sender, System.EventArgs e)
        {
            _toasts.Remove(sender as DarkToastForm);
        }
    }
}
