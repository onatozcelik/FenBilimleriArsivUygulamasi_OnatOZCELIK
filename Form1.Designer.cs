namespace BarkodeProjectV2
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelSide = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.yeniKayitbtn = new System.Windows.Forms.Button();
            this.yazdırmaArayuzbtn = new System.Windows.Forms.Button();
            this.paneHeader = new System.Windows.Forms.Panel();
            this.btnclose = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.minimizebtn = new System.Windows.Forms.Button();
            this.panelSide.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.paneHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSide
            // 
            this.panelSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(71)))));
            this.panelSide.Controls.Add(this.pictureBox1);
            this.panelSide.Controls.Add(this.yeniKayitbtn);
            this.panelSide.Controls.Add(this.yazdırmaArayuzbtn);
            this.panelSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSide.ForeColor = System.Drawing.Color.White;
            this.panelSide.Location = new System.Drawing.Point(0, 57);
            this.panelSide.Name = "panelSide";
            this.panelSide.Size = new System.Drawing.Size(200, 711);
            this.panelSide.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 192);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // yeniKayitbtn
            // 
            this.yeniKayitbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(71)))));
            this.yeniKayitbtn.FlatAppearance.BorderSize = 0;
            this.yeniKayitbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yeniKayitbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.yeniKayitbtn.ForeColor = System.Drawing.Color.White;
            this.yeniKayitbtn.Image = ((System.Drawing.Image)(resources.GetObject("yeniKayitbtn.Image")));
            this.yeniKayitbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.yeniKayitbtn.Location = new System.Drawing.Point(0, 306);
            this.yeniKayitbtn.Name = "yeniKayitbtn";
            this.yeniKayitbtn.Size = new System.Drawing.Size(200, 80);
            this.yeniKayitbtn.TabIndex = 1;
            this.yeniKayitbtn.Text = "KAYIT ARAYÜZÜ";
            this.yeniKayitbtn.UseVisualStyleBackColor = false;
            this.yeniKayitbtn.Click += new System.EventHandler(this.yeniKayitbtn_Click);
            // 
            // yazdırmaArayuzbtn
            // 
            this.yazdırmaArayuzbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(71)))));
            this.yazdırmaArayuzbtn.FlatAppearance.BorderSize = 0;
            this.yazdırmaArayuzbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yazdırmaArayuzbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.yazdırmaArayuzbtn.ForeColor = System.Drawing.Color.White;
            this.yazdırmaArayuzbtn.Image = ((System.Drawing.Image)(resources.GetObject("yazdırmaArayuzbtn.Image")));
            this.yazdırmaArayuzbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.yazdırmaArayuzbtn.Location = new System.Drawing.Point(0, 204);
            this.yazdırmaArayuzbtn.Name = "yazdırmaArayuzbtn";
            this.yazdırmaArayuzbtn.Size = new System.Drawing.Size(200, 80);
            this.yazdırmaArayuzbtn.TabIndex = 0;
            this.yazdırmaArayuzbtn.Text = "YAZDIRMA ARAYÜZÜ";
            this.yazdırmaArayuzbtn.UseVisualStyleBackColor = false;
            this.yazdırmaArayuzbtn.Click += new System.EventHandler(this.yazdırmaArayuzbtn_Click);
            // 
            // paneHeader
            // 
            this.paneHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(71)))));
            this.paneHeader.Controls.Add(this.panel1);
            this.paneHeader.Controls.Add(this.btnclose);
            this.paneHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.paneHeader.Location = new System.Drawing.Point(0, 0);
            this.paneHeader.Name = "paneHeader";
            this.paneHeader.Size = new System.Drawing.Size(1380, 57);
            this.paneHeader.TabIndex = 1;
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(71)))));
            this.btnclose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnclose.FlatAppearance.BorderSize = 0;
            this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclose.Font = new System.Drawing.Font("Gotham", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnclose.ForeColor = System.Drawing.Color.White;
            this.btnclose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnclose.Location = new System.Drawing.Point(1321, 0);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(59, 57);
            this.btnclose.TabIndex = 3;
            this.btnclose.Text = "X";
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(200, 57);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1180, 711);
            this.mainPanel.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.minimizebtn);
            this.panel1.Location = new System.Drawing.Point(1256, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(59, 57);
            this.panel1.TabIndex = 0;
            // 
            // minimizebtn
            // 
            this.minimizebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(71)))));
            this.minimizebtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minimizebtn.FlatAppearance.BorderSize = 0;
            this.minimizebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizebtn.Font = new System.Drawing.Font("Gotham", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.minimizebtn.ForeColor = System.Drawing.Color.White;
            this.minimizebtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.minimizebtn.Location = new System.Drawing.Point(0, 0);
            this.minimizebtn.Name = "minimizebtn";
            this.minimizebtn.Size = new System.Drawing.Size(59, 57);
            this.minimizebtn.TabIndex = 4;
            this.minimizebtn.Text = "-";
            this.minimizebtn.UseVisualStyleBackColor = false;
            this.minimizebtn.Click += new System.EventHandler(this.minimizebtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1380, 768);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.panelSide);
            this.Controls.Add(this.paneHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panelSide.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.paneHeader.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSide;
        private System.Windows.Forms.Panel paneHeader;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button yeniKayitbtn;
        private System.Windows.Forms.Button yazdırmaArayuzbtn;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button minimizebtn;
    }
}

