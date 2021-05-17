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
    /// Логика взаимодействия для registration.xaml
    /// </summary>
    public partial class registration : UserControl
    {
        public registration()
        {
            InitializeComponent();
        }

        private void registr_button_Click(object sender, RoutedEventArgs e)
        {
            RijndaelAlgorithm rijn = new RijndaelAlgorithm();
            DataBase db = new DataBase();
            String login = Userbox_reg.Text;
            String pass = Passbox_reg.Text;
            Globals.name = Name_reg.Text;
            Globals.surname = Surname_reg.Text; 
            Globals.cardholder = $"{Globals.name} {Globals.surname}";
            Globals.cardholder = Globals.cardholder.ToUpper();
            String dob = dob_reg.Text;
            String year = $"{ dob.Substring(6)}.";
            string day = dob.Substring(0, 2);
            string month = dob.Substring(3, 3);
            dob = year + month + day;
            string enc_login = RijndaelAlgorithm.Encrypt(login, rijn.passPhrase, rijn.saltValue, rijn.hashAlgorithm, rijn.passwordIterations, rijn.initVector, rijn.keySize);
            string enc_pass = RijndaelAlgorithm.Encrypt(pass, rijn.passPhrase, rijn.saltValue, rijn.hashAlgorithm, rijn.passwordIterations, rijn.initVector, rijn.keySize);
            string enc_name = RijndaelAlgorithm.Encrypt(Globals.name, rijn.passPhrase, rijn.saltValue, rijn.hashAlgorithm, rijn.passwordIterations, rijn.initVector, rijn.keySize);
            string enc_surname = RijndaelAlgorithm.Encrypt(Globals.surname, rijn.passPhrase, rijn.saltValue, rijn.hashAlgorithm, rijn.passwordIterations, rijn.initVector, rijn.keySize);
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` ( `u_username`, `u_password`, `u_name`, `u_surname`, `u_date_of_birth`) VALUES ( @username, @pass, @name, @surname, @dob)", db.GetConnection());
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = enc_login;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = enc_pass;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = enc_name;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = enc_surname;
            command.Parameters.Add("@dob", MySqlDbType.Date).Value = dob;

            db.OpenConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                UserControl usc = null;
                usc = new CartCreate();
                registration1.Children.Add(usc);
            }
            db.CloseConnection();

        }
    }
}
