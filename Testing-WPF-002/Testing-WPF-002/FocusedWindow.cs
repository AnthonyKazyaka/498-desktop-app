using System;
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
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _untrimmedName;

        private int _windowHandle;
        public int WindowHandle
        {
            get { return _windowHandle; }
        }

        public FocusedWindow(string name, int _handle)
        {
            Name = name;
            _untrimmedName = name;
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
            if (Name.Contains(" - Word"))
            {
                TrimName();
                return true;
            }
            return false;
        }

        public void TrimName()
        {
            Name = Name.Remove(Name.IndexOf(" - Word"));            
        }

    }
}
