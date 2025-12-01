namespace BarnCaseApi
{
    partial class Production
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Production));
            this.pictureBoxBack = new System.Windows.Forms.PictureBox();
            this.btnSheep = new System.Windows.Forms.Button();
            this.lblMoney = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressCow = new System.Windows.Forms.ProgressBar();
            this.progressChicken = new System.Windows.Forms.ProgressBar();
            this.progressSheep = new System.Windows.Forms.ProgressBar();
            this.btnChicken = new System.Windows.Forms.Button();
            this.btnCow = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBack)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxBack
            // 
            this.pictureBoxBack.Image = global::BarnCaseApi.Properties.Resources.arrow_left;
            this.pictureBoxBack.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxBack.Name = "pictureBoxBack";
            this.pictureBoxBack.Size = new System.Drawing.Size(67, 33);
            this.pictureBoxBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxBack.TabIndex = 7;
            this.pictureBoxBack.TabStop = false;
            this.pictureBoxBack.Click += new System.EventHandler(this.PicToLogin_Click);
            // 
            // btnSheep
            // 
            this.btnSheep.Location = new System.Drawing.Point(272, 268);
            this.btnSheep.Name = "btnSheep";
            this.btnSheep.Size = new System.Drawing.Size(145, 38);
            this.btnSheep.TabIndex = 9;
            this.btnSheep.Text = "Wool";
            this.btnSheep.UseVisualStyleBackColor = true;
            this.btnSheep.Click += new System.EventHandler(this.btnSheep_Click);
            // 
            // lblMoney
            // 
            this.lblMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoney.Location = new System.Drawing.Point(91, 12);
            this.lblMoney.Name = "lblMoney";
            this.lblMoney.Size = new System.Drawing.Size(188, 33);
            this.lblMoney.TabIndex = 2;
            this.lblMoney.Text = "lblMoney";
            // 
            // progressCow
            // 
            this.progressCow.Location = new System.Drawing.Point(440, 239);
            this.progressCow.Name = "progressCow";
            this.progressCow.Size = new System.Drawing.Size(145, 24);
            this.progressCow.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressCow.TabIndex = 11;
            // 
            // progressChicken
            // 
            this.progressChicken.Location = new System.Drawing.Point(87, 239);
            this.progressChicken.Name = "progressChicken";
            this.progressChicken.Size = new System.Drawing.Size(145, 24);
            this.progressChicken.TabIndex = 12;
            // 
            // progressSheep
            // 
            this.progressSheep.Location = new System.Drawing.Point(272, 239);
            this.progressSheep.Name = "progressSheep";
            this.progressSheep.Size = new System.Drawing.Size(145, 24);
            this.progressSheep.TabIndex = 13;
            // 
            // btnChicken
            // 
            this.btnChicken.Location = new System.Drawing.Point(87, 268);
            this.btnChicken.Name = "btnChicken";
            this.btnChicken.Size = new System.Drawing.Size(145, 38);
            this.btnChicken.TabIndex = 14;
            this.btnChicken.Text = "Eggs";
            this.btnChicken.UseVisualStyleBackColor = true;
            this.btnChicken.Click += new System.EventHandler(this.btnChicken_Click);
            // 
            // btnCow
            // 
            this.btnCow.Location = new System.Drawing.Point(440, 268);
            this.btnCow.Name = "btnCow";
            this.btnCow.Size = new System.Drawing.Size(145, 38);
            this.btnCow.TabIndex = 15;
            this.btnCow.Text = "Milk";
            this.btnCow.UseVisualStyleBackColor = true;
            this.btnCow.Click += new System.EventHandler(this.btnCow_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(492, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Cow";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(315, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Sheep";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Chicken";
            // 
            // Production
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 344);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCow);
            this.Controls.Add(this.btnChicken);
            this.Controls.Add(this.progressSheep);
            this.Controls.Add(this.progressChicken);
            this.Controls.Add(this.progressCow);
            this.Controls.Add(this.lblMoney);
            this.Controls.Add(this.btnSheep);
            this.Controls.Add(this.pictureBoxBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Production";
            this.Text = "Production";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       
        #endregion
        private System.Windows.Forms.PictureBox pictureBoxBack;
        private System.Windows.Forms.Button btnSheep;
        private System.Windows.Forms.Label lblMoney;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar progressCow;
        private System.Windows.Forms.ProgressBar progressChicken;
        private System.Windows.Forms.ProgressBar progressSheep;
        private System.Windows.Forms.Button btnChicken;
        private System.Windows.Forms.Button btnCow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}