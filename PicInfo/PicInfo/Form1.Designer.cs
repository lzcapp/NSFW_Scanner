namespace PicInfo
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pic = new System.Windows.Forms.PictureBox();
            this.llbOk = new System.Windows.Forms.LinkLabel();
            this.llbPr = new System.Windows.Forms.LinkLabel();
            this.llbType = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // pic
            // 
            this.pic.ImageLocation = "D:\\Downloads\\test.jpg";
            this.pic.Location = new System.Drawing.Point(12, 12);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(241, 317);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic.TabIndex = 3;
            this.pic.TabStop = false;
            this.pic.DragDrop += new System.Windows.Forms.DragEventHandler(this.Pic_DragDrop);
            this.pic.DragEnter += new System.Windows.Forms.DragEventHandler(this.Pic_DragEnter);
            // 
            // llbOk
            // 
            this.llbOk.Font = new System.Drawing.Font("造字工房尚雅体演示版常规体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.llbOk.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
            this.llbOk.Location = new System.Drawing.Point(259, 32);
            this.llbOk.Name = "llbOk";
            this.llbOk.Size = new System.Drawing.Size(218, 27);
            this.llbOk.TabIndex = 4;
            this.llbOk.Text = "合规";
            // 
            // llbPr
            // 
            this.llbPr.AutoSize = true;
            this.llbPr.Font = new System.Drawing.Font("造字工房尚雅体演示版常规体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.llbPr.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
            this.llbPr.Location = new System.Drawing.Point(262, 12);
            this.llbPr.Name = "llbPr";
            this.llbPr.Size = new System.Drawing.Size(163, 66);
            this.llbPr.TabIndex = 5;
            this.llbPr.Text = "99.9999%  确定\r\n正常";
            this.llbPr.Visible = false;
            // 
            // llbType
            // 
            this.llbType.Font = new System.Drawing.Font("造字工房尚雅体演示版常规体", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.llbType.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
            this.llbType.Location = new System.Drawing.Point(264, 78);
            this.llbType.Name = "llbType";
            this.llbType.Size = new System.Drawing.Size(218, 251);
            this.llbType.TabIndex = 6;
            this.llbType.Text = "linkLabel1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 343);
            this.Controls.Add(this.llbType);
            this.Controls.Add(this.llbOk);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.llbPr);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "PicInfo";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.LinkLabel llbOk;
        private System.Windows.Forms.LinkLabel llbPr;
        private System.Windows.Forms.LinkLabel llbType;
    }
}

