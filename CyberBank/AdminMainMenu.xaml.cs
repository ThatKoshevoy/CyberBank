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
        }

        class item
        {
            public string ID { get; set; }

            public string Username { get; set; }

            public string Name { get; set; }

            public string Surname { get; set; }

            public string dob { get; set; }

            public string card { get; set; }

            public string Role { get; set; }

            public double value { get; set; }

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
                Querys q = new Querys();
                string username = q.select_by_id("u_username", "users", "u_id", id);
                string name = $"{q.select_by_id("u_name", "users", "u_id", id)} {q.select_by_id("u_surname", "users", "u_id", id)}";
                string date_of_birth = q.select_by_id("DATE_FORMAT(u_date_of_birth, '%d /%m /%Y')", "users", "u_id", id);
                string havecart = q.select_by_id("u_havecart", "users", "u_id", id);
                string role = q.select_by_id("u_role", "users", "u_id", id);
                double cache = Math.Round(Convert.ToDouble(q.select_by_id("ec_cache", "e_carts", "ec_cartholder_id", id)), 2);
                DataGrid.Items.Add(new item { ID = id.ToString(), Username = username, Name = name, dob = date_of_birth, card = havecart, value = cache, Role = role }); 
                id++;
            }
        }
    }
}
