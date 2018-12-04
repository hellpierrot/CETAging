using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Cesco.FW.TestForm.Handlers;

namespace Cesco.FW.TestForm.Controls
{
    public partial class ConfigControl : DevExpress.XtraEditors.XtraUserControl
    {
        public string TabName;
        public string DllPath;
        public string ClassName;
        public DataTable Params;
        public string ParamJsonString;
        public string Constructor;

        public ConfigControl()
        {
            InitializeComponent();
        }

        public void Init(string tabName, string dllPath, string className, string constructorName, DataTable paramsTable)
        {
            this.TabName = tabName;
            this.DllPath = dllPath;
            this.ClassName = className;
            this.Params = paramsTable;
            this.Constructor = constructorName;

            JsonHandler jsonHandler = new JsonHandler();
            this.ParamJsonString = jsonHandler.DataTableToJsonObj(paramsTable);

            txtDllPath.Text = dllPath;
            txtClassName.Text = ClassName;
            txtTabName.Text = tabName;
            txtParams.Text = this.ParamJsonString;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            EventArguments.LoadClickEventArgs loadClickEventArgs = new EventArguments.LoadClickEventArgs();

            loadClickEventArgs.ClassName = this.ClassName;
            loadClickEventArgs.DllPath = this.DllPath;
            loadClickEventArgs.ParamJsonString = this.ParamJsonString;
            loadClickEventArgs.Params = this.Params;
            loadClickEventArgs.TabName = this.TabName;
            loadClickEventArgs.Constructor = this.Constructor;

            if (LoadClick != null)
                LoadClick(this, loadClickEventArgs);
        }

        public delegate void LoadClickEvent(object sender, Cesco.FW.TestForm.EventArguments.LoadClickEventArgs e);
        [Description("조회 버튼 클릭 이벤트")]
        public event LoadClickEvent LoadClick;
    }
}
