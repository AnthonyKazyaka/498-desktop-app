using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RusticiSoftware.TinCanAPILibrary;
using RusticiSoftware.TinCanAPILibrary.Model;

namespace Testing_WPF_002
{
    class TinCan
    {
        private static bool tri = false;

        public static void ConnectToTinCan(string usrName, string passwd)
        {
            try
            {
                TCAPI tincan = new TCAPI(new Uri("http://35.9.22.105:8000/xapi"), new BasicHTTPAuth(usrName, passwd),
                    RusticiSoftware.TinCanAPILibrary.Helper.TCAPIVersion.TinCan1p0p0);
            }

        }

        public static void SendStatement()
        {
            //TODO
        }
    }
}
