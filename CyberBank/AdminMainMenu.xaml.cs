using MySql.Data.MySqlClient;
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
    /// Логика взаимодействия для AdminMainMenu.xaml
    /// </summary>
    public partial class AdminMainMenu : UserControl
    {
        public AdminMainMenu()
        {
            InitializeComponent();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataBase db = new DataBase();
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM `users`", db.GetConnection());
            db.OpenConnection();
            adapter.SelectCommand = cmd;
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            db.CloseConnection();
            int id = 1;
            FindAll(count, id);
            FindAllCredit(count, id);
        }

        class item
        {
            public string ID { get; set; }

            public string Username { get; set; }

            public string Name { get; set; }

            public string Surname { get; set; }
            public string Desc { get; set; }
            public string dob { get; set; }

            public string card { get; set; }

            public string Role { get; set; }
            public string email { get; set; }
            public double value { get; set; }
            public double value_need { get; set; }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataBase db = new DataBase();
            DataTable table = new DataTable();
            string request = search.Text.ToString();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            int id = 1;
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM `users`", db.GetConnection());
            db.OpenConnection();
            adapter.SelectCommand = cmd;
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            db.CloseConnection();
            DataGrid.Items.Clear();
            if (request == "" || request == "SEARCH")
            {
                FindAll(count, id);
                
                return;
            }
        }

        private void FindAll(int count, int id)
        {
            while (id <= count)
            {

                RijndaelAlgorithm rijn = new RijndaelAlgorithm();
                Querys q = new Querys();
                string username = RijndaelAlgorithm.Decrypt(q.select_by_id("u_username", "users", "u_id", id), rijn.passPhrase, rijn.saltValue, rijn.hashAlgorithm, rijn.passwordIterations, rijn.initVector, rijn.keySize);
                string name = $"{ RijndaelAlgorithm.Decrypt(q.select_by_id("u_name", "users", "u_id", id), rijn.passPhrase, rijn.saltValue, rijn.hashAlgorithm, rijn.passwordIterations, rijn.initVector, rijn.keySize)} {RijndaelAlgorithm.Decrypt(q.select_by_id("u_surname", "users", "u_id", id),rijn.passPhrase, rijn.saltValue, rijn.hashAlgorithm, rijn.passwordIterations, rijn.initVector, rijn.keySize)}";
                string date_of_birth = q.select_by_id("DATE_FORMAT(u_date_of_birth, '%d /%m /%Y')", "users", "u_id", id);
                string havecart = q.select_by_id("u_havecart", "users", "u_id", id);
                string role = q.select_by_id("u_role", "users", "u_id", id);
                double cache = Math.Round(Convert.ToDouble(q.select_by_id("ec_cache", "e_carts", "ec_cartholder_id", id)), 2);
                DataGrid.Items.Add(new item { ID = id.ToString(), Username = username, Name = name, dob = date_of_birth, card = havecart, value = cache, Role = role }); 
                id++;
            }
            id = 1;
        }
        private void FindAllCredit(int count, int id)
        {
            while (id <= count)
            {
                RijndaelAlgorithm rijn = new RijndaelAlgorithm();
                Querys q = new Querys();
                string desc = q.select_by_id_if("cr_description", "credit_requests", "cr_id_user", id);
                string email = q.select_by_id_if("cr_email", "credit_requests", "cr_id_user", id);
                string username = RijndaelAlgorithm.Decrypt(q.select_by_id_if("u_username", "users", "u_id", id), rijn.passPhrase, rijn.saltValue, rijn.hashAlgorithm, rijn.passwordIterations, rijn.initVector, rijn.keySize);
                string name = $"{ RijndaelAlgorithm.Decrypt(q.select_by_id_if("u_name", "users", "u_id", id), rijn.passPhrase, rijn.saltValue, rijn.hashAlgorithm, rijn.passwordIterations, rijn.initVector, rijn.keySize)} {RijndaelAlgorithm.Decrypt(q.select_by_id("u_surname", "users", "u_id", id), rijn.passPhrase, rijn.saltValue, rijn.hashAlgorithm, rijn.passwordIterations, rijn.initVector, rijn.keySize)}";
                string value_need_str = q.select_by_id_if("cr_value", "credit_requests", "cr_id_user", id);
                if(value_need_str != "")
                {
                    double value_need = Math.Round(Convert.ToDouble(value_need_str), 2);
                    double cache = Math.Round(Convert.ToDouble(q.select_by_id("ec_cache", "e_carts", "ec_cartholder_id", id)), 2);
                    CreditDataGrid.Items.Add(new item { Desc = desc, Username = username, value_need = value_need, value = cache, Name = name, email = email });
                }
                id++;
            }
        }

        private void user_datagrid_Click(object sender, RoutedEventArgs e)
        {
            Credit_border.Visibility = Visibility.Hidden;
            Users_border.Visibility = Visibility.Visible;
            search.Visibility = Visibility.Visible;
            credit.Visibility = Visibility.Hidden;
            credit_button.Visibility = Visibility.Hidden;
            search_button.Visibility = Visibility.Visible;
        }

        private void credit_datagrid_Click(object sender, RoutedEventArgs e)
        {         
            Users_border.Visibility = Visibility.Hidden;
            Credit_border.Visibility = Visibility.Visible;
            search.Visibility = Visibility.Hidden;
            credit.Visibility = Visibility.Visible;
            credit_button.Visibility = Visibility.Visible;
            search_button.Visibility = Visibility.Hidden;
        }

        private void credit_button_Click(object sender, RoutedEventArgs e)
        {
            DataBase db = new DataBase();
            Random rnd = new Random();
            Querys q = new Querys();
            Mail mail = new Mail();
            RijndaelAlgorithm rijn = new RijndaelAlgorithm();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            string credit_to_who = RijndaelAlgorithm.Encrypt(credit.Text, rijn.passPhrase, rijn.saltValue, rijn.hashAlgorithm, rijn.passwordIterations, rijn.initVector, rijn.keySize);
            DataTable table = new DataTable();
            db.OpenConnection();
            MySqlCommand command = new MySqlCommand("SELECT u_id FROM `users` where u_username = @login", db.GetConnection());
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = credit_to_who;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                int id = Convert.ToInt32(command.ExecuteScalar());
                string email = q.select_by_id_if("cr_email", "credit_requests", "cr_id_user", id);
                double value = Math.Round(Convert.ToDouble(q.select_by_id_if("cr_value", "credit_requests", "cr_id_user", id)));

                int cvv = rnd.Next(100, 999);
                String cardnumber = rnd.Next(1000, 9999).ToString();
                for (int i = 0; i <= 2; i++)
                {
                    cardnumber += rnd.Next(1000, 9999).ToString();
                }
                command = new MySqlCommand("INSERT INTO `credit_cards` ( `cr_ca_cache`, `cr_c_need_cache`, `cr_c_cardnuber`, `cr_c_id_cvv`, `cr_c_id_user`) VALUES ( @cache, @value_need, @cardnumber, @cvv, @id)", db.GetConnection());
                command.Parameters.Add("@cardnumber", MySqlDbType.VarChar).Value = cardnumber;
                command.Parameters.Add("@cache", MySqlDbType.Float).Value = value;
                command.Parameters.Add("@value_need", MySqlDbType.VarChar).Value = value;
                command.Parameters.Add("@cvv", MySqlDbType.VarChar).Value = cvv;
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                if (command.ExecuteNonQuery() == 1)
                {
                    success.Content = "Успешно";
                    success.Foreground = Brushes.Green;
                    command = new MySqlCommand("Delete FROM `credit_requests` where cr_id_user = @id", db.GetConnection());
                    command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                    command.ExecuteNonQuery();
                    mail.send_mail(email);
                    command = new MySqlCommand("UPDATE `users` SET `u_havecredit` = 1 where `u_id` = @id", db.GetConnection());
                    command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                    command.ExecuteNonQuery();
                }
                else
                {
                    success.Content = "Ошибка";
                    success.Foreground = Brushes.Red;
                }
                db.CloseConnection();
            }
        }
    }
}
