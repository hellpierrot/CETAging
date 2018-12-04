using System;
using System.Reflection;

namespace Cesco.FW.TestForm.Handlers
{
    /// <summary>
    /// Assembly Handler
    /// </summary>
    public class AssemblyHandler
    {
        Assembly _assembly;
        Type _type;

        public AssemblyHandler()
        { }

        public Assembly Assem
        {
            get { return _assembly; }
            set { _assembly = value; }
        }

        public Type SelectionType
        {
            get { return _type; }
            set { _type = value; }
        }

        public bool GetAssemblyType(out Assembly assem, out Type type)
        {
            type = null;
            if (!GetAssemblyType(out assem)) return false;
            if (!GetAssemblyType(out type)) return false;

            return true;
        }

        public bool GetAssemblyType(out Assembly assem)
        {
            assem = null;
            if (_assembly == null)
            {
                System.Windows.Forms.MessageBox.Show("Assembly 파일이 없습니다.", "파일 오픈 에러");
                return false;
            }

            assem = _assembly;
            return true;
        }

        public bool GetAssemblyType(out Type type)
        {
            type = null;
            if (_type == null)
            {
                System.Windows.Forms.MessageBox.Show("Type(Class) 이 없습니다.", "파일 오픈 에러");
                return false;
            }

            type = _type;
            return true;
        }
    }
}
