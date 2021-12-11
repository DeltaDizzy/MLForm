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
            this.btnUpload.Location = new System.Drawing.Point(389, 112);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(139, 70);
            this.btnUpload.TabIndex = 0;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.BtnUpload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(273, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(428, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "Object Detection with ML.NET";
            // 
            // pbFresh
            // 
            this.pbFresh.Location = new System.Drawing.Point(36, 112);
            this.pbFresh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbFresh.Name = "pbFresh";
            this.pbFresh.Size = new System.Drawing.Size(344, 398);
            this.pbFresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFresh.TabIndex = 2;
            this.pbFresh.TabStop = false;
            // 
            // btnDetect
            // 
            this.btnDetect.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDetect.Location = new System.Drawing.Point(389, 192);
            this.btnDetect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDetect.Name = "btnDetect";
            this.btnDetect.Size = new System.Drawing.Size(139, 70);
            this.btnDetect.TabIndex = 3;
            this.btnDetect.Text = "Detect Objects";
            this.btnDetect.UseVisualStyleBackColor = true;
            this.btnDetect.Click += new System.EventHandler(this.BtnDetect_Click);
            // 
            // pbMLd
            // 
            this.pbMLd.Location = new System.Drawing.Point(536, 112);
            this.pbMLd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbMLd.Name = "pbMLd";
            this.pbMLd.Size = new System.Drawing.Size(344, 398);
            this.pbMLd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMLd.TabIndex = 4;
            this.pbMLd.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 538);
            this.Controls.Add(this.pbMLd);
            this.Controls.Add(this.btnDetect);
            this.Controls.Add(this.pbFresh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpload);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
    }
}