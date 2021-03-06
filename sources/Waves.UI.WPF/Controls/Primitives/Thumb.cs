﻿using System.Windows.Input;
using Waves.UI.WPF.Controls.Primitives.Interfaces;

namespace Waves.UI.WPF.Controls.Primitives
{
    /// <summary>
    ///     Thumb.
    /// </summary>
    public class Thumb : System.Windows.Controls.Primitives.Thumb, IThumb
    {
        private TouchDevice _currentDevice;

        /// <inheritdoc />
        protected override void OnPreviewTouchDown(TouchEventArgs e)
        {
            // Release any previous capture
            ReleaseCurrentDevice();
            // Capture the new touch
            CaptureCurrentDevice(e);
        }

        /// <inheritdoc />
        protected override void OnPreviewTouchUp(TouchEventArgs e)
        {
            ReleaseCurrentDevice();
        }

        /// <inheritdoc />
        protected override void OnLostTouchCapture(TouchEventArgs e)
        {
            // Only re-capture if the reference is not null
            // This way we avoid re-capturing after calling ReleaseCurrentDevice()
            if (_currentDevice != null) CaptureCurrentDevice(e);
        }

        /// <summary>
        ///     Releases device.
        /// </summary>
        private void ReleaseCurrentDevice()
        {
            if (_currentDevice == null) return;

            // Set the reference to null so that we don't re-capture in the OnLostTouchCapture() method
            var temp = _currentDevice;
            _currentDevice = null;
            ReleaseTouchCapture(temp);
        }

        /// <summary>
        ///     Captures current device.
        /// </summary>
        /// <param name="e">Arguments.</param>
        private void CaptureCurrentDevice(TouchEventArgs e)
        {
            var gotTouch = CaptureTouch(e.TouchDevice);
            if (gotTouch) _currentDevice = e.TouchDevice;
        }
    }
}