using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace YXH.ScanForm
{
    partial class FormAdjustScanImg
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grdShow = new DevExpress.XtraGrid.GridControl();
            this.grvShow = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grcImageID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcImage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rieImage = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.grcSwap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLinkSwap = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.grcRotate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rLinkRotate = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rieImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLinkSwap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLinkRotate)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.grdShow);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(235, 161);
            this.panel1.TabIndex = 5;
            // 
            // grdShow
            // 
            this.grdShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdShow.Location = new System.Drawing.Point(0, 0);
            this.grdShow.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.grdShow.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdShow.MainView = this.grvShow;
            this.grdShow.Name = "grdShow";
            this.grdShow.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rieImage,
            this.rLinkSwap,
            this.rLinkRotate});
            this.grdShow.Size = new System.Drawing.Size(235, 161);
            this.grdShow.TabIndex = 4;
            this.grdShow.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvShow});
            // 
            // grvShow
            // 
            this.grvShow.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcImageID,
            this.grcImage,
            this.grcSwap,
            this.grcRotate});
            this.grvShow.GridControl = this.grdShow;
            this.grvShow.Name = "grvShow";
            this.grvShow.OptionsView.ShowGroupPanel = false;
            // 
            // grcImageID
            // 
            this.grcImageID.Caption = "页码";
            this.grcImageID.FieldName = "ID";
            this.grcImageID.Name = "grcImageID";
            this.grcImageID.Visible = true;
            this.grcImageID.VisibleIndex = 0;
            this.grcImageID.Width = 55;
            // 
            // grcImage
            // 
            this.grcImage.Caption = "图片";
            this.grcImage.ColumnEdit = this.rieImage;
            this.grcImage.FieldName = "ImageByte";
            this.grcImage.Name = "grcImage";
            this.grcImage.Visible = true;
            this.grcImage.VisibleIndex = 1;
            this.grcImage.Width = 50;
            // 
            // rieImage
            // 
            this.rieImage.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.DropDown, "预览", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, false)});
            this.rieImage.Name = "rieImage";
            this.rieImage.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            // 
            // grcSwap
            // 
            this.grcSwap.ColumnEdit = this.rLinkSwap;
            this.grcSwap.Name = "grcSwap";
            this.grcSwap.Visible = true;
            this.grcSwap.VisibleIndex = 2;
            this.grcSwap.Width = 49;
            // 
            // rLinkSwap
            // 
            this.rLinkSwap.AutoHeight = false;
            this.rLinkSwap.Name = "rLinkSwap";
            this.rLinkSwap.NullText = "对调";
            this.rLinkSwap.Click += new System.EventHandler(this.rLinkSwap_Click);
            // 
            // grcRotate
            // 
            this.grcRotate.ColumnEdit = this.rLinkRotate;
            this.grcRotate.Name = "grcRotate";
            this.grcRotate.Visible = true;
            this.grcRotate.VisibleIndex = 3;
            this.grcRotate.Width = 63;
            // 
            // rLinkRotate
            // 
            this.rLinkRotate.AutoHeight = false;
            this.rLinkRotate.Name = "rLinkRotate";
            this.rLinkRotate.NullText = "旋转";
            this.rLinkRotate.Click += new System.EventHandler(this.rLinkRotate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(137, 167);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormAdjustScanImg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 194);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAdjustScanImg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "调整扫描图片";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAdjustScanImg_FormClosing);
            this.Load += new System.EventHandler(this.FormAdjustScanImg_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rieImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLinkSwap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rLinkRotate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl grdShow;
        private DevExpress.XtraGrid.Views.Grid.GridView grvShow;
        private DevExpress.XtraGrid.Columns.GridColumn grcImageID;
        private DevExpress.XtraGrid.Columns.GridColumn grcImage;
        private DevExpress.XtraGrid.Columns.GridColumn grcSwap;
        private DevExpress.XtraGrid.Columns.GridColumn grcRotate;
        private System.Windows.Forms.Button btnClose;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit rieImage;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rLinkSwap;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit rLinkRotate;
    }
}