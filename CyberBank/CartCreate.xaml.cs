using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для CartCreate.xaml
    /// </summary>
    public partial class CartCreate : UserControl
    {
        public CartCreate()
        {
            InitializeComponent();
        }

        private void create_button_Click(object sender, RoutedEventArgs e)
        {
            DataBase db = new DataBase();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            Random rnd = new Random();        
            Globals.login = Userbox_cardcreate.Text;
            Globals.pass = Passbox_cardcreate.Text;
            string fullname = Globals.cardholder;
            float cache = rnd.Next(0, 1000);
            fullname = fullname.ToUpper();
            int cvv = rnd.Next(100, 999);
            String cardnumber = rnd.Next(1000, 9999).ToString();
            for(int i = 0; i <= 2; i++)
            {
                cardnumber += rnd.Next(1000, 9999).ToString();
            }
            db.OpenConnection();
            MySqlCommand command = new MySqlCommand("SELECT u_id FROM users where u_username = @login and u_password = @pass", db.GetConnection());
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = Globals.login;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = Globals.pass;
            adapter.SelectCommand = command;
            int id = Convert.ToInt32(command.ExecuteScalar());
            command = new MySqlCommand("INSERT INTO `e_carts` ( `ec_cartnumber`, `ec_cache`, `ec_cvv`, `ec_cartholder_name`, `ec_cartholder_id`) VALUES ( @cardnumber, @cache, @cvv, @fullname, @id)", db.GetConnection());
            command.Parameters.Add("@cardnumber", MySqlDbType.VarChar).Value = cardnumber;
            command.Parameters.Add("@cache", MySqlDbType.Float).Value = cache;
            command.Parameters.Add("@cvv", MySqlDbType.Int32).Value = cvv;
            command.Parameters.Add("@fullname", MySqlDbType.VarChar).Value = fullname;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            if (command.ExecuteNonQuery() == 1)
            {
                command = new MySqlCommand("UPDATE `users` SET `u_havecart` = 1 where `u_id` = @id", db.GetConnection());
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                command.ExecuteNonQuery();
                command = new MySqlCommand("SELECT u_id FROM users where u_username = @login and u_password = @pass", db.GetConnection());
                command.Parameters.Add("@login", MySqlDbType.VarChar).Value = Globals.login;
                command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = Globals.pass;
                adapter.SelectCommand = command;
                Globals.id = Convert.ToInt32(command.ExecuteScalar());
                UserControl usc = null;
                usc = new MainMenu();
                CreateGrid.Children.Add(usc);        
            }
            else
            {
                
            }
            db.CloseConnection();



        }
    }
}
