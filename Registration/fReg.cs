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
            _dbConrol.tryConnection();
            //TODO
            MessageBox.Show("hello! Do пинок до бд");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!loginRegex.IsMatch(tbLogin.Text))
            {
                epLogin.SetError(tbLogin,
                    "Некорректный логин");
                btRegister.Enabled = false;
                return;
            }
            if (_dbConrol.IsExistsInDBLogin(tbLogin.Text))
            {
                epLogin.SetError(tbLogin, "Логин уже занят");
                btRegister.Enabled = false;
                return;
            }
            epLogin.SetError(tbLogin, "");
            btRegister.Enabled = true;
        }

        private void btRegister_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            MessageBox.Show("Now will be calc hash. OK to bigin");
            _dbConrol.AddNewUser(tbLogin.Text, tbPassword.Text);
            MessageBox.Show("hash calc complite");
            Cursor.Current = Cursors.Default;
        }
    }
}
