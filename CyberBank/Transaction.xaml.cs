﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CyberBank
{
    /// <summary>
    /// Логика взаимодействия для Transaction.xaml
    /// </summary>
    public partial class Transaction : UserControl
    {
        public Transaction()
        {
            InitializeComponent();

        }

        private void trans_button_Click(object sender, RoutedEventArgs e)
        {
            success.Content = "";
            error.Content = "";
            bool fatal_error = true;
            string to_who = kuda_trans.Text;
            float value = float.Parse(how_much.Text);
            if (Globals.cache - value >= 0)
            {

            
                DataBase db = new DataBase();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                db.OpenConnection();
                MySqlCommand command = new MySqlCommand("SELECT ec_cartnumber FROM e_carts where ec_cartnumber = @cardnumber", db.GetConnection());
                command.Parameters.Add("@cardnumber", MySqlDbType.VarChar).Value = to_who;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    command = new MySqlCommand("UPDATE e_carts SET ec_cache=ec_cache+@value where ec_cartnumber = @cardnumber", db.GetConnection());
                    command.Parameters.Add("@cardnumber", MySqlDbType.VarChar).Value = to_who;
                    command.Parameters.Add("@value", MySqlDbType.Float).Value = value;
                    command.ExecuteNonQuery();
                    command = new MySqlCommand("UPDATE e_carts SET ec_cache=ec_cache-@value where ec_cartnumber = @cardnumber", db.GetConnection());
                    command.Parameters.Add("@cardnumber", MySqlDbType.VarChar).Value = Globals.cardnumber;
                    command.Parameters.Add("@value", MySqlDbType.Float).Value = value;
                    command.ExecuteNonQuery();
                    success.Content = "Перевод выполнен!";
                    error.Foreground = Brushes.Green;
                    fatal_error = false;

                }
                command = new MySqlCommand("SELECT u_id FROM users where u_username = @cardnumber", db.GetConnection());
                command.Parameters.Add("@cardnumber", MySqlDbType.VarChar).Value = to_who;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {

                    int id = Convert.ToInt32(command.ExecuteScalar());
                    command = new MySqlCommand("UPDATE e_carts SET ec_cache=ec_cache+@value where ec_cartholder_id = @cardnumber", db.GetConnection());
                    command.Parameters.Add("@cardnumber", MySqlDbType.VarChar).Value = id;
                    command.Parameters.Add("@value", MySqlDbType.Float).Value = value;
                    command.ExecuteNonQuery();
                    command = new MySqlCommand("UPDATE e_carts SET ec_cache=ec_cache-@value where ec_cartnumber = @cardnumber", db.GetConnection());
                    command.Parameters.Add("@cardnumber", MySqlDbType.VarChar).Value = Globals.cardnumber;
                    command.Parameters.Add("@value", MySqlDbType.Float).Value = value;
                    command.ExecuteNonQuery();
                    success.Content = "Перевод выполнен!";
                    success.Foreground = Brushes.Green;
                    fatal_error = false;
                }
                if (fatal_error)
                {
                    success.Content = "";
                    error.Content = "Проверьте данные.";
                    error.Foreground = Brushes.Red;
                }
            }
            else
            {
                error.Content = "Недостаточно денег.";
                error.Foreground = Brushes.Red;
            }
        }
    }
}