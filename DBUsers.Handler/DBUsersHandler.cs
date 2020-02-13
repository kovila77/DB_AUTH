using Npgsql;
using PasswordHandler;
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
        /// <summary>
        /// regular expression that the username must match
        /// </summary>
        public static readonly string regularOfCorrectLogin = @"^[A-Za-z0-9_\-А-Яа-яёЁ~`!@#$%^&*()+\\\[\]{}:;'""|<>,.\s\/?=№]{6,50}$";

        private readonly Regex _loginRegex = new Regex(regularOfCorrectLogin);
        private readonly string _sConnStr = new NpgsqlConnectionStringBuilder
        {
            Host = Database.Default.Host,
            Port = Database.Default.Port,
            Database = Database.Default.Name,
            Username = Environment.GetEnvironmentVariable("POSTGRESQL_USERNAME"),
            Password = Environment.GetEnvironmentVariable("POSTGRESQL_PASSWORD"),
            AutoPrepareMinUsages = 2,
            MaxAutoPrepare = 10,
        }.ConnectionString;
        //private readonly PasswordHandler.PasswordHandler _pCoder = new PasswordHandler.PasswordHandler();

        public DBUsersHandler() { }

        /// <summary>
        /// try coonect to the database
        /// </summary>
        public void TryConnection()
        {
            using (var sConn = new NpgsqlConnection(_sConnStr))
            {
                sConn.Open();
            }
        }

        public string RemoveExtraSpaces(string str)
        {
            str = str.Trim();
            str = Regex.Replace(str, @"\s+", " ");
            return str;
        }

        /// <summary>
        /// checks whether there is a login in the database
        /// </summary>
        /// <param name="newLogin"></param>
        /// <returns></returns>
        public bool IsExistsInDBLogin(string newLogin)
        {
            newLogin = RemoveExtraSpaces(newLogin);

            if (!_loginRegex.IsMatch(newLogin)) return false;

            using (var sConn = new NpgsqlConnection(_sConnStr))
            {
                sConn.Open();
                var sCOmmand = new NpgsqlCommand
                {
                    Connection = sConn,
                    CommandText = @"
                        SELECT count(*)
                        FROM users
                        WHERE lower(ulogin) = lower(@currentLogin)"
                };
                sCOmmand.Parameters.AddWithValue("@currentLogin", newLogin);
                if ((long)sCOmmand.ExecuteScalar() > 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// add new user to databse
        /// </summary>
        /// <param name="newLogin"></param>
        /// <param name="newPassword"></param>
        public void AddNewUser(string newLogin, string newPassword)
        {
            if (!_loginRegex.IsMatch(RemoveExtraSpaces(newLogin)))
            {
                throw new ArgumentException("Bad login");
            }
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
                var salt = PasswordHandler.PasswordHandler.CreateSalt();
                sCOmmand.Parameters.AddWithValue("@salt", salt);

                //TODO
                //maybe use some thread? Yeah will be cool

                sCOmmand.Parameters.AddWithValue("@passwordHash", PasswordHandler.PasswordHandler.HashPassword(newPassword, salt));
                sCOmmand.ExecuteNonQuery(); // не нужно ответ от DB
            }
        }
    }
}
