namespace AyarabuxMaster
{
    partial class MainForms
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForms));
            this.btn_Capture = new System.Windows.Forms.Button();
            this.btn_Click = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timerAuto = new System.Windows.Forms.Timer(this.components);
            this.btn_TopMost = new System.Windows.Forms.Button();
            this.btn_Dev = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Capture
            // 
            this.btn_Capture.Location = new System.Drawing.Point(1139, 41);
            this.btn_Capture.Name = "btn_Capture";
            this.btn_Capture.Size = new System.Drawing.Size(75, 23);
            this.btn_Capture.TabIndex = 1;
            this.btn_Capture.Text = "截圖";
            this.btn_Capture.UseVisualStyleBackColor = true;
            this.btn_Capture.Click += new System.EventHandler(this.btn_Capture_Click);
            // 
            // btn_Click
            // 
            this.btn_Click.Location = new System.Drawing.Point(1139, 70);
            this.btn_Click.Name = "btn_Click";
            this.btn_Click.Size = new System.Drawing.Size(75, 23);
            this.btn_Click.TabIndex = 2;
            this.btn_Click.Text = "點";
            this.btn_Click.UseVisualStyleBackColor = true;
            this.btn_Click.Visible = false;
            this.btn_Click.Click += new System.EventHandler(this.btn_Click_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1136, 640);
            this.panel1.TabIndex = 3;
            // 
            // timerAuto
            // 
            this.timerAuto.Interval = 500;
            this.timerAuto.Tick += new System.EventHandler(this.timerAuto_Tick);
            // 
            // btn_TopMost
            // 
            this.btn_TopMost.Location = new System.Drawing.Point(1139, 12);
            this.btn_TopMost.Name = "btn_TopMost";
            this.btn_TopMost.Size = new System.Drawing.Size(75, 23);
            this.btn_TopMost.TabIndex = 6;
            this.btn_TopMost.Text = "置頂";
            this.btn_TopMost.UseVisualStyleBackColor = true;
            this.btn_TopMost.Click += new System.EventHandler(this.btn_TopMost_Click);
            // 
            // btn_Dev
            // 
            this.btn_Dev.Location = new System.Drawing.Point(1139, 605);
            this.btn_Dev.Name = "btn_Dev";
            this.btn_Dev.Size = new System.Drawing.Size(75, 23);
            this.btn_Dev.TabIndex = 7;
            this.btn_Dev.Text = "開啟Dev";
            this.btn_Dev.UseVisualStyleBackColor = true;
            this.btn_Dev.Click += new System.EventHandler(this.btn_Dev_Click);
            // 
            // MainForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1217, 640);
            this.Controls.Add(this.btn_Dev);
            this.Controls.Add(this.btn_TopMost);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_Click);
            this.Controls.Add(this.btn_Capture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "妖聲助理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForms_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Capture;
        private System.Windows.Forms.Button btn_Click;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timerAuto;
        private System.Windows.Forms.Button btn_TopMost;
        private System.Windows.Forms.Button btn_Dev;
    }
}

