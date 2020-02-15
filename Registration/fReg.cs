using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Registration
{
    public partial class fReg : Form
    {
        private readonly Regex loginRegex = new Regex(DBUsersHandler.DBUsersHandler.regularOfCorrectLogin);
        private DBUsersHandler.DBUsersHandler _dbConrol = new DBUsersHandler.DBUsersHandler();

        public fReg()
        {
            InitializeComponent();
            InitializeDBUserClass();
        }

        private void InitializeDBUserClass()
        {
            try
            {
                _dbConrol.TryConnection();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Trouble with DB\n{e.Message}");
                throw e;
            }
        }

        private void tbLogin_TextChanged(object sender, EventArgs e)
        {
            if (!loginRegex.IsMatch(tbLogin.Text))
            {
                epMain.SetError(tbLogin, "Некорректный логин: В логине могут быть использованы символы, изображённые на классической русско-английской раскладке клавиатуре. Длина логина от 6 до 50 символов");
            }
            else
            {
                if (_dbConrol.IsExistsInDBLogin(tbLogin.Text))
                {
                    epMain.SetError(tbLogin, "Логин уже занят");
                }
                else
                {
                    epMain.SetError(tbLogin, "");
                }
            }
            RefreshBtReg();
        }

        private void btRegister_Click(object sender, EventArgs e)
        {
            btRegister.Enabled = false;
            _dbConrol.AddNewUser(tbLogin.Text, tbPassword.Text);
            MessageBox.Show("Регистрация прошла успешно");
            epMain.SetError(tbLogin, "Логин уже занят");
            RefreshBtReg();
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            if (!PasswordHandler.PasswordHandler.IsStrongPassword(tbPassword.Text, new List<string> { tbLogin.Text }))
            {
                epMain.SetError(tbPassword, "Слабый пороль");
            }
            else
            {
                epMain.SetError(tbPassword, "");
            }
            RefreshBtReg();
        }

        private void RefreshBtReg()
        {
            if (epMain.GetError(tbPassword) == "" && epMain.GetError(tbLogin) == "")
            {
                btRegister.Enabled = true;
            }
            else
            {
                btRegister.Enabled = false;
            }
        }
    }
}
