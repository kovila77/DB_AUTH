using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions; // для регулярок
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Security.Cryptography;
using Konscious.Security.Cryptography;
using DBUsersHandler;
using PasswordHandler;

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
                epLogin.SetError(tbLogin, "Некорректный логин");
                //btRegister.Enabled = false;
            }
            else
            {
                if (_dbConrol.IsExistsInDBLogin(tbLogin.Text))
                {
                    epLogin.SetError(tbLogin, "Логин уже занят");
                    //btRegister.Enabled = false;
                }
                else
                {
                    epLogin.SetError(tbLogin, "");
                }
            }
            //btRegister.Enabled = true;
            RefreshBtReg();
        }

        private void btRegister_Click(object sender, EventArgs e)
        {
            btRegister.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            MessageBox.Show("Now will be calc hash. OK to begin");
            _dbConrol.AddNewUser(tbLogin.Text, tbPassword.Text);
            MessageBox.Show("hash calc complite");
            Cursor.Current = Cursors.Default;
            epLogin.SetError(tbLogin, "Логин уже занят");
            RefreshBtReg();
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            if (!PasswordHandler.PasswordHandler.IsStrongPassword(tbPassword.Text, new List<string> { tbLogin.Text }))
            {
                epPassword.SetError(tbPassword, "Слабый пороль логин");
                //btRegister.Enabled = false;
            }
            else
            {
                epPassword.SetError(tbPassword, "");
            }
            RefreshBtReg();
            //btRegister.Enabled = true;
        }

        private void RefreshBtReg()
        {
            if (epPassword.GetError(tbPassword) == "" && epLogin.GetError(tbLogin) == "")
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
