namespace QuickCommand
{
    partial class FormCommand
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCommand));
            this.cbCommand = new System.Windows.Forms.ComboBox();
            this.btnExcute = new MetroFramework.Controls.MetroButton();
            this.notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.lblMessage = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // cbCommand
            // 
            this.cbCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCommand.FormattingEnabled = true;
            this.cbCommand.ItemHeight = 23;
            this.cbCommand.Location = new System.Drawing.Point(3, 27);
            this.cbCommand.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbCommand.MaxDropDownItems = 30;
            this.cbCommand.Name = "cbCommand";
            this.cbCommand.Size = new System.Drawing.Size(338, 29);
            this.cbCommand.TabIndex = 0;
            this.cbCommand.TextUpdate += new System.EventHandler(this.cbCommand_TextUpdate);
            this.cbCommand.TextChanged += new System.EventHandler(this.cbCommand_TextChanged);
            this.cbCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbCommand_KeyDown);
            // 
            // btnExcute
            // 
            this.btnExcute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcute.Enabled = false;
            this.btnExcute.Location = new System.Drawing.Point(344, 26);
            this.btnExcute.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnExcute.Name = "btnExcute";
            this.btnExcute.Size = new System.Drawing.Size(70, 23);
            this.btnExcute.TabIndex = 1;
            this.btnExcute.TabStop = false;
            this.btnExcute.Text = "(&E)xcute";
            this.btnExcute.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnExcute.UseSelectable = true;
            this.btnExcute.UseVisualStyleBackColor = true;
            this.btnExcute.Click += new System.EventHandler(this.btnExcute_Click);
            // 
            // notify
            // 
            this.notify.Text = "快捷命令";
            this.notify.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notify_MouseDoubleClick);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "2014092219534814.png");
            this.imageList.Images.SetKeyName(1, "2014092219534911.png");
            this.imageList.Images.SetKeyName(2, "2014092219534922.png");
            this.imageList.Images.SetKeyName(3, "2014092219534932.png");
            this.imageList.Images.SetKeyName(4, "2014092219534943.png");
            this.imageList.Images.SetKeyName(5, "2014092219534959.png");
            this.imageList.Images.SetKeyName(6, "2014092219534992.png");
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(2, 5);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(252, 19);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "quick command(thirdlucky@126.com)  -r ";
            this.lblMessage.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // FormCommand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(417, 53);
            this.Controls.Add(this.btnExcute);
            this.Controls.Add(this.cbCommand);
            this.Controls.Add(this.lblMessage);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCommand";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "quick command(thirdlucky@126.com)  -r ";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormCommand_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCommand;
        private MetroFramework.Controls.MetroButton btnExcute;
        private System.Windows.Forms.NotifyIcon notify;
        private System.Windows.Forms.ImageList imageList;
        private MetroFramework.Controls.MetroLabel lblMessage;
    }
}

