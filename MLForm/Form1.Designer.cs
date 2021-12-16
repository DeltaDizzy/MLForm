namespace MLForm
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnUpload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pbFresh = new System.Windows.Forms.PictureBox();
            this.btnDetect = new System.Windows.Forms.Button();
            this.pbMLd = new System.Windows.Forms.PictureBox();
            this.btnCategories = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbFresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMLd)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // btnUpload
            // 
            this.btnUpload.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpload.Location = new System.Drawing.Point(272, 67);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(97, 42);
            this.btnUpload.TabIndex = 0;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.BtnUpload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(191, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Object Detection with ML.NET";
            // 
            // pbFresh
            // 
            this.pbFresh.Location = new System.Drawing.Point(25, 67);
            this.pbFresh.Name = "pbFresh";
            this.pbFresh.Size = new System.Drawing.Size(241, 239);
            this.pbFresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFresh.TabIndex = 2;
            this.pbFresh.TabStop = false;
            // 
            // btnDetect
            // 
            this.btnDetect.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDetect.Location = new System.Drawing.Point(272, 115);
            this.btnDetect.Name = "btnDetect";
            this.btnDetect.Size = new System.Drawing.Size(97, 42);
            this.btnDetect.TabIndex = 3;
            this.btnDetect.Text = "Detect Objects";
            this.btnDetect.UseVisualStyleBackColor = true;
            this.btnDetect.Click += new System.EventHandler(this.BtnDetect_Click);
            // 
            // pbMLd
            // 
            this.pbMLd.Location = new System.Drawing.Point(375, 67);
            this.pbMLd.Name = "pbMLd";
            this.pbMLd.Size = new System.Drawing.Size(241, 239);
            this.pbMLd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMLd.TabIndex = 4;
            this.pbMLd.TabStop = false;
            // 
            // btnCategories
            // 
            this.btnCategories.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCategories.Location = new System.Drawing.Point(272, 163);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.Size = new System.Drawing.Size(97, 42);
            this.btnCategories.TabIndex = 5;
            this.btnCategories.Text = "Show Category Names";
            this.btnCategories.UseVisualStyleBackColor = true;
            this.btnCategories.Click += new System.EventHandler(this.btnCategories_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 323);
            this.Controls.Add(this.btnCategories);
            this.Controls.Add(this.pbMLd);
            this.Controls.Add(this.btnDetect);
            this.Controls.Add(this.pbFresh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpload);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbFresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMLd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenFileDialog openFileDialog;
        private Button btnUpload;
        private Label label1;
        private PictureBox pbFresh;
        private Button btnDetect;
        private PictureBox pbMLd;
        private Button btnCategories;
    }
}