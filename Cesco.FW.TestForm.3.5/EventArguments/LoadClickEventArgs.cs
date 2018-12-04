using System;
using System.Data;

namespace Cesco.FW.TestForm.EventArguments
{
    public class LoadClickEventArgs : EventArgs
    {
        public string TabName;
        public string DllPath;
        public string ClassName;
        public DataTable Params;
        public string ParamJsonString;
        public string Constructor;

        public LoadClickEventArgs()
        { 
            
        }
    }
}
