namespace DB_UP_1_25._01._2020
{
    partial class fReg
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
            this.components = new System.ComponentModel.Container();
            this.pnLogin = new System.Windows.Forms.Panel();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.lLogin = new System.Windows.Forms.Label();
            this.btRegister = new System.Windows.Forms.Button();
            this.oldImage = new System.Windows.Forms.OpenFileDialog();
            this.epMain = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lPassword = new System.Windows.Forms.Label();
            this.epLogin = new System.Windows.Forms.ErrorProvider(this.components);
            this.epPassword = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epMain)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // pnLogin
            // 
            this.pnLogin.Controls.Add(this.tbLogin);
            this.pnLogin.Controls.Add(this.lLogin);
            this.pnLogin.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnLogin.Location = new System.Drawing.Point(0, 0);
            this.pnLogin.Name = "pnLogin";
            this.pnLogin.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.pnLogin.Size = new System.Drawing.Size(535, 48);
            this.pnLogin.TabIndex = 0;
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(54, 0);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(444, 20);
            this.tbLogin.TabIndex = 0;
            this.tbLogin.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lLogin
            // 
            this.lLogin.AutoSize = true;
            this.lLogin.Dock = System.Windows.Forms.DockStyle.Left;
            this.lLogin.Location = new System.Drawing.Point(0, 0);
            this.lLogin.Name = "lLogin";
            this.lLogin.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lLogin.Size = new System.Drawing.Size(41, 16);
            this.lLogin.TabIndex = 1;
            this.lLogin.Text = "Логин:";
            // 
            // btRegister
            // 
            this.btRegister.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btRegister.Enabled = false;
            this.btRegister.Location = new System.Drawing.Point(0, 153);
            this.btRegister.Name = "btRegister";
            this.btRegister.Size = new System.Drawing.Size(535, 23);
            this.btRegister.TabIndex = 1;
            this.btRegister.Text = "Зарегистрироваться";
            this.btRegister.UseVisualStyleBackColor = true;
            this.btRegister.Click += new System.EventHandler(this.btRegister_Click);
            // 
            // oldImage
            // 
            this.oldImage.FileName = "openFileDialog1";
            // 
            // epMain
            // 
            this.epMain.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbPassword);
            this.panel1.Controls.Add(this.lPassword);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 48);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.panel1.Size = new System.Drawing.Size(535, 50);
            this.panel1.TabIndex = 2;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(54, 0);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(444, 20);
            this.tbPassword.TabIndex = 0;
            // 
            // lPassword
            // 
            this.lPassword.AutoSize = true;
            this.lPassword.Dock = System.Windows.Forms.DockStyle.Left;
            this.lPassword.Location = new System.Drawing.Point(0, 0);
            this.lPassword.Name = "lPassword";
            this.lPassword.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lPassword.Size = new System.Drawing.Size(48, 16);
            this.lPassword.TabIndex = 1;
            this.lPassword.Text = "Пароль:";
            // 
            // epLogin
            // 
            this.epLogin.ContainerControl = this;
            // 
            // epPassword
            // 
            this.epPassword.ContainerControl = this;
            // 
            // fReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 176);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btRegister);
            this.Controls.Add(this.pnLogin);
            this.Name = "fReg";
            this.Text = "Registration";
            this.pnLogin.ResumeLayout(false);
            this.pnLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epMain)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPassword)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnLogin;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Label lLogin;
        private System.Windows.Forms.Button btRegister;
        private System.Windows.Forms.OpenFileDialog oldImage;
        private System.Windows.Forms.ErrorProvider epMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lPassword;
        private System.Windows.Forms.ErrorProvider epLogin;
        private System.Windows.Forms.ErrorProvider epPassword;
    }
}

