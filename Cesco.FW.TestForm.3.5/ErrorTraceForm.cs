using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Cesco.FW.TestForm
{
    public partial class ErrorTraceForm : Form
    {
        public ErrorTraceForm()
        {
            InitializeComponent();
        }

        public ErrorTraceForm(Exception ex, System.Reflection.MethodBase mb)
        {
            InitializeComponent();
            splitContainer2.Panel1.Padding = new Padding(5, 5, 5, 5);

            txtExceptionTypeName.Text = string.Format("{0}.{1} ({2})", mb.ReflectedType, mb.Name, ex.GetType().FullName);
            txtErrorMessage.Text = ex.Message;
            
            SetException(ex);
        }

        void SetException(Exception ex)
        {
            treeView1.Nodes.Add("_", ex.GetType().FullName);
            treeView1.Nodes["_"].Tag = ex.ToString();
            TreeNodeCollection nodes = treeView1.Nodes["_"].Nodes;
            
            SetProperties(nodes, ex.GetType(), 1, ex);
        }

        void SetProperties(TreeNodeCollection nodes, Type type, int level, object ex)
        {
            foreach (PropertyInfo prop in type.GetProperties())
            {
                if (prop == null) continue;

                string nodeKey = string.Format("{0}{1}", level.ToString(), prop.Name);
                string nodeName = string.Format("{0} ({1})", prop.Name, prop.PropertyType.Name);
                object objValue = prop.GetValue(ex, null);

                nodes.Add(nodeKey, nodeName);
                nodes[nodeKey].Tag = (objValue ?? "Null 값 입니다.").ToString();

                if (objValue == null) continue;
                
                switch (prop.PropertyType.Name)
                {
                    case "IDictionary":
                        SetIDictionary(nodes[nodeKey].Nodes, objValue, level + 1);
                        break;
                    case "Exception":
                        SetProperties(nodes[nodeKey].Nodes, objValue.GetType(), level + 1, objValue);
                        break;
                    default:
                        break;
                }
            }
        }

        void SetIDictionary(TreeNodeCollection nodes, object obj, int level)
        {
            IDictionary dic = obj as IDictionary;
            IEnumerator enumObj = dic.GetEnumerator();
            DictionaryEntry de;

            while (enumObj.MoveNext())
            {
                de = (DictionaryEntry)enumObj.Current;

                string nodeKey = string.Format("{0}{1}", level.ToString(), de.Key);
                string nodeName = string.Format("{0} ({1})", de.Key, de.Value.GetType().Name);

                nodes.Add(nodeKey, nodeName);
                nodes[nodeKey].Tag = (de.Value ?? "Null 값 입니다.").ToString();
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == null) return;
            if (e.Node.Tag == null) { textBox1.Text = "데이터가 없습니다."; }
            else
            {
                textBox1.Text = e.Node.Tag.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!splitContainer2.Panel2Collapsed)
            {
                button1.Text = "자세히";
                
                if (this.WindowState == FormWindowState.Maximized)
                    return;
                
                this.Size = new Size(this.Width, this.Height - 300);
                splitContainer2.Panel1.Padding = new Padding(5, 5, 5, 5);
            }
            else
            {
                button1.Text = "숨기기";

                if (this.WindowState == FormWindowState.Maximized)
                    return;
                
                this.Size = new Size(this.Width, this.Height + 300);
                splitContainer2.Panel1.Padding = new Padding(5, 5, 5, 0);
            }
            
            splitContainer2.Panel2Collapsed = !splitContainer2.Panel2Collapsed;
            splitContainer2.SplitterDistance = 146;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
