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
using System.Security.Cryptography;
using DBUsersHandler;
using PasswordHandler;

namespace Authentication
{
    public partial class fAuth : Form
    {
        private readonly Regex _loginRegex = new Regex(DBUsersHandler.DBUsersHandler.regularOfCorrectLogin);
        private DBUsersHandler.DBUsersHandler _dbConrol;

        public fAuth()
        {
            InitializeComponent();
            InitializeDBUserClass();
        }

        private void InitializeDBUserClass()
        {
            _dbConrol = new DBUsersHandler.DBUsersHandler();
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
            RefreshBtAuth();
        }

        private void btAuthentication_Click(object sender, EventArgs e)
        {
            btAuthentication.Enabled = false;
            if (_dbConrol.IsExistsInDBUser(tbLogin.Text, tbPassword.Text))
            {
                MessageBox.Show("success");
            }
            else
            {
                MessageBox.Show("unsuccess");
            }
            RefreshBtAuth();
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            RefreshBtAuth();
        }

        private void RefreshBtAuth()
        {
            if (tbPassword.Text != "" && tbLogin.Text != "")
            {
                btAuthentication.Enabled = true;
            }
            else
            {
                btAuthentication.Enabled = false;
            }
        }
    }
}
