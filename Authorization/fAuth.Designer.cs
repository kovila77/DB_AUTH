namespace Authentication
{
    partial class fAuth
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnLogin = new System.Windows.Forms.Panel();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.lLogin = new System.Windows.Forms.Label();
            this.btAuthentication = new System.Windows.Forms.Button();
            this.pnPassword = new System.Windows.Forms.Panel();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lPassword = new System.Windows.Forms.Label();
            this.pnLogin.SuspendLayout();
            this.pnPassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnLogin
            // 
            this.pnLogin.Controls.Add(this.tbLogin);
            this.pnLogin.Controls.Add(this.lLogin);
            this.pnLogin.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnLogin.Location = new System.Drawing.Point(0, 0);
            this.pnLogin.Name = "pnLogin";
            this.pnLogin.Padding = new System.Windows.Forms.Padding(10, 10, 30, 10);
            this.pnLogin.Size = new System.Drawing.Size(284, 47);
            this.pnLogin.TabIndex = 0;
            // 
            // tbLogin
            // 
            this.tbLogin.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbLogin.Location = new System.Drawing.Point(58, 10);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(196, 20);
            this.tbLogin.TabIndex = 0;
            this.tbLogin.TextChanged += new System.EventHandler(this.tbLogin_TextChanged);
            // 
            // lLogin
            // 
            this.lLogin.Dock = System.Windows.Forms.DockStyle.Left;
            this.lLogin.Location = new System.Drawing.Point(10, 10);
            this.lLogin.Name = "lLogin";
            this.lLogin.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lLogin.Size = new System.Drawing.Size(48, 27);
            this.lLogin.TabIndex = 1;
            this.lLogin.Text = "Логин:";
            // 
            // btAuthentication
            // 
            this.btAuthentication.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btAuthentication.Enabled = false;
            this.btAuthentication.Location = new System.Drawing.Point(0, 92);
            this.btAuthentication.Name = "btAuthentication";
            this.btAuthentication.Size = new System.Drawing.Size(284, 23);
            this.btAuthentication.TabIndex = 1;
            this.btAuthentication.Text = "Аутентифицироваться";
            this.btAuthentication.UseVisualStyleBackColor = true;
            this.btAuthentication.Click += new System.EventHandler(this.btAuthentication_Click);
            // 
            // pnPassword
            // 
            this.pnPassword.Controls.Add(this.tbPassword);
            this.pnPassword.Controls.Add(this.lPassword);
            this.pnPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnPassword.Location = new System.Drawing.Point(0, 47);
            this.pnPassword.Name = "pnPassword";
            this.pnPassword.Padding = new System.Windows.Forms.Padding(10, 10, 30, 10);
            this.pnPassword.Size = new System.Drawing.Size(284, 68);
            this.pnPassword.TabIndex = 2;
            // 
            // tbPassword
            // 
            this.tbPassword.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbPassword.Location = new System.Drawing.Point(58, 10);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(196, 20);
            this.tbPassword.TabIndex = 0;
            this.tbPassword.UseSystemPasswordChar = true;
            this.tbPassword.TextChanged += new System.EventHandler(this.tbPassword_TextChanged);
            // 
            // lPassword
            // 
            this.lPassword.Dock = System.Windows.Forms.DockStyle.Left;
            this.lPassword.Location = new System.Drawing.Point(10, 10);
            this.lPassword.Name = "lPassword";
            this.lPassword.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lPassword.Size = new System.Drawing.Size(48, 48);
            this.lPassword.TabIndex = 1;
            this.lPassword.Text = "Пароль:";
            // 
            // fAuth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 115);
            this.Controls.Add(this.btAuthentication);
            this.Controls.Add(this.pnPassword);
            this.Controls.Add(this.pnLogin);
            this.MinimumSize = new System.Drawing.Size(300, 150);
            this.Name = "fAuth";
            this.Text = "Authentication";
            this.pnLogin.ResumeLayout(false);
            this.pnLogin.PerformLayout();
            this.pnPassword.ResumeLayout(false);
            this.pnPassword.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnLogin;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Label lLogin;
        private System.Windows.Forms.Button btAuthentication;
        private System.Windows.Forms.Panel pnPassword;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lPassword;
    }
}

