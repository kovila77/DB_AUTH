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
//npgsql
//bouncyCaslte

namespace DB_UP_1_25._01._2020
{
    public partial class fReg : Form
    {
        //npgsql
        private readonly Regex loginRegex = new Regex("^[A-Za-z0-9]{6,50}$");
        //private readonly Regex loginRegex = new Regex("^[А-Яа-я0-9]{6,50}$");

        private readonly string sConnStr = new NpgsqlConnectionStringBuilder
        {
            Host = Database.Default.Host,
            Port = Database.Default.Port,
            Database = Database.Default.Name,
            Username = Environment.GetEnvironmentVariable("POSTGRESQL_USERNAME"),
            Password = Environment.GetEnvironmentVariable("POSTGRESQL_PASSWORD"),
            AutoPrepareMinUsages = 2, //Если запрос выполняется хотябы два раза, то пошли в бд сообщение, что вот эту штуку надо заполнить
            MaxAutoPrepare = 10,
        }.ConnectionString;

        public fReg()
        {
            InitializeComponent();
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            if (oldImage.ShowDialog() == DialogResult.OK)
            {
                // pbPassword.ImageLocation = oldImage.FileName;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!loginRegex.IsMatch(tbLogin.Text))
            {
                epLogin.SetError(tbLogin,
                    "Логин должен быть длиной от 6 до 50 и содержать только A-Za-z0-9");
                btRegister.Enabled = false;
                return;
            }
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                var sCOmmand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = @"
                        SELECT count(*)
                        FROM users
                        WHERE lower(ulogin) = lower('@currentLogin')"
                };
                sCOmmand.Parameters.AddWithValue("@currentLogin", lLogin.Text);
                if ((long)sCOmmand.ExecuteScalar() > 0)
                {
                    epLogin.SetError(tbLogin,
                        "Логин уже занят");
                    btRegister.Enabled = false;
                    return;
                }
            }
            epLogin.SetError(tbLogin, "");
            btRegister.Enabled = true;

        }

        private static byte[] CreateSalt()
        {
            var buffer = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);
            return buffer;
        }

        private static byte[] HashPassword(string password, byte[] salt)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));

            argon2.Salt = salt;
            argon2.DegreeOfParallelism = 8; // four cores
            argon2.Iterations = 2;
            argon2.MemorySize = 1024 * 64; // 64 MB

            return argon2.GetBytes(32);
        }

        private static bool VerifyHash(string password, byte[] salt, byte[] hash)
        {
            var newHash = HashPassword(password, salt);
            return hash.SequenceEqual(newHash);
        }

        //private static byte[] CalcHash(string password, )
        //{
        //    return HashPassword(password, CreateSalt());
        //    //MessageBox.Show(Encoding.ASCII.GetBytes(smthToCalc).ToString(), null, MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    //return Org.BouncyCastle.Security.DigestUtilities.CalculateDigest(
        //    //    "GOST3411-2012-256",
        //    //    Encoding.UTF8.GetBytes(smthToCalc)
        //    //    );
        //}

        private void btRegister_Click(object sender, EventArgs e)
        {
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                var sCOmmand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = @"
                        INSERT INTO users(ulogin, usalt, upassword)
                        VALUES (@currentlogin, @salt, @passwordHash)"
                };
                sCOmmand.Parameters.AddWithValue("currentlogin", tbLogin.Text);
                var salt = CreateSalt();
                sCOmmand.Parameters.AddWithValue("salt", salt);

                //TODO
                MessageBox.Show("now will be calc hash");
                Cursor.Current = Cursors.WaitCursor;

                sCOmmand.Parameters.AddWithValue("passwordHash", HashPassword(tbPassword.Text, salt));
                sCOmmand.ExecuteNonQuery(); // не нужно ответ от DB
                MessageBox.Show("hash calc complite");
                Cursor.Current = Cursors.Default;
                GC.Collect();
            }
        }
    }
}
