using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Threading;

namespace Testing_WPF_002
{
    public class FocusedWindowManager
    {

        #region External Methods

        [DllImport("user32.dll")]
        private static extern int GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern int GetWindowText(int hWnd, StringBuilder text, int count);

        #endregion

        DispatcherTimer _dispatcherTimer = new DispatcherTimer();

        private List<FocusedWindow> _learningActivityWindows = new List<FocusedWindow>();

        private Dictionary<string, string> _fileAndProgramNames = new Dictionary<string, string>();

        private TimeSpan _intervalTime = new TimeSpan(0, 0, 5);

        public FocusedWindowManager()
        {
            _dispatcherTimer.Interval = _intervalTime;
            _dispatcherTimer.Tick += DispatcherTimer_Tick;
        }

        /// <summary>
        /// Starts monitoring focused windows.
        /// </summary>
        public void StartWatching()
        {
            _dispatcherTimer.Start();
        }

        /// <summary>
        /// Stops monitoring focused windows.
        /// </summary>
        public void StopWatching()
        {
            _dispatcherTimer.Stop();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            GetFocusedWindow();
        }

        public void GetFocusedWindow()
        {
            int charLength = 256;
            StringBuilder windowNameStringBuilder = new StringBuilder(charLength);

            int handle = GetForegroundWindow();

            if (GetWindowText(handle, windowNameStringBuilder, charLength) > 0)
            {
                FocusedWindow currentWindow = new FocusedWindow(windowNameStringBuilder.ToString(), handle);
                if (currentWindow.IsALearningActivity() && !_learningActivityWindows.Contains(currentWindow))
                {
                    _learningActivityWindows.Add(currentWindow);
                    DictionaryEntry fileAndProgramName = currentWindow.GetProgramNameAndFileName();
                    _fileAndProgramNames.Add(fileAndProgramName.Key.ToString(), fileAndProgramName.Value.ToString());
                    
                    TinCan.SendStatement(currentWindow.FileName);
                }
            }
        }

    }
}
