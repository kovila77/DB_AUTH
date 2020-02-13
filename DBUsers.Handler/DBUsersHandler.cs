using Npgsql;
using PasswordCoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DBUsersHandler
{
    public class DBUsersHandler
    {
        public static readonly string regularOfCorrectLogin = "^[A-Za-z0-9]{6,50}$";

        private readonly Regex _loginRegex = new Regex(regularOfCorrectLogin);

        private readonly string _sConnStr;

        private readonly PasswordCoder.PasswordCoder _pCoder = new PasswordCoder.PasswordCoder();

        public DBUsersHandler()
        {
            _sConnStr = new NpgsqlConnectionStringBuilder
            {
                Host = Database.Default.Host,
                Port = Database.Default.Port,
                Database = Database.Default.Name,
                Username = Environment.GetEnvironmentVariable("POSTGRESQL_USERNAME"),
                Password = Environment.GetEnvironmentVariable("POSTGRESQL_PASSWORD"),
                AutoPrepareMinUsages = 2, //Если запрос выполняется хотябы два раза, то пошли в бд сообщение, что вот эту штуку надо заполнить
                MaxAutoPrepare = 10,
            }.ConnectionString;
        }

        public void tryConnection()
        {
            using (var sConn = new NpgsqlConnection(_sConnStr))
            {
                sConn.Open();
            }
        }

        public bool IsExistsInDBLogin(string newLogin)
        {
            using (var sConn = new NpgsqlConnection(_sConnStr))
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
                sCOmmand.Parameters.AddWithValue("@currentLogin", newLogin);
                if ((long)sCOmmand.ExecuteScalar() > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddNewUser(string newLogin, string newPassword)
        {
            using (var sConn = new NpgsqlConnection(_sConnStr))
            {
                sConn.Open();
                var sCOmmand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = @"
                        INSERT INTO users(ulogin, usalt, upassword)
                        VALUES (@currentlogin, @salt, @passwordHash)"
                };
                sCOmmand.Parameters.AddWithValue("@currentlogin", newLogin);
                var salt = _pCoder.CreateSalt();
                sCOmmand.Parameters.AddWithValue("@salt", salt);

                //TODO
                //may be use some thread? Yeah will be cool

                sCOmmand.Parameters.AddWithValue("@passwordHash", _pCoder.HashPassword(newPassword, salt));
                sCOmmand.ExecuteNonQuery(); // не нужно ответ от DB
            }
        }
    }
}
