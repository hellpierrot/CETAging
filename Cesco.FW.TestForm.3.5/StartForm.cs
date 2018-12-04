using Cesco.FW.TestForm.Controls;
using Cesco.FW.TestForm.Handlers;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Cesco.FW.TestForm
{
    /// <summary>
    /// 테스트 폼 시작
    /// </summary>
    public partial class StartForm : XtraForm
    {
        OpenFileDialog _fileDlg; // 오픈 파일 다이어로그
        string _fileFolder; // 파일 저장용 폴더
        AssemblyHandler _assemblyHandler;
        DataTable _dtClass, _dtConstruct;
        DataTable _dtFavList;

        /// <summary>
        /// 기본 생성자
        /// </summary>
        public StartForm()
        {
            InitializeComponent();
            
            // 오픈파일 다이어로그, 필터, Title 셋팅
            _fileDlg = new OpenFileDialog();
            _fileDlg.Filter = "DLL Files(*.dll)|*.dll|EXE File(*.exe)|*.exe";
            _fileDlg.Title = "실행할 프로젝트가 들어있는 파일의 경로를 선택해 주세요.";

            // 기본값 셋팅
            _fileFolder = string.Format("{0}", Application.StartupPath);
            _assemblyHandler = new AssemblyHandler();

            _dtClass = new DataTable();
            _dtClass.Columns.Add("CODE");
            _dtClass.Columns.Add("NAME");

            lueClass.Properties.DataSource = _dtClass;

            _dtConstruct = new DataTable();
            _dtConstruct.Columns.Add("CODE");
            _dtConstruct.Columns.Add("NAME");
            _dtConstruct.Columns.Add("CINFO", typeof(ConstructorInfo));

            lueConstruct.Properties.DataSource = _dtConstruct;

            _dtFavList = new DataTable();
            _dtFavList.Columns.Add("Seqn", typeof(int));
            _dtFavList.Columns.Add("Name", typeof(string));
            _dtFavList.Columns.Add("TabName", typeof(string));
            _dtFavList.Columns.Add("DllPath", typeof(string));
            _dtFavList.Columns.Add("ClassName", typeof(string));
            _dtFavList.Columns.Add("ConstructName", typeof(string));
            _dtFavList.Columns.Add("Params", typeof(Dictionary<string, string>));

            gridControl2.DataSource = _dtFavList;

            SetDBConnectionFramework();
        }

        private void SetDBConnectionFramework()
        {
            string serverName = "main";
            string optionFolderPath = Application.StartupPath + @"\\conf";
            string optionFilePath = optionFolderPath + @"\\wcfconfig.xml";

            comboBoxEdit1.SelectedIndex = 0;

            textEdit1.EditValue = GetEndpointAddress();

            switch (textEdit1.Text)
            {
                case "http://cesnetdev.cesco.biz/WCF/IISService/WcfCommon/WcfCommonNew.svc": // 개발DB
                    comboBoxEdit1.SelectedIndex = 1;
                    serverName = "dev";
                    break;
                case "http://cesnetedu.cesco.biz/WCF/IISService/WcfCommon/WcfCommonNew.svc": // 교육DB
                    comboBoxEdit1.SelectedIndex = 2;
                    serverName = "edu";
                    break;
                default: // 운영        
                    break;
            }

            if (!Directory.Exists(optionFolderPath))
            {
                Directory.CreateDirectory(optionFolderPath);
            }

            if (!File.Exists(optionFilePath))
            {
                // xml 파일 생성
                XmlDocument option = new XmlDocument();
                XmlNode wcfOption = option.CreateElement("", "WcfOption", "");
                option.AppendChild(wcfOption);
                XmlElement wcfConfig = option.CreateElement("Config");
                wcfConfig.SetAttribute("uri", textEdit1.Text);
                wcfConfig.SetAttribute("db", serverName);

                wcfOption.AppendChild(wcfConfig);
                option.Save(optionFilePath);
            }
            else
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(optionFilePath);
                XmlNode node = doc.SelectSingleNode("/WcfOption/Config");
                XmlAttributeCollection acxNode = node.Attributes;
                node.Attributes["uri"].Value = textEdit1.Text;
                node.Attributes["db"].Value = serverName;
                doc.Save(optionFilePath);
            }
        }

        /// <summary>
        /// 폼 사이즈 변경시 크기 적요에 넣기
        /// </summary>
        private void StartForm_SizeChanged(object sender, EventArgs e)
        {
            txtScreenWidthSize.Text = this.Size.Width.ToString();
            txtScreenHeightSize.Text = this.Size.Height.ToString();
        }

        /// <summary>
        /// 화면 사이즈 콤보박스 변경시 화면크기 셋팅
        /// </summary>
        private void cboScreenSize_EditValueChanged(object sender, EventArgs e)
        {
            string[] size = cboScreenSize.Text.Split('×');

            // 전체화면 처리
            if (cboScreenSize.SelectedIndex == 0)
            {
                this.WindowState = FormWindowState.Maximized;
                return;
            }

            // 2개 이상의 숫자가 없다면 중지
            if (size.Length < 2) return;

            // 높이 너비를 구함
            int width = 0;
            int height = 0;

            if (!int.TryParse(size[0].Trim(), out width)) return;
            if (!int.TryParse(size[1].Trim(), out height)) return;

            // 폼이 최대 상태거나 최소 상태일때 일반으로 변경함
            switch (this.WindowState)
	        {
                case FormWindowState.Maximized:
                case FormWindowState.Minimized:
                    this.WindowState = FormWindowState.Normal;
                    break;
		        default:
                    break;
	        }

            // 높이에서 윈도우 바 크기를 뺌
            int screenHeight = Screen.PrimaryScreen.Bounds.Size.Height;
            int workingHeight = Screen.PrimaryScreen.WorkingArea.Size.Height;
            height = height - (screenHeight - workingHeight);

            // 사이즈 셋팅
            this.Size = new Size(width, height);
        }

        /// <summary>
        /// 내부 컨트롤 사이즈 조회(변경시 마다 셋팅)
        /// </summary>
        private void pncConfig_SizeChanged(object sender, EventArgs e)
        {
            txtUserControlWidthSize.EditValue = pncConfig.Size.Width;
            txtUserControlHeightSize.EditValue = pncConfig.Size.Height;
        }

        /// <summary>
        /// Dll 로드 클릭 이벤트
        /// </summary>
        private void btnDllLoad_Click(object sender, EventArgs e)
        {
            string fileName = GetAssemblyList();

            DllLoad(fileName);
        }

        /// <summary>
        /// DLL 로드
        /// </summary>
        /// <param name="fileName">Dll File Full Path</param>
        private void DllLoad(string fileName)
        {
            // 파일경로가 올바르지 않으면 리턴
            if (fileName.Length == 0) return;

            LoadAssembly(fileName);
            lueClass.ItemIndex = 0;
        }

        /// <summary>
        /// 어셈블리 파일 로드 다이어로그
        /// </summary>
        /// <returns>File Full Path</returns>
        private string GetAssemblyList()
        {
            string filePath = string.Empty;
            _fileDlg.FileName = string.Empty;

            if (_fileDlg.ShowDialog() == DialogResult.OK)
                return _fileDlg.FileName;
            else
                return string.Empty;
        }

        /// <summary>
        /// 어셈블리 파일 처리
        /// </summary>
        /// <param name="path">dll file 경로</param>
        private void LoadAssembly(string path)
        {
            Assembly assem;
            Type[] types;

            // Assembly 파일 로드
            try
            {
                assem = Assembly.LoadFrom(path);
                if (assem == null) throw new Exception("DLL 로드에 실패 했습니다. 지정되지 않은 오류.");
            }
            catch (Exception ex)
            {
                ErrorTraceForm form = new ErrorTraceForm(ex, System.Reflection.MethodBase.GetCurrentMethod());
                form.ShowDialog();
                return;
            }
            
            // 등록된 Class 목록 가져오기
            try
            {
                types = assem.GetTypes();
            }
            catch (ReflectionTypeLoadException ex)
            {
                // 클래스를 로드할 수 없을 경우
                ErrorTraceForm form = new ErrorTraceForm(ex, System.Reflection.MethodBase.GetCurrentMethod());
                form.ShowDialog();
                return;
            }

            // 항목 콤보박스에 담기
            _dtClass.Clear();

            foreach (Type type in types)
            {
                // UserControl, Form 만 처리함 그외는 무시
                if (type.BaseType == null) continue;

                _dtClass.Rows.Add(new object[] { type.FullName, string.Format("({0}) {1}", type.BaseType.Name, type.Name) });
            }

            // 선택 DLL 정보 셋팅
            txtDllPath.Text = path;
            _assemblyHandler.Assem = assem;
        }
        
        /// <summary>
        /// 생성자 리스트 셋팅
        /// </summary>
        private void SetConstructorList()
        {
            string classFullName = lueClass.EditValue.ToString();
            Type classType;
            Assembly assem;
            txtClassName.Text = classFullName;

            if (!_assemblyHandler.GetAssemblyType(out assem)) return;

            // Assembly 안에 Class 를 추출함
            try
            {
                classType = assem.GetType(classFullName);
            }
            catch (Exception ex)
            {
                ErrorTraceForm form = new ErrorTraceForm(ex, System.Reflection.MethodBase.GetCurrentMethod());
                form.ShowDialog();
                return;
            }

            // 추출한 클래스를 Tag에 담음
            _assemblyHandler.SelectionType = classType;

            // 기존 항목 초기화
            _dtConstruct.Clear();
            
            // 생성자 리스트 셋팅
            foreach (ConstructorInfo constructorInfo in classType.GetConstructors())
            {
                StringBuilder param = new StringBuilder();
                string paramString = string.Empty;

                // 파라미터 셋팅
                foreach (ParameterInfo parameterInfo in constructorInfo.GetParameters())
                {
                    if (parameterInfo.Position != 0)
                        param.Append("|");
                    param.AppendFormat("{0} ({1})", parameterInfo.Name, parameterInfo.ParameterType.Name);
                }

                if (param.ToString().Length == 0)
                    paramString = "(기본 빈 생성자)";
                else
                    paramString = param.ToString();
                
                _dtConstruct.Rows.Add(new object[] { constructorInfo.ToString(), paramString, constructorInfo });
            }

            // 최초 빈값 셋팅
            lueConstruct.ItemIndex = 0;
        }

        /// <summary>
        /// 생성자 변경 이벤트
        /// </summary>
        private void cboConstructors_EditValueChanged(object sender, EventArgs e)
        {
            //// 생성자가 선택되지 않으면 실행하지 않음
            //if (cboConstructors.SelectedIndex < 0) return;

            //SetParameter();
        }

        /// <summary>
        /// 파라미터 셋팅
        /// </summary>
        private void SetParameter()
        {
            if (_assemblyHandler.SelectionType == null)
            {
                MessageBox.Show("Class 를 선택해 주세요.", "파라미터 셋팅 에러");
                return;
            }

            ConstructorInfo constructorInfo = lueConstruct.GetColumnValue("CINFO") as ConstructorInfo;

            // 생성자가 올바른지 확인
            if (constructorInfo == null)
            {
                MessageBox.Show("생성자가 올바르지 않습니다.", "파라미터 셋팅 에러");
                return;
            }

            // 테이블 초기화
            gridControl1.DataSource = null;
            gridView1.Columns.Clear();

            // 파라미터가 없으면 리턴
            if (constructorInfo.GetParameters().Length <= 0) return;

            // 셋팅
            gridControl1.DataSource = GetParameterTable(constructorInfo.GetParameters());
            gridView1.AddNewRow();
            gridView1.UpdateCurrentRow();
        }

        /// <summary>
        /// 파라미터 테이블 리턴
        /// </summary>
        /// <param name="parameterInfos">파라미터 정보(리스트)</param>
        /// <returns>테이블</returns>
        private DataTable GetParameterTable(ParameterInfo[] parameterInfos)
        {
            DataTable dtParameters = new DataTable();
            foreach (ParameterInfo parameterInfo in parameterInfos)
            {
                DataColumn col = new DataColumn(parameterInfo.Name);
                col.DataType = parameterInfo.ParameterType;

                // 기본값이 있을 경우 기본값 셋팅
                if (parameterInfo.DefaultValue != null)
                    col.DefaultValue = parameterInfo.DefaultValue;
                dtParameters.Columns.Add(col);
            }
            return dtParameters;
        }

        /// <summary>
        /// 파일 오픈 이벤트
        /// </summary>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenControl();
        }

        /// <summary>
        /// 파일 오픈
        /// </summary>
        private void OpenControl()
        {
            object control;
            Assembly assem;
            Type classType;

            if (!_assemblyHandler.GetAssemblyType(out assem, out classType))
                return;
            
            // 컨트롤 조회
            try
            {
                // 파라미터 값 조회
                object[] args = GetArgs();

                // 불러오기
                control = assem.CreateInstance(
                classType.FullName,
                true,
                BindingFlags.CreateInstance,
                null,
                args,
                null,
                null);

                // 값이 없을 경우
                if (control == null) throw new Exception("컨트롤 조회 결과 값이 없습니다.");
            }
            catch (Exception ex)
            {
                ErrorTraceForm form = new ErrorTraceForm(ex, System.Reflection.MethodBase.GetCurrentMethod());
                form.ShowDialog();
                return;
            }

            // 컨트롤 탭 불러오기
            SetTabPage(assem, classType, control);
        }

        /// <summary>
        /// 탭 페이지 셋팅
        /// </summary>
        /// <param name="assem">Assembly</param>
        /// <param name="classType">Class</param>
        /// <param name="control">컨트롤</param>
        private void SetTabPage(Assembly assem, Type classType, object control)
        {
            XtraTabPage xtraTabPage = new XtraTabPage();
            string tabPageName = "tap_" + DateTime.Now.ToString("yyyyMMddHHmmssfffff");

            xtraTabPage.Name = tabPageName;
            if (txtTabName.Text.Trim().Equals(string.Empty))
                xtraTabPage.Text = classType.FullName;
            else
                xtraTabPage.Text = txtTabName.Text;

            xtraTabControl1.TabPages.Add(xtraTabPage);
            xtraTabControl1.SelectedTabPage = xtraTabPage;

            switch (control.GetType().BaseType.Name)
            {
                case "UserControl":
                    UserControl usercontrol = control as UserControl;
                    usercontrol.Dock = DockStyle.Fill;
                    usercontrol.Name = "UC_" + classType.Name;
                    xtraTabPage.Controls.Add(usercontrol);
                    break;
                case "XtraUserControl":
                    XtraUserControl xtraUserControl = control as XtraUserControl;
                    xtraUserControl.Dock = DockStyle.Fill;
                    xtraUserControl.Name = "XUC_" + classType.Name;
                    xtraTabPage.Controls.Add(xtraUserControl);
                    break;
                case "XtraForm":
                    XtraForm xtraForm = control as XtraForm;
                    xtraForm.Show();
                    break;
                case "Form":
                    Form form = control as Form;
                    form.Show();
                    break;
                default:
                    UserControl defaultUserControl = control as UserControl;
                    defaultUserControl.Dock = DockStyle.Fill;
                    defaultUserControl.Name = "DUC_" + classType.Name;
                    xtraTabPage.Controls.Add(defaultUserControl);
                    break;
            }
        }

        /// <summary>
        /// File Open Args Return
        /// </summary>
        /// <returns>Args</returns>
        private object[] GetArgs()
        {
            List<object> args = new List<object>();
            DataTable dt = (gridControl1.DataSource as DataTable);
            
            // 데이터가 없을 경우 빈 값 리턴
            if (dt == null) return args.ToArray();

            DataRow row = dt.Rows[0];

            foreach (DataColumn col in dt.Columns)
            {
                if (col.DataType == typeof(string))
                    args.Add(row[col].ToString());
                else
                    args.Add(row[col]);
            }

            return args.ToArray();
        }

        /// <summary>
        /// 탭 페이지 삭제 이벤트
        /// </summary>
        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            // Config 탭은 삭제하지 않음
            if (xtraTabControl1.SelectedTabPage == xtpConfig) return;

            DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs arg = e as DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs;
            XtraTabPage xtraTabPage = arg.PrevPage as XtraTabPage;
            if (xtraTabPage == null) return;
            xtraTabControl1.TabPages.Remove(xtraTabPage);
            xtraTabPage.Dispose();
        }

        /// <summary>
        /// Dll File Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SaveDllLoadInfo();
            DllFileLoad();
        }

        private void SaveDllLoadInfo()
        {
            string dllpath = txtDllPath.Text;
            string className = (lueClass.EditValue ?? string.Empty).ToString();
            string constructName = (lueConstruct.EditValue ?? string.Empty).ToString();
            DataTable dtParam = gridControl1.DataSource as DataTable;
            Dictionary<string, string> paramDic = new Dictionary<string, string>();
            string paramNames = string.Empty;
            string name = txtTabName.Text;
            
            if (dtParam != null)
            { 
                foreach (DataColumn col in dtParam.Columns)
                {
                    paramNames += string.Format("['{0}' : '{1}']", col.ColumnName, dtParam.Rows[0][col].ToString());
                    paramDic.Add(col.ColumnName, dtParam.Rows[0][col].ToString());
                }
            }

            StringBuilder sbName = new StringBuilder();

            if (name.Length > 0)
                sbName.AppendLine(name);
            else 
                sbName.AppendLine(className);
            
            sbName.Append(paramNames);

            DataRow row = _dtFavList.NewRow();

            row["Seqn"] = _dtFavList.Rows.Count + 1;
            row["Name"] = sbName.ToString();
            row["DllPath"] = dllpath;
            row["ClassName"] = className;
            row["ConstructName"] = constructName;
            row["Params"] = paramDic;
            row["TabName"] = name;

            _dtFavList.Rows.Add(row);

            XmlSave();
        }

        private void XmlSave()
        {
            XmlDocument doc = new XmlDocument();

            XmlElement masterList = doc.CreateElement("TestFormList");

            foreach (DataRow row in _dtFavList.Rows)
            {
                string dllpath = row["DllPath"].ToString();
                string className = row["ClassName"].ToString();
                string constructName = row["ConstructName"].ToString();
                string tabName = row["TabName"].ToString();
                Dictionary<string, string> paramsDic = row["Params"] as Dictionary<string, string>;

                XmlElement classList = doc.CreateElement("ClassInfo");
                classList.SetAttribute("Seqn", row["Seqn"].ToString());
                classList.SetAttribute("DllPath", dllpath);
                classList.SetAttribute("ClassName", className);
                classList.SetAttribute("ConstructName", constructName);
                classList.SetAttribute("TabName", tabName);
                
                XmlElement paramElement = doc.CreateElement("Param");

                foreach (KeyValuePair<string, string> kv in paramsDic)
                {
                    XmlElement subElement = doc.CreateElement(kv.Key);
                    subElement.SetAttribute("Value", kv.Value);
                    paramElement.AppendChild(subElement);
                }

                classList.AppendChild(paramElement);
                masterList.AppendChild(classList);
            }

            doc.AppendChild(masterList);
            doc.Save(GetFileName());
        }

        private void XmlLoad()
        {
            string fileName = GetFileName();
            if (!File.Exists(fileName)) return;

            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            XmlElement root = doc.DocumentElement;
            
            foreach (XmlNode classInfo in root.ChildNodes)
            {
                string dllpath = classInfo.Attributes["DllPath"].Value;
                string className = classInfo.Attributes["ClassName"].Value;
                string constructName = classInfo.Attributes["ConstructName"].Value;
                string tabName = classInfo.Attributes["TabName"].Value;
                string paramNames = "";

                Dictionary<string, string> paramsDic = new Dictionary<string, string>();
                if (!classInfo.HasChildNodes) continue;
                foreach (XmlNode param in classInfo.ChildNodes[0].ChildNodes)
                {
                    paramsDic.Add(param.Name, param.Attributes["Value"].Value);
                    paramNames += string.Format("['{0}' : '{1}']", param.Name, param.Attributes["Value"].Value);
                }

                StringBuilder sbName = new StringBuilder();

                sbName.AppendLine(tabName);
                sbName.Append(paramNames);

                DataRow row = _dtFavList.NewRow();
                
                row["Seqn"] = classInfo.Attributes["Seqn"].Value;
                row["Name"] = sbName.ToString();
                row["TabName"] = classInfo.Attributes["TabName"].Value;
                row["DllPath"] = classInfo.Attributes["DllPath"].Value;
                row["ClassName"] = classInfo.Attributes["ClassName"].Value;
                row["ConstructName"] = classInfo.Attributes["ConstructName"].Value;
                row["Params"] = paramsDic;

                _dtFavList.Rows.Add(row);
            }
        }

        private void DllFileLoad()
        {

        }

        private string GetFileName()
        {
            return string.Format("{0}\\testform_load_config.cesco", _fileFolder);
        }

        private void SaveInfo(string tabName, string dllPath, string className, string constructor, DataTable parameters)
        {
            
        }

        private void StartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        /// <summary>
        /// 생성자 변경 이벤트
        /// </summary>
        private void lueConstruct_EditValueChanged(object sender, EventArgs e)
        {
            if (lueConstruct.EditValue == null) return;

            SetParameter();
        }

        private void grvConfigList_DoubleClick(object sender, EventArgs e)
        {
            if (grvConfigList.FocusedRowHandle < 0) return;

            DataRow row = grvConfigList.GetFocusedDataRow();
            SetConfig(row);
            btnOpen_Click(btnOpen, new EventArgs());
        }

        private void SetConfig(DataRow row)
        {
            string dllpath = row["DllPath"].ToString();
            string className = row["ClassName"].ToString();
            string constructName = row["ConstructName"].ToString();
            string tabName = row["TabName"].ToString();
            Dictionary<string, string> paramsDic = row["Params"] as Dictionary<string, string>;

            ConfigTableAdd(dllpath, className, constructName, tabName, paramsDic);
        }

        private void ConfigTableAdd(string dllpath, string className, string constructName, string tabName, Dictionary<string, string> paramsDic)
        {
            DllLoad(dllpath);
            lueClass.EditValue = className;
            lueConstruct.EditValue = constructName;
            txtTabName.EditValue = tabName;

            DataTable dt = new DataTable();

            foreach (KeyValuePair<string, string> kv in paramsDic)
            {
                dt.Columns.Add(kv.Key);
            }

            DataRow insertRow = dt.NewRow();

            foreach (KeyValuePair<string, string> kv in paramsDic)
            {
                insertRow[kv.Key] = kv.Value;
            }

            dt.Rows.Add(insertRow);
            gridControl1.DataSource = dt;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            grvConfigList.DeleteSelectedRows();
            XmlSave();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            XmlLoad();
        }
        
        /// <summary>
        /// 클래스가 변경될때 이벤트
        /// </summary>
        private void lueClass_EditValueChanged(object sender, EventArgs e)
        {
            if (lueClass.EditValue == null) return;

            SetConstructorList();
        }

        private static string NodePath = "//system.serviceModel//client//endpoint";
        
        public static string GetEndpointAddress()
        {
            string endpointString = "";
            foreach (XmlNode endpointNode in loadConfigDocument().SelectNodes(NodePath))
            {
                string contractString = endpointNode.Attributes["contract"].Value;

                switch (contractString)
                {
                    case "WcfCommonNew.IWcfCommonNew":
                        endpointString = endpointNode.Attributes["address"].Value;
                        break;
                    default:
                        break;
                }
            }
            
            return endpointString;
        }
        
        public static XmlDocument loadConfigDocument()
        {
            XmlDocument doc = null;
            try
            {
                doc = new XmlDocument();
                doc.Load(getConfigFilePath());
                return doc;
            }
            catch (System.IO.FileNotFoundException e)
            {
                throw new Exception("No configuration file found.", e);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            XtraForm1 xr = new XtraForm1();
            xr.ShowDialog();
        }

        private static string getConfigFilePath()
        {
            return Assembly.GetExecutingAssembly().Location + ".config";
        }
    }
}