namespace iTextSharpTest
{
    partial class ConfigForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabCreateProperties = new System.Windows.Forms.TabControl();
            this.templateChoosePage = new System.Windows.Forms.TabPage();
            this.tabCreatePropertiesPage = new System.Windows.Forms.TabPage();
            this.labelPropertiesName = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelEdition = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.tabCreateProperties.SuspendLayout();
            this.tabCreatePropertiesPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCreateProperties
            // 
            this.tabCreateProperties.Controls.Add(this.templateChoosePage);
            this.tabCreateProperties.Controls.Add(this.tabCreatePropertiesPage);
            this.tabCreateProperties.Location = new System.Drawing.Point(0, 1);
            this.tabCreateProperties.Name = "tabCreateProperties";
            this.tabCreateProperties.SelectedIndex = 0;
            this.tabCreateProperties.Size = new System.Drawing.Size(578, 415);
            this.tabCreateProperties.TabIndex = 0;
            // 
            // templateChoosePage
            // 
            this.templateChoosePage.Location = new System.Drawing.Point(4, 22);
            this.templateChoosePage.Name = "templateChoosePage";
            this.templateChoosePage.Padding = new System.Windows.Forms.Padding(3);
            this.templateChoosePage.Size = new System.Drawing.Size(570, 389);
            this.templateChoosePage.TabIndex = 0;
            this.templateChoosePage.Text = "tabPage1";
            this.templateChoosePage.UseVisualStyleBackColor = true;
            // 
            // tabCreatePropertiesPage
            // 
            this.tabCreatePropertiesPage.Controls.Add(this.textBox3);
            this.tabCreatePropertiesPage.Controls.Add(this.label1);
            this.tabCreatePropertiesPage.Controls.Add(this.textBox2);
            this.tabCreatePropertiesPage.Controls.Add(this.labelEdition);
            this.tabCreatePropertiesPage.Controls.Add(this.textBox1);
            this.tabCreatePropertiesPage.Controls.Add(this.labelPropertiesName);
            this.tabCreatePropertiesPage.Location = new System.Drawing.Point(4, 22);
            this.tabCreatePropertiesPage.Name = "tabCreatePropertiesPage";
            this.tabCreatePropertiesPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabCreatePropertiesPage.Size = new System.Drawing.Size(570, 389);
            this.tabCreatePropertiesPage.TabIndex = 1;
            this.tabCreatePropertiesPage.Text = "新建";
            this.tabCreatePropertiesPage.UseVisualStyleBackColor = true;
            // 
            // labelPropertiesName
            // 
            this.labelPropertiesName.AutoSize = true;
            this.labelPropertiesName.Location = new System.Drawing.Point(3, 26);
            this.labelPropertiesName.Name = "labelPropertiesName";
            this.labelPropertiesName.Size = new System.Drawing.Size(41, 12);
            this.labelPropertiesName.TabIndex = 0;
            this.labelPropertiesName.Text = "名称：";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(43, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(521, 21);
            this.textBox1.TabIndex = 1;
            // 
            // labelEdition
            // 
            this.labelEdition.AutoSize = true;
            this.labelEdition.Location = new System.Drawing.Point(3, 65);
            this.labelEdition.Name = "labelEdition";
            this.labelEdition.Size = new System.Drawing.Size(41, 12);
            this.labelEdition.TabIndex = 2;
            this.labelEdition.Text = "版本：";
            this.labelEdition.Click += new System.EventHandler(this.labelEdition_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(43, 62);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(213, 21);
            this.textBox2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(43, 97);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(213, 21);
            this.textBox3.TabIndex = 5;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 417);
            this.Controls.Add(this.tabCreateProperties);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ConfigForm";
            this.Text = "配置";
            this.tabCreateProperties.ResumeLayout(false);
            this.tabCreatePropertiesPage.ResumeLayout(false);
            this.tabCreatePropertiesPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCreateProperties;
        private System.Windows.Forms.TabPage templateChoosePage;
        private System.Windows.Forms.TabPage tabCreatePropertiesPage;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelPropertiesName;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label labelEdition;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
    }
}