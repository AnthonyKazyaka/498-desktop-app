using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace Testing_WPF_002
{
    public class FocusedWindow : IEquatable<FocusedWindow>
    {
        public string WindowTitle
        {
            get; private set;
        }

        public string ProgramName
        {
            get; private set;
        }

        public string FileName
        {
            get; private set;
        }

        private int _windowHandle;
        public int WindowHandle {get { return _windowHandle; }}

        public FocusedWindow(string name, int _handle)
        {
            WindowTitle = name;
            this._windowHandle = _handle;
        }

        public bool Equals(FocusedWindow other)
        {
            if (other.WindowHandle == WindowHandle)
            {
                return true;
            }
            return false;
        }


        public bool IsALearningActivity()
        {
            if (WindowTitle.Contains(" - Word"))
            {
                return true;
            }
            return false;
        }

        public DictionaryEntry GetProgramNameAndFileName()
        {
            if (WindowTitle.Contains(" - Word"))
            {
                ProgramName = "Microsoft Word";
                FileName = WindowTitle.Remove(WindowTitle.IndexOf(" - Word"));            
            }
            return new DictionaryEntry(FileName, ProgramName);
        }

    }
}
