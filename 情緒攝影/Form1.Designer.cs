
namespace 情緒攝影
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboBoxAttachedCameras = new System.Windows.Forms.ComboBox();
            this.pictureBoxVideo = new System.Windows.Forms.PictureBox();
            this.BtnRecord = new System.Windows.Forms.Button();
            this.comboBoxSupportedModes = new System.Windows.Forms.ComboBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.Btnsetcamera = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnSavedir = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bw1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVideo)).BeginInit();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxAttachedCameras
            // 
            this.comboBoxAttachedCameras.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.comboBoxAttachedCameras.FormattingEnabled = true;
            this.comboBoxAttachedCameras.Location = new System.Drawing.Point(8, 29);
            this.comboBoxAttachedCameras.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxAttachedCameras.Name = "comboBoxAttachedCameras";
            this.comboBoxAttachedCameras.Size = new System.Drawing.Size(255, 20);
            this.comboBoxAttachedCameras.TabIndex = 0;
            this.comboBoxAttachedCameras.SelectedIndexChanged += new System.EventHandler(this.comboBoxAttachedCameras_SelectedIndexChanged);
            // 
            // pictureBoxVideo
            // 
            this.pictureBoxVideo.Location = new System.Drawing.Point(301, 20);
            this.pictureBoxVideo.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxVideo.Name = "pictureBoxVideo";
            this.pictureBoxVideo.Size = new System.Drawing.Size(350, 400);
            this.pictureBoxVideo.TabIndex = 1;
            this.pictureBoxVideo.TabStop = false;
            // 
            // BtnRecord
            // 
            this.BtnRecord.Location = new System.Drawing.Point(28, 362);
            this.BtnRecord.Margin = new System.Windows.Forms.Padding(2);
            this.BtnRecord.Name = "BtnRecord";
            this.BtnRecord.Size = new System.Drawing.Size(61, 23);
            this.BtnRecord.TabIndex = 2;
            this.BtnRecord.Text = "開始攝影";
            this.BtnRecord.UseVisualStyleBackColor = true;
            this.BtnRecord.Click += new System.EventHandler(this.BtnRecord_Click);
            // 
            // comboBoxSupportedModes
            // 
            this.comboBoxSupportedModes.FormattingEnabled = true;
            this.comboBoxSupportedModes.Location = new System.Drawing.Point(8, 87);
            this.comboBoxSupportedModes.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxSupportedModes.Name = "comboBoxSupportedModes";
            this.comboBoxSupportedModes.Size = new System.Drawing.Size(255, 20);
            this.comboBoxSupportedModes.TabIndex = 3;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.Btnsetcamera);
            this.groupBox.Controls.Add(this.label4);
            this.groupBox.Controls.Add(this.BtnStart);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.comboBoxSupportedModes);
            this.groupBox.Controls.Add(this.comboBoxAttachedCameras);
            this.groupBox.Location = new System.Drawing.Point(18, 134);
            this.groupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox.Size = new System.Drawing.Size(267, 196);
            this.groupBox.TabIndex = 4;
            this.groupBox.TabStop = false;
            // 
            // Btnsetcamera
            // 
            this.Btnsetcamera.Enabled = false;
            this.Btnsetcamera.Location = new System.Drawing.Point(10, 162);
            this.Btnsetcamera.Name = "Btnsetcamera";
            this.Btnsetcamera.Size = new System.Drawing.Size(61, 23);
            this.Btnsetcamera.TabIndex = 12;
            this.Btnsetcamera.Text = "設定相機";
            this.Btnsetcamera.UseVisualStyleBackColor = true;
            this.Btnsetcamera.Click += new System.EventHandler(this.Btnsetcamera_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "若要更改相機與解析度 請重開!";
            this.label4.Visible = false;
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(10, 122);
            this.BtnStart.Margin = new System.Windows.Forms.Padding(2);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(61, 23);
            this.BtnStart.TabIndex = 10;
            this.BtnStart.Text = "開啟相機";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "選擇相機";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "選擇解析度";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "儲存的檔案";
            // 
            // BtnSavedir
            // 
            this.BtnSavedir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnSavedir.Location = new System.Drawing.Point(99, 13);
            this.BtnSavedir.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSavedir.Name = "BtnSavedir";
            this.BtnSavedir.Size = new System.Drawing.Size(63, 20);
            this.BtnSavedir.TabIndex = 6;
            this.BtnSavedir.Text = "選擇";
            this.BtnSavedir.UseVisualStyleBackColor = true;
            this.BtnSavedir.Click += new System.EventHandler(this.BtnSavedir_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(18, 35);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(269, 22);
            this.textBox1.TabIndex = 7;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(93, 362);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "00:00:000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 408);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "錄製中";
            this.label6.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BtnSavedir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnRecord);
            this.Controls.Add(this.pictureBoxVideo);
            this.Controls.Add(this.groupBox);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "情緒攝影(0.0.1)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVideo)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxAttachedCameras;
        private System.Windows.Forms.PictureBox pictureBoxVideo;
        private System.Windows.Forms.Button BtnRecord;
        private System.Windows.Forms.ComboBox comboBoxSupportedModes;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnSavedir;
        private System.Windows.Forms.TextBox textBox1;
        private System.ComponentModel.BackgroundWorker bw1;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Btnsetcamera;
    }
}

