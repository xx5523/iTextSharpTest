namespace iTextSharpTest
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCreatePDF = new System.Windows.Forms.Button();
            this.openHtmlDialog = new System.Windows.Forms.OpenFileDialog();
            this.webBrowserForPDF = new System.Windows.Forms.WebBrowser();
            this.btnConfig = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnChooseHtml = new System.Windows.Forms.Button();
            this.tBhtmlPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCreatePDF
            // 
            this.btnCreatePDF.Location = new System.Drawing.Point(12, 15);
            this.btnCreatePDF.Name = "btnCreatePDF";
            this.btnCreatePDF.Size = new System.Drawing.Size(116, 30);
            this.btnCreatePDF.TabIndex = 0;
            this.btnCreatePDF.Text = "转换";
            this.btnCreatePDF.UseVisualStyleBackColor = true;
            this.btnCreatePDF.Click += new System.EventHandler(this.btnCreatePDF_Click);
            // 
            // openHtmlDialog
            // 
            this.openHtmlDialog.FileName = "openFileDialog1";
            // 
            // webBrowserForPDF
            // 
            this.webBrowserForPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowserForPDF.Location = new System.Drawing.Point(6, 64);
            this.webBrowserForPDF.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserForPDF.Name = "webBrowserForPDF";
            this.webBrowserForPDF.Size = new System.Drawing.Size(882, 400);
            this.webBrowserForPDF.TabIndex = 1;
            // 
            // btnConfig
            // 
            this.btnConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfig.Location = new System.Drawing.Point(759, 15);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(122, 30);
            this.btnConfig.TabIndex = 2;
            this.btnConfig.Text = "button1";
            this.btnConfig.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(135, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnChooseHtml
            // 
            this.btnChooseHtml.Location = new System.Drawing.Point(256, 15);
            this.btnChooseHtml.Name = "btnChooseHtml";
            this.btnChooseHtml.Size = new System.Drawing.Size(115, 30);
            this.btnChooseHtml.TabIndex = 4;
            this.btnChooseHtml.Text = "button2";
            this.btnChooseHtml.UseVisualStyleBackColor = true;
            this.btnChooseHtml.Click += new System.EventHandler(this.btnChooseHtml_Click);
            // 
            // tBhtmlPath
            // 
            this.tBhtmlPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tBhtmlPath.Location = new System.Drawing.Point(378, 21);
            this.tBhtmlPath.Name = "tBhtmlPath";
            this.tBhtmlPath.Size = new System.Drawing.Size(375, 21);
            this.tBhtmlPath.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 469);
            this.Controls.Add(this.tBhtmlPath);
            this.Controls.Add(this.btnChooseHtml);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.webBrowserForPDF);
            this.Controls.Add(this.btnCreatePDF);
            this.MinimumSize = new System.Drawing.Size(909, 507);
            this.Name = "MainForm";
            this.Text = "核心技技技术术术术啊啊啊啊啊啊";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreatePDF;
        private System.Windows.Forms.OpenFileDialog openHtmlDialog;
        private System.Windows.Forms.WebBrowser webBrowserForPDF;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnChooseHtml;
        private System.Windows.Forms.TextBox tBhtmlPath;
    }
}

