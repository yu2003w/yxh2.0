using System.Drawing;
using System.Windows.Forms;
namespace YXH.Main
{
    partial class SubjectListForm
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
            this.panel_body = new System.Windows.Forms.Panel();
            this.panListArea = new System.Windows.Forms.Panel();
            this.lblComboBoxImage = new System.Windows.Forms.Label();
            this.panSelectSubject = new System.Windows.Forms.Panel();
            this.panSubjcetRow2 = new System.Windows.Forms.Panel();
            this.panSubjcetRow1 = new System.Windows.Forms.Panel();
            this.lblSelectSubject = new System.Windows.Forms.Label();
            this.panSelectGrade = new System.Windows.Forms.Panel();
            this.panCompulsoryEducation = new System.Windows.Forms.Panel();
            this.panSeniorHighSchool = new System.Windows.Forms.Panel();
            this.lblSelectGrade = new System.Windows.Forms.Label();
            this.cbxExamGroup = new System.Windows.Forms.ComboBox();
            this.panel_body.SuspendLayout();
            this.panListArea.SuspendLayout();
            this.panSelectSubject.SuspendLayout();
            this.panSelectGrade.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_body
            // 
            this.panel_body.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel_body.AutoScroll = true;
            this.panel_body.Controls.Add(this.panListArea);
            this.panel_body.Controls.Add(this.panSelectSubject);
            this.panel_body.Controls.Add(this.panSelectGrade);
            this.panel_body.Controls.Add(this.cbxExamGroup);
            this.panel_body.Location = new System.Drawing.Point(0, 0);
            this.panel_body.MinimumSize = new System.Drawing.Size(1020, 0);
            this.panel_body.Name = "panel_body";
            this.panel_body.Size = new System.Drawing.Size(1020, 509);
            this.panel_body.TabIndex = 3;
            // 
            // panListArea
            // 
            this.panListArea.Controls.Add(this.lblComboBoxImage);
            this.panListArea.Location = new System.Drawing.Point(271, 64);
            this.panListArea.Name = "panListArea";
            this.panListArea.Size = new System.Drawing.Size(452, 82);
            this.panListArea.TabIndex = 4;
            // 
            // lblComboBoxImage
            // 
            this.lblComboBoxImage.AutoSize = true;
            this.lblComboBoxImage.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblComboBoxImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(27)))));
            this.lblComboBoxImage.Image = global::YXH.Main.SubjectListFormRes.DropDownImage;
            this.lblComboBoxImage.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblComboBoxImage.Location = new System.Drawing.Point(78, 28);
            this.lblComboBoxImage.Name = "lblComboBoxImage";
            this.lblComboBoxImage.Size = new System.Drawing.Size(358, 21);
            this.lblComboBoxImage.TabIndex = 1;
            this.lblComboBoxImage.Text = "                             ";
            this.lblComboBoxImage.Click += new System.EventHandler(this.lblComboBoxImage_Click);
            // 
            // panSelectSubject
            // 
            this.panSelectSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panSelectSubject.Controls.Add(this.panSubjcetRow2);
            this.panSelectSubject.Controls.Add(this.panSubjcetRow1);
            this.panSelectSubject.Controls.Add(this.lblSelectSubject);
            this.panSelectSubject.Location = new System.Drawing.Point(0, 258);
            this.panSelectSubject.Margin = new System.Windows.Forms.Padding(0);
            this.panSelectSubject.Name = "panSelectSubject";
            this.panSelectSubject.Size = new System.Drawing.Size(1020, 100);
            this.panSelectSubject.TabIndex = 3;
            this.panSelectSubject.Visible = false;
            // 
            // panSubjcetRow2
            // 
            this.panSubjcetRow2.Location = new System.Drawing.Point(531, 33);
            this.panSubjcetRow2.Name = "panSubjcetRow2";
            this.panSubjcetRow2.Size = new System.Drawing.Size(100, 40);
            this.panSubjcetRow2.TabIndex = 2;
            this.panSubjcetRow2.Visible = false;
            // 
            // panSubjcetRow1
            // 
            this.panSubjcetRow1.Location = new System.Drawing.Point(389, 33);
            this.panSubjcetRow1.Name = "panSubjcetRow1";
            this.panSubjcetRow1.Size = new System.Drawing.Size(100, 40);
            this.panSubjcetRow1.TabIndex = 1;
            this.panSubjcetRow1.Visible = false;
            // 
            // lblSelectSubject
            // 
            this.lblSelectSubject.AutoSize = true;
            this.lblSelectSubject.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSelectSubject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblSelectSubject.Location = new System.Drawing.Point(428, 0);
            this.lblSelectSubject.Margin = new System.Windows.Forms.Padding(0);
            this.lblSelectSubject.Name = "lblSelectSubject";
            this.lblSelectSubject.Size = new System.Drawing.Size(164, 21);
            this.lblSelectSubject.TabIndex = 0;
            this.lblSelectSubject.Text = "请选择扫描科目";
            // 
            // panSelectGrade
            // 
            this.panSelectGrade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panSelectGrade.Controls.Add(this.panCompulsoryEducation);
            this.panSelectGrade.Controls.Add(this.panSeniorHighSchool);
            this.panSelectGrade.Controls.Add(this.lblSelectGrade);
            this.panSelectGrade.Location = new System.Drawing.Point(0, 152);
            this.panSelectGrade.Name = "panSelectGrade";
            this.panSelectGrade.Size = new System.Drawing.Size(1020, 100);
            this.panSelectGrade.TabIndex = 2;
            this.panSelectGrade.Visible = false;
            this.panSelectGrade.VisibleChanged += new System.EventHandler(this.panSelectGrade_VisibleChanged);
            // 
            // panCompulsoryEducation
            // 
            this.panCompulsoryEducation.Location = new System.Drawing.Point(531, 33);
            this.panCompulsoryEducation.Name = "panCompulsoryEducation";
            this.panCompulsoryEducation.Size = new System.Drawing.Size(100, 40);
            this.panCompulsoryEducation.TabIndex = 2;
            this.panCompulsoryEducation.Visible = false;
            // 
            // panSeniorHighSchool
            // 
            this.panSeniorHighSchool.Location = new System.Drawing.Point(389, 33);
            this.panSeniorHighSchool.Margin = new System.Windows.Forms.Padding(0);
            this.panSeniorHighSchool.Name = "panSeniorHighSchool";
            this.panSeniorHighSchool.Size = new System.Drawing.Size(100, 40);
            this.panSeniorHighSchool.TabIndex = 1;
            this.panSeniorHighSchool.Visible = false;
            // 
            // lblSelectGrade
            // 
            this.lblSelectGrade.AutoSize = true;
            this.lblSelectGrade.BackColor = System.Drawing.Color.White;
            this.lblSelectGrade.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSelectGrade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblSelectGrade.Location = new System.Drawing.Point(460, 0);
            this.lblSelectGrade.Name = "lblSelectGrade";
            this.lblSelectGrade.Size = new System.Drawing.Size(120, 21);
            this.lblSelectGrade.TabIndex = 0;
            this.lblSelectGrade.Text = "请选择年级";
            // 
            // cbxExamGroup
            // 
            this.cbxExamGroup.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbxExamGroup.DropDownHeight = 400;
            this.cbxExamGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxExamGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxExamGroup.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxExamGroup.FormattingEnabled = true;
            this.cbxExamGroup.IntegralHeight = false;
            this.cbxExamGroup.ItemHeight = 40;
            this.cbxExamGroup.Location = new System.Drawing.Point(349, 91);
            this.cbxExamGroup.Margin = new System.Windows.Forms.Padding(0);
            this.cbxExamGroup.Name = "cbxExamGroup";
            this.cbxExamGroup.Size = new System.Drawing.Size(350, 46);
            this.cbxExamGroup.TabIndex = 0;
            this.cbxExamGroup.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbxExamGroup_DrawItem);
            this.cbxExamGroup.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.cbxExamGroup_MeasureItem);
            this.cbxExamGroup.SelectedIndexChanged += new System.EventHandler(this.cbxExamGroup_SelectedIndexChanged);
            // 
            // SubjectListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(784, 521);
            this.Controls.Add(this.panel_body);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "SubjectListForm";
            this.Text = "SubjectListForm";
            this.Load += new System.EventHandler(this.SubjectListForm_Load);
            this.SizeChanged += new System.EventHandler(this.SubjectListForm_SizeChanged);
            this.panel_body.ResumeLayout(false);
            this.panListArea.ResumeLayout(false);
            this.panListArea.PerformLayout();
            this.panSelectSubject.ResumeLayout(false);
            this.panSelectSubject.PerformLayout();
            this.panSelectGrade.ResumeLayout(false);
            this.panSelectGrade.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel_body;
        private ComboBox cbxExamGroup;
        private Label lblComboBoxImage;
        private Panel panSelectGrade;
        private Label lblSelectGrade;
        private Panel panSeniorHighSchool;
        private Panel panCompulsoryEducation;
        private Panel panSelectSubject;
        private Panel panSubjcetRow2;
        private Panel panSubjcetRow1;
        private Label lblSelectSubject;
        private Panel panListArea;
    }
}