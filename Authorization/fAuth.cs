using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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
                MessageBox.Show("Вы успешно аутентифицированны");
            }
            else
            {
                MessageBox.Show("Вы не аутентифицированны!!!");
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
