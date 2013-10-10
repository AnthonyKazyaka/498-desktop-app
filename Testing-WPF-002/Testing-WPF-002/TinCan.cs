using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RusticiSoftware.TinCanAPILibrary;
using RusticiSoftware.TinCanAPILibrary.Model;
using System.Windows.Forms;

namespace Testing_WPF_002
{
    class TinCan
    {
        private static bool tri = false;
        private static TCAPI tincan;

        public static void ConnectToTinCan(string usrName, string passwd)
        {
            try
            {
                tincan = new TCAPI(new Uri("http://35.9.22.105:8000/xapi"), new BasicHTTPAuth(usrName, passwd),
                            RusticiSoftware.TinCanAPILibrary.Helper.TCAPIVersion.TinCan1p0p0);
            }
            catch (Exception e)
            {
                const string msg = "Invalid login information.  Please re-try.";
            }

        }

        public static void SendStatement(string usrName)
        {
            string email = "mailto:";
            email += usrName;
            Statement[] statements = new Statement[1];
            Activity newAct = new Activity("http://35.9.22.105/xapi");
            newAct.Definition = new ActivityDefinition();
            newAct.Definition.Name = new LanguageMap();
            newAct.Definition.Name.Add("en-US", "Testing Windows App");
            statements[0] = new Statement(new Actor(usrName, email), new StatementVerb(PredefinedVerbs.Created), newAct);
            tincan.StoreStatements(statements);
            tri = true;
        }
    }
}
