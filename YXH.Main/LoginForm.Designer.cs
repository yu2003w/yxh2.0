using System.Windows.Forms;
namespace YXH.Main
{
    partial class LoginForm
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.panTopBbar = new System.Windows.Forms.Panel();
            this.panMinimum = new System.Windows.Forms.Panel();
            this.panClose = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.picBottom = new System.Windows.Forms.PictureBox();
            this.lblClearLocaldata = new System.Windows.Forms.Label();
            this.lblRememberUser = new System.Windows.Forms.Label();
            this.picLoginName = new System.Windows.Forms.PictureBox();
            this.txtLoginName = new System.Windows.Forms.TextBox();
            this.picPassWord = new System.Windows.Forms.PictureBox();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.pcbBackground = new System.Windows.Forms.PictureBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.ckbRememberAccount = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panTopBbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoginName)).BeginInit();
            this.picLoginName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPassWord)).BeginInit();
            this.picPassWord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbBackground)).BeginInit();
            this.pcbBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(27)))));
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(39, 448);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(0);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(280, 40);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "登 录";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // panTopBbar
            // 
            this.panTopBbar.BackgroundImage = global::YXH.Main.LoginFormRes.LoginForm_TopImage;
            this.panTopBbar.Controls.Add(this.panMinimum);
            this.panTopBbar.Controls.Add(this.panClose);
            this.panTopBbar.Controls.Add(this.lblTitle);
            this.panTopBbar.Location = new System.Drawing.Point(0, 0);
            this.panTopBbar.Margin = new System.Windows.Forms.Padding(0);
            this.panTopBbar.Name = "panTopBbar";
            this.panTopBbar.Size = new System.Drawing.Size(359, 24);
            this.panTopBbar.TabIndex = 26;
            this.panTopBbar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panTopBbar_MouseDown);
            // 
            // panMinimum
            // 
            this.panMinimum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panMinimum.BackColor = System.Drawing.Color.Transparent;
            this.panMinimum.BackgroundImage = global::YXH.Main.CommonRes.Minimum_Normal;
            this.panMinimum.Location = new System.Drawing.Point(311, 0);
            this.panMinimum.Name = "panMinimum";
            this.panMinimum.Size = new System.Drawing.Size(24, 24);
            this.panMinimum.TabIndex = 21;
            this.panMinimum.Click += new System.EventHandler(this.panMinimum_Click);
            this.panMinimum.MouseLeave += new System.EventHandler(this.panMinimum_MouseLeave);
            this.panMinimum.MouseHover += new System.EventHandler(this.panMinimum_MouseHover);
            // 
            // panClose
            // 
            this.panClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panClose.BackColor = System.Drawing.Color.Transparent;
            this.panClose.BackgroundImage = global::YXH.Main.CommonRes.Close_Normal;
            this.panClose.Location = new System.Drawing.Point(334, 0);
            this.panClose.Name = "panClose";
            this.panClose.Size = new System.Drawing.Size(24, 24);
            this.panClose.TabIndex = 22;
            this.panClose.Click += new System.EventHandler(this.panClose_Click);
            this.panClose.MouseLeave += new System.EventHandler(this.panClose_MouseLeave);
            this.panClose.MouseHover += new System.EventHandler(this.panClose_MouseHover);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(56, 16);
            this.lblTitle.TabIndex = 21;
            this.lblTitle.Text = "蘑菇云";
            // 
            // picBottom
            // 
            this.picBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picBottom.Image = global::YXH.Main.LoginFormRes.LoginForm_ButtomImage;
            this.picBottom.Location = new System.Drawing.Point(0, 516);
            this.picBottom.Name = "picBottom";
            this.picBottom.Size = new System.Drawing.Size(360, 8);
            this.picBottom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picBottom.TabIndex = 25;
            this.picBottom.TabStop = false;
            // 
            // lblClearLocaldata
            // 
            this.lblClearLocaldata.AutoSize = true;
            this.lblClearLocaldata.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(133)))), ((int)(((byte)(133)))));
            this.lblClearLocaldata.Image = global::YXH.Main.LoginFormRes.LoginForm_CheckBox_Normal;
            this.lblClearLocaldata.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblClearLocaldata.Location = new System.Drawing.Point(221, 399);
            this.lblClearLocaldata.Name = "lblClearLocaldata";
            this.lblClearLocaldata.Size = new System.Drawing.Size(95, 12);
            this.lblClearLocaldata.TabIndex = 3;
            this.lblClearLocaldata.Text = "   清空本地数据";
            this.lblClearLocaldata.Visible = false;
            this.lblClearLocaldata.Click += new System.EventHandler(this.lblClearLocaldata_Click);
            // 
            // lblRememberUser
            // 
            this.lblRememberUser.AutoSize = true;
            this.lblRememberUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(133)))), ((int)(((byte)(133)))));
            this.lblRememberUser.Image = global::YXH.Main.LoginFormRes.LoginForm_CheckBox_Selected;
            this.lblRememberUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRememberUser.Location = new System.Drawing.Point(8, 9);
            this.lblRememberUser.Name = "lblRememberUser";
            this.lblRememberUser.Size = new System.Drawing.Size(71, 12);
            this.lblRememberUser.TabIndex = 2;
            this.lblRememberUser.Text = "   记住帐号";
            this.lblRememberUser.Click += new System.EventHandler(this.lblRememberUser_Click);
            // 
            // picLoginName
            // 
            this.picLoginName.Controls.Add(this.txtLoginName);
            this.picLoginName.Image = global::YXH.Main.LoginFormRes.LoginForm_TextBoxBackground;
            this.picLoginName.Location = new System.Drawing.Point(40, 295);
            this.picLoginName.Name = "picLoginName";
            this.picLoginName.Size = new System.Drawing.Size(279, 40);
            this.picLoginName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picLoginName.TabIndex = 22;
            this.picLoginName.TabStop = false;
            // 
            // txtLoginName
            // 
            this.txtLoginName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLoginName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLoginName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(133)))), ((int)(((byte)(133)))));
            this.txtLoginName.Location = new System.Drawing.Point(10, 12);
            this.txtLoginName.Name = "txtLoginName";
            this.txtLoginName.Size = new System.Drawing.Size(265, 19);
            this.txtLoginName.TabIndex = 0;
            this.txtLoginName.Text = "请输入用户名";
            this.txtLoginName.Enter += new System.EventHandler(this.txtLoginName_Enter);
            this.txtLoginName.Leave += new System.EventHandler(this.txtLoginName_Leave);
            // 
            // picPassWord
            // 
            this.picPassWord.Controls.Add(this.txtPassWord);
            this.picPassWord.Image = global::YXH.Main.LoginFormRes.LoginForm_TextBoxBackground;
            this.picPassWord.Location = new System.Drawing.Point(39, 347);
            this.picPassWord.Name = "picPassWord";
            this.picPassWord.Size = new System.Drawing.Size(279, 40);
            this.picPassWord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picPassWord.TabIndex = 21;
            this.picPassWord.TabStop = false;
            // 
            // txtPassWord
            // 
            this.txtPassWord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassWord.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPassWord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(133)))), ((int)(((byte)(133)))));
            this.txtPassWord.Location = new System.Drawing.Point(10, 12);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.Size = new System.Drawing.Size(265, 19);
            this.txtPassWord.TabIndex = 1;
            this.txtPassWord.Text = "请输入密码";
            this.txtPassWord.Enter += new System.EventHandler(this.txtPassWord_Enter);
            this.txtPassWord.Leave += new System.EventHandler(this.txtPassWord_Leave);
            // 
            // pcbBackground
            // 
            this.pcbBackground.BackColor = System.Drawing.Color.Transparent;
            this.pcbBackground.BackgroundImage = global::YXH.Main.LoginFormRes.LoginForm_BackgroundImage;
            this.pcbBackground.Controls.Add(this.picLogo);
            this.pcbBackground.InitialImage = null;
            this.pcbBackground.Location = new System.Drawing.Point(0, 0);
            this.pcbBackground.Margin = new System.Windows.Forms.Padding(0);
            this.pcbBackground.Name = "pcbBackground";
            this.pcbBackground.Size = new System.Drawing.Size(359, 262);
            this.pcbBackground.TabIndex = 20;
            this.pcbBackground.TabStop = false;
            // 
            // picLogo
            // 
            this.picLogo.Image = global::YXH.Main.LoginFormRes.LoginForm_Logo;
            this.picLogo.Location = new System.Drawing.Point(111, 74);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(137, 114);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picLogo.TabIndex = 27;
            this.picLogo.TabStop = false;
            // 
            // ckbRememberAccount
            // 
            this.ckbRememberAccount.AutoSize = true;
            this.ckbRememberAccount.Location = new System.Drawing.Point(40, 398);
            this.ckbRememberAccount.Name = "ckbRememberAccount";
            this.ckbRememberAccount.Size = new System.Drawing.Size(72, 16);
            this.ckbRememberAccount.TabIndex = 27;
            this.ckbRememberAccount.Text = "记住帐号";
            this.ckbRememberAccount.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblRememberUser);
            this.panel1.Location = new System.Drawing.Point(40, 393);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 26);
            this.panel1.TabIndex = 28;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(359, 524);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ckbRememberAccount);
            this.Controls.Add(this.panTopBbar);
            this.Controls.Add(this.picBottom);
            this.Controls.Add(this.lblClearLocaldata);
            this.Controls.Add(this.picLoginName);
            this.Controls.Add(this.picPassWord);
            this.Controls.Add(this.pcbBackground);
            this.Controls.Add(this.btnLogin);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.Shown += new System.EventHandler(this.FormLogin_Shown);
            this.panTopBbar.ResumeLayout(false);
            this.panTopBbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLoginName)).EndInit();
            this.picLoginName.ResumeLayout(false);
            this.picLoginName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPassWord)).EndInit();
            this.picPassWord.ResumeLayout(false);
            this.picPassWord.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbBackground)).EndInit();
            this.pcbBackground.ResumeLayout(false);
            this.pcbBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private TextBox txtPassWord;
        private TextBox txtLoginName;
        private PictureBox pcbBackground;
        private Label lblTitle;
        private Panel panMinimum;
        private Panel panClose;
        private PictureBox picPassWord;
        private PictureBox picLoginName;
        private Label lblRememberUser;
        private Label lblClearLocaldata;
        private PictureBox picBottom;
        private Panel panTopBbar;
        private PictureBox picLogo;
        private CheckBox ckbRememberAccount;
        private Panel panel1;
    }
}