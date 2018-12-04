namespace Cesco.FW.TestForm.Controls
{
    partial class ConfigControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.txtTabName = new DevExpress.XtraEditors.TextEdit();
            this.btnDel = new DevExpress.XtraEditors.SimpleButton();
            this.btnLoad = new DevExpress.XtraEditors.SimpleButton();
            this.txtClassName = new DevExpress.XtraEditors.TextEdit();
            this.txtDllPath = new DevExpress.XtraEditors.TextEdit();
            this.txtParams = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.cesLabelControl6 = new Cesco.FW.TestForm.Controls.CesLabelControl();
            this.cesLabelControl3 = new Cesco.FW.TestForm.Controls.CesLabelControl();
            this.cesLabelControl7 = new Cesco.FW.TestForm.Controls.CesLabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtTabName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClassName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDllPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtParams.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Appearance.BorderColor = System.Drawing.Color.LightGray;
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.simpleButton1.Appearance.Options.UseBorderColor = true;
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Appearance.Options.UseTextOptions = true;
            this.simpleButton1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.simpleButton1.Location = new System.Drawing.Point(604, 0);
            this.simpleButton1.LookAndFeel.SkinName = "Office 2013";
            this.simpleButton1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(20, 20);
            this.simpleButton1.TabIndex = 214;
            this.simpleButton1.Text = "∨";
            // 
            // txtTabName
            // 
            this.txtTabName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTabName.EditValue = "";
            this.txtTabName.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txtTabName.Location = new System.Drawing.Point(113, 0);
            this.txtTabName.Name = "txtTabName";
            this.txtTabName.Properties.Appearance.BorderColor = System.Drawing.Color.LightGray;
            this.txtTabName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtTabName.Properties.Appearance.Options.UseBorderColor = true;
            this.txtTabName.Properties.Appearance.Options.UseFont = true;
            this.txtTabName.Properties.AutoHeight = false;
            this.txtTabName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtTabName.Properties.ReadOnly = true;
            this.txtTabName.Size = new System.Drawing.Size(368, 20);
            this.txtTabName.TabIndex = 216;
            this.txtTabName.Tag = "";
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.Appearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnDel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnDel.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btnDel.Appearance.Options.UseBorderColor = true;
            this.btnDel.Appearance.Options.UseFont = true;
            this.btnDel.Appearance.Options.UseForeColor = true;
            this.btnDel.Appearance.Options.UseTextOptions = true;
            this.btnDel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnDel.Location = new System.Drawing.Point(534, 0);
            this.btnDel.LookAndFeel.SkinName = "Office 2013";
            this.btnDel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(50, 20);
            this.btnDel.TabIndex = 218;
            this.btnDel.Text = "Del";
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Appearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnLoad.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLoad.Appearance.Options.UseBorderColor = true;
            this.btnLoad.Appearance.Options.UseFont = true;
            this.btnLoad.Appearance.Options.UseTextOptions = true;
            this.btnLoad.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnLoad.Location = new System.Drawing.Point(484, 0);
            this.btnLoad.LookAndFeel.SkinName = "Office 2013";
            this.btnLoad.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(50, 20);
            this.btnLoad.TabIndex = 219;
            this.btnLoad.Text = "Load";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtClassName
            // 
            this.txtClassName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClassName.EditValue = "";
            this.txtClassName.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txtClassName.Location = new System.Drawing.Point(319, 22);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Properties.Appearance.BorderColor = System.Drawing.Color.LightGray;
            this.txtClassName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtClassName.Properties.Appearance.Options.UseBorderColor = true;
            this.txtClassName.Properties.Appearance.Options.UseFont = true;
            this.txtClassName.Properties.AutoHeight = false;
            this.txtClassName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtClassName.Properties.ReadOnly = true;
            this.txtClassName.Size = new System.Drawing.Size(305, 20);
            this.txtClassName.TabIndex = 223;
            this.txtClassName.Tag = "";
            // 
            // txtDllPath
            // 
            this.txtDllPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDllPath.EditValue = "";
            this.txtDllPath.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txtDllPath.Location = new System.Drawing.Point(113, 22);
            this.txtDllPath.Name = "txtDllPath";
            this.txtDllPath.Properties.Appearance.BorderColor = System.Drawing.Color.LightGray;
            this.txtDllPath.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtDllPath.Properties.Appearance.Options.UseBorderColor = true;
            this.txtDllPath.Properties.Appearance.Options.UseFont = true;
            this.txtDllPath.Properties.AutoHeight = false;
            this.txtDllPath.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtDllPath.Properties.ReadOnly = true;
            this.txtDllPath.Size = new System.Drawing.Size(204, 20);
            this.txtDllPath.TabIndex = 225;
            this.txtDllPath.Tag = "";
            // 
            // txtParams
            // 
            this.txtParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParams.EditValue = "";
            this.txtParams.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txtParams.Location = new System.Drawing.Point(113, 44);
            this.txtParams.Name = "txtParams";
            this.txtParams.Properties.Appearance.BorderColor = System.Drawing.Color.LightGray;
            this.txtParams.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtParams.Properties.Appearance.Options.UseBorderColor = true;
            this.txtParams.Properties.Appearance.Options.UseFont = true;
            this.txtParams.Properties.AutoHeight = false;
            this.txtParams.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtParams.Properties.ReadOnly = true;
            this.txtParams.Size = new System.Drawing.Size(511, 20);
            this.txtParams.TabIndex = 228;
            this.txtParams.Tag = "";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton2.Appearance.BorderColor = System.Drawing.Color.LightGray;
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.simpleButton2.Appearance.Options.UseBorderColor = true;
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Appearance.Options.UseTextOptions = true;
            this.simpleButton2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.simpleButton2.Location = new System.Drawing.Point(584, 0);
            this.simpleButton2.LookAndFeel.SkinName = "Office 2013";
            this.simpleButton2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(20, 20);
            this.simpleButton2.TabIndex = 217;
            this.simpleButton2.Text = "∧";
            // 
            // cesLabelControl6
            // 
            this.cesLabelControl6.LabelFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.cesLabelControl6.LabelText = "Parameter";
            this.cesLabelControl6.Location = new System.Drawing.Point(3, 44);
            this.cesLabelControl6.Name = "cesLabelControl6";
            this.cesLabelControl6.Size = new System.Drawing.Size(110, 20);
            this.cesLabelControl6.TabIndex = 227;
            // 
            // cesLabelControl3
            // 
            this.cesLabelControl3.LabelFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.cesLabelControl3.LabelText = "Dll Path";
            this.cesLabelControl3.Location = new System.Drawing.Point(3, 22);
            this.cesLabelControl3.Name = "cesLabelControl3";
            this.cesLabelControl3.Size = new System.Drawing.Size(110, 20);
            this.cesLabelControl3.TabIndex = 220;
            // 
            // cesLabelControl7
            // 
            this.cesLabelControl7.LabelFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.cesLabelControl7.LabelText = "TabPage Name";
            this.cesLabelControl7.Location = new System.Drawing.Point(3, 0);
            this.cesLabelControl7.Name = "cesLabelControl7";
            this.cesLabelControl7.Size = new System.Drawing.Size(110, 20);
            this.cesLabelControl7.TabIndex = 215;
            // 
            // ConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtParams);
            this.Controls.Add(this.cesLabelControl6);
            this.Controls.Add(this.txtClassName);
            this.Controls.Add(this.txtDllPath);
            this.Controls.Add(this.cesLabelControl3);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.txtTabName);
            this.Controls.Add(this.cesLabelControl7);
            this.Controls.Add(this.simpleButton1);
            this.Name = "ConfigControl";
            this.Size = new System.Drawing.Size(624, 66);
            ((System.ComponentModel.ISupportInitialize)(this.txtTabName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClassName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDllPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtParams.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private CesLabelControl cesLabelControl7;
        private DevExpress.XtraEditors.TextEdit txtTabName;
        private DevExpress.XtraEditors.SimpleButton btnDel;
        private DevExpress.XtraEditors.SimpleButton btnLoad;
        private CesLabelControl cesLabelControl6;
        private DevExpress.XtraEditors.TextEdit txtClassName;
        private DevExpress.XtraEditors.TextEdit txtDllPath;
        private CesLabelControl cesLabelControl3;
        private DevExpress.XtraEditors.TextEdit txtParams;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}
