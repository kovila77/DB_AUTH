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
//npgsql
//bouncyCaslte

namespace DB_UP_1_25._01._2020
{
    public partial class Form1 : Form
    {
        //npgsql
        private readonly Regex loginRegex = new Regex("^[А-Яа-я0-9]{6,50}$");

        private readonly string sConnStr = new NpgsqlConnectionStringBuilder
        {
            Host = Database.Default.Host,
            Port = Database.Default.Port,
            Database = Database.Default.Name,
            Username = "postgres",
            Password = "kovila77"
        }.ConnectionString;

        public Form1()
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
                epMain.SetError(tbLogin,
                    "Логин должен быть длиной от 6 до 50 и содержать только А-Яа-я0-9");
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
                        WHERE lower(login) = lower('@currentLogin')"
                };
                sCOmmand.Parameters.AddWithValue("@currentLogin", lLogin.Text);
                if ((long)sCOmmand.ExecuteScalar() > 0)
                {
                    epMain.SetError(tbLogin,
                        "Логин уже занят");
                    btRegister.Enabled = false;
                    return;
                }
            }
            epMain.SetError(tbLogin, "");
            btRegister.Enabled = true;

        }

        private static byte[] CalcHash(string filePath)
        {
            return Org.BouncyCastle.Security.DigestUtilities.CalculateDigest(
                "GOST3411-2012-256",
                File.ReadAllBytes(filePath)
                );
        }

        private void btRegister_Click(object sender, EventArgs e)
        {
            using (var sConn = new NpgsqlConnection(sConnStr))
            {
                sConn.Open();
                var sCOmmand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = @"
                        INSERT INTO users(login, image_hash)
                        VALUES (@currentlogin, @imagehash)"
                };
                sCOmmand.Parameters.AddWithValue("currentlogin",
                    tbLogin.Text);
                sCOmmand.Parameters.AddWithValue("imagehash",
                    CalcHash(tbPassword.Text));
                sCOmmand.ExecuteNonQuery(); // не нужно ответ от DB
            }
        }
    }
}
