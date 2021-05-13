using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberBank
{
    class Querys
    {
        private DataBase db = new DataBase();
        private MySqlDataAdapter adapter = new MySqlDataAdapter();
        public string select_by_id(string what, string from, string where, int id)
        {
            db.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT {what} FROM {from} WHERE {where} = @id", db.GetConnection());
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            adapter.SelectCommand = command;
            string exit_data = command.ExecuteScalar().ToString();
            db.CloseConnection();
            return exit_data;
        }
        public string select_by_username_pass(string what, string from, string username, string pass)
        {
            db.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT {what} FROM {from} where u_username = @login and u_password = @pass", db.GetConnection());
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pass;
            adapter.SelectCommand = command;
            string exit_data = command.ExecuteScalar().ToString();
            db.CloseConnection();
            return exit_data;
        }

        public string select_by_id_if(string what, string from, string where, int id)
        {
            string exit_data = "";
            db.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT {what} FROM {from} WHERE {where} = @id", db.GetConnection());
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            adapter.SelectCommand = command;
            if (command.ExecuteScalar() != null)
            {
                exit_data = command.ExecuteScalar().ToString();
            }
            db.CloseConnection();
            return exit_data;
        }
        public string select_by_username_pass_if(string what, string from, string username, string pass)
        {
            string exit_data = "";
            db.OpenConnection();
            MySqlCommand command = new MySqlCommand($"SELECT {what} FROM {from} where u_username = @login and u_password = @pass", db.GetConnection());
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pass;
            adapter.SelectCommand = command;
            if (command.ExecuteScalar() != null)
            {
                exit_data = command.ExecuteScalar().ToString();
            }
            db.CloseConnection();
            return exit_data;
        }
    }
}
