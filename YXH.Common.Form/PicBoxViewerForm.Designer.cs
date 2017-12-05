using System.Drawing;
using System.Windows.Forms;
namespace YXH.Common.Form
{
    partial class PicBoxViewerForm
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
            this.picFront = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_Tool = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_ZoomOut = new System.Windows.Forms.Button();
            this.btn_ZoomIn = new System.Windows.Forms.Button();
            this.btn_LastPage = new System.Windows.Forms.Button();
            this.lbl_pageIndex = new System.Windows.Forms.Label();
            this.btn_NextPage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picFront)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel_Tool.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picFront
            // 
            this.picFront.BackColor = System.Drawing.Color.White;
            this.picFront.Location = new System.Drawing.Point(0, 0);
            this.picFront.Name = "picFront";
            this.picFront.Size = new System.Drawing.Size(817, 517);
            this.picFront.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFront.TabIndex = 3;
            this.picFront.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.picFront);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 510);
            this.panel1.TabIndex = 4;
            // 
            // panel_Tool
            // 
            this.panel_Tool.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel_Tool.Controls.Add(this.flowLayoutPanel1);
            this.panel_Tool.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Tool.Location = new System.Drawing.Point(0, 0);
            this.panel_Tool.Name = "panel_Tool";
            this.panel_Tool.Size = new System.Drawing.Size(784, 52);
            this.panel_Tool.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btn_ZoomOut);
            this.flowLayoutPanel1.Controls.Add(this.btn_ZoomIn);
            this.flowLayoutPanel1.Controls.Add(this.btn_LastPage);
            this.flowLayoutPanel1.Controls.Add(this.lbl_pageIndex);
            this.flowLayoutPanel1.Controls.Add(this.btn_NextPage);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(218, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(379, 42);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // btn_ZoomOut
            // 
            this.btn_ZoomOut.FlatAppearance.BorderSize = 0;
            this.btn_ZoomOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_ZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ZoomOut.Image = global::YXH.Common.Form.PicBoxViewerFormRes.btn_ZoomOut_Image;
            this.btn_ZoomOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ZoomOut.Location = new System.Drawing.Point(0, 0);
            this.btn_ZoomOut.Margin = new System.Windows.Forms.Padding(0);
            this.btn_ZoomOut.Name = "btn_ZoomOut";
            this.btn_ZoomOut.Size = new System.Drawing.Size(61, 47);
            this.btn_ZoomOut.TabIndex = 5;
            this.btn_ZoomOut.Text = "放大";
            this.btn_ZoomOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ZoomOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_ZoomOut.UseVisualStyleBackColor = true;
            this.btn_ZoomOut.Click += new System.EventHandler(this.btn_ZoomOut_Click);
            // 
            // btn_ZoomIn
            // 
            this.btn_ZoomIn.FlatAppearance.BorderSize = 0;
            this.btn_ZoomIn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_ZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ZoomIn.Image = global::YXH.Common.Form.PicBoxViewerFormRes.btn_ZoomIn_Image;
            this.btn_ZoomIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ZoomIn.Location = new System.Drawing.Point(61, 0);
            this.btn_ZoomIn.Margin = new System.Windows.Forms.Padding(0);
            this.btn_ZoomIn.Name = "btn_ZoomIn";
            this.btn_ZoomIn.Size = new System.Drawing.Size(61, 47);
            this.btn_ZoomIn.TabIndex = 6;
            this.btn_ZoomIn.Text = "缩小";
            this.btn_ZoomIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ZoomIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_ZoomIn.UseVisualStyleBackColor = true;
            this.btn_ZoomIn.Click += new System.EventHandler(this.btn_ZoomIn_Click);
            // 
            // btn_LastPage
            // 
            this.btn_LastPage.FlatAppearance.BorderSize = 0;
            this.btn_LastPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_LastPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_LastPage.Image = global::YXH.Common.Form.PicBoxViewerFormRes.btn_LastPage_Image;
            this.btn_LastPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_LastPage.Location = new System.Drawing.Point(122, 0);
            this.btn_LastPage.Margin = new System.Windows.Forms.Padding(0);
            this.btn_LastPage.Name = "btn_LastPage";
            this.btn_LastPage.Size = new System.Drawing.Size(71, 47);
            this.btn_LastPage.TabIndex = 8;
            this.btn_LastPage.Text = "上一页";
            this.btn_LastPage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_LastPage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_LastPage.UseVisualStyleBackColor = true;
            this.btn_LastPage.Click += new System.EventHandler(this.btn_LastPage_Click);
            // 
            // lbl_pageIndex
            // 
            this.lbl_pageIndex.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_pageIndex.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbl_pageIndex.Location = new System.Drawing.Point(196, 0);
            this.lbl_pageIndex.Name = "lbl_pageIndex";
            this.lbl_pageIndex.Size = new System.Drawing.Size(62, 47);
            this.lbl_pageIndex.TabIndex = 10;
            this.lbl_pageIndex.Text = "0/0";
            this.lbl_pageIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_NextPage
            // 
            this.btn_NextPage.FlatAppearance.BorderSize = 0;
            this.btn_NextPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_NextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_NextPage.Image = global::YXH.Common.Form.PicBoxViewerFormRes.btn_NextPage_Image;
            this.btn_NextPage.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_NextPage.Location = new System.Drawing.Point(261, 0);
            this.btn_NextPage.Margin = new System.Windows.Forms.Padding(0);
            this.btn_NextPage.Name = "btn_NextPage";
            this.btn_NextPage.Size = new System.Drawing.Size(70, 47);
            this.btn_NextPage.TabIndex = 9;
            this.btn_NextPage.Text = "下一页";
            this.btn_NextPage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_NextPage.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_NextPage.UseVisualStyleBackColor = true;
            this.btn_NextPage.Click += new System.EventHandler(this.btn_NextPage_Click);
            // 
            // PicBoxViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_Tool);
            this.Name = "PicBoxViewerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图片查看";
            ((System.ComponentModel.ISupportInitialize)(this.picFront)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel_Tool.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private PictureBox picFront;

        private Panel panel1;

        private Panel panel_Tool;

        private Button btn_ZoomIn;

        private Button btn_ZoomOut;

        private FlowLayoutPanel flowLayoutPanel1;

        private Button btn_LastPage;

        private Label lbl_pageIndex;

        private Button btn_NextPage;

        #endregion
    }
}