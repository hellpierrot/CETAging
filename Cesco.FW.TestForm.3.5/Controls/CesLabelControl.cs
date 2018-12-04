using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Cesco.FW.TestForm.Controls
{
    public partial class CesLabelControl : DevExpress.XtraEditors.XtraUserControl
    {
        bool _isRequired = false;
        bool _isReadOnly = false;

        public CesLabelControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 레벨 텍스트
        /// </summary>
        [Description("라벨 텍스트"), DefaultValue("라벨명")]
        public string LabelText
        {
            get { return labelControl1.Text; }
            set { labelControl1.Text = value; }
        }

        /// <summary>
        /// 레벨 텍스트
        /// </summary>
        [Description("필수값 여부"), DefaultValue(false)]
        public bool IsRequired
        {
            get
            {
                return _isRequired;
            }
            set
            {
                if (value) labelControl3.Text = "*";
                else labelControl3.Text = string.Empty;
                _isRequired = value;
            }
        }

        /// <summary>
        /// 라인 색상
        /// </summary>
        [Description("라인 색상"), DefaultValue(typeof(Color), "LightGray")]
        public Color LineColor
        {
            get { return pnlLabel.BackColor; }
            set
            {
                pnlLabel.BackColor = value;
                pnlReq.BackColor = value;
            }
        }

        /// <summary>
        /// 글자 색상
        /// </summary>
        [Description("라벨 글자 색상"), DefaultValue(typeof(Color), "Black")]
        public Color LabelFontColor
        {
            get { return labelControl1.ForeColor; }
            set
            {
                labelControl1.ForeColor = value;
            }
        }

        /// <summary>
        /// 읽기 전용 여부
        /// </summary>
        [Description("필수값 여부"), DefaultValue(false)]
        public bool IsReadOnly
        {
            get
            {
                return _isReadOnly;
            }
            set
            {
                System.Drawing.Font font = labelControl1.Font;

                if (value)
                {
                    labelControl1.Font = new Font(font.FontFamily, font.Size);
                    labelControl1.ForeColor = Color.DimGray;
                }
                else
                {
                    labelControl1.Font = new Font(font.FontFamily, font.Size);
                    labelControl1.ForeColor = Color.Black;
                }

                _isReadOnly = value;
            }
        }
    }
}
