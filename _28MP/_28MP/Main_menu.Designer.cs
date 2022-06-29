namespace _28MP
{
    partial class mainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainMenu));
            this.creatbtn = new System.Windows.Forms.Button();
            this.signoutbtn = new System.Windows.Forms.Button();
            this.addbtn = new System.Windows.Forms.Button();
            this.viewbtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ordersbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // creatbtn
            // 
            this.creatbtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.creatbtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.creatbtn.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creatbtn.Location = new System.Drawing.Point(126, 130);
            this.creatbtn.Name = "creatbtn";
            this.creatbtn.Size = new System.Drawing.Size(226, 59);
            this.creatbtn.TabIndex = 0;
            this.creatbtn.Text = "إنشاء";
            this.creatbtn.UseVisualStyleBackColor = false;
            this.creatbtn.Click += new System.EventHandler(this.creatbtn_Click);
            // 
            // signoutbtn
            // 
            this.signoutbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.signoutbtn.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signoutbtn.Location = new System.Drawing.Point(12, 563);
            this.signoutbtn.Name = "signoutbtn";
            this.signoutbtn.Size = new System.Drawing.Size(175, 48);
            this.signoutbtn.TabIndex = 3;
            this.signoutbtn.Text = "تسجيل خروج";
            this.signoutbtn.UseVisualStyleBackColor = true;
            this.signoutbtn.Click += new System.EventHandler(this.signoutbtn_Click);
            // 
            // addbtn
            // 
            this.addbtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.addbtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.addbtn.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addbtn.Location = new System.Drawing.Point(126, 224);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(226, 54);
            this.addbtn.TabIndex = 1;
            this.addbtn.Text = "إضافة";
            this.addbtn.UseVisualStyleBackColor = false;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // viewbtn
            // 
            this.viewbtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.viewbtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.viewbtn.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewbtn.Location = new System.Drawing.Point(126, 418);
            this.viewbtn.Name = "viewbtn";
            this.viewbtn.Size = new System.Drawing.Size(226, 61);
            this.viewbtn.TabIndex = 2;
            this.viewbtn.Text = "عرض";
            this.viewbtn.UseVisualStyleBackColor = false;
            this.viewbtn.Click += new System.EventHandler(this.viewbtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(122, 114);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // ordersbtn
            // 
            this.ordersbtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ordersbtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ordersbtn.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ordersbtn.Location = new System.Drawing.Point(126, 318);
            this.ordersbtn.Name = "ordersbtn";
            this.ordersbtn.Size = new System.Drawing.Size(226, 61);
            this.ordersbtn.TabIndex = 5;
            this.ordersbtn.Text = "قرارات النيابة";
            this.ordersbtn.UseVisualStyleBackColor = false;
            this.ordersbtn.Click += new System.EventHandler(this.ordersbtn_Click);
            // 
            // mainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Firebrick;
            this.ClientSize = new System.Drawing.Size(442, 623);
            this.ControlBox = false;
            this.Controls.Add(this.ordersbtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.signoutbtn);
            this.Controls.Add(this.viewbtn);
            this.Controls.Add(this.addbtn);
            this.Controls.Add(this.creatbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "mainMenu";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الرئيسية";
            this.Load += new System.EventHandler(this.mainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button creatbtn;
        private System.Windows.Forms.Button signoutbtn;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.Button viewbtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ordersbtn;
    }
}

