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
    /// Логика взаимодействия для CreditCreate.xaml
    /// </summary>
    public partial class CreditCreate : UserControl
    {
        public CreditCreate()
        {
            InitializeComponent();
        }

        private void create_credit_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataBase db = new DataBase();
                RijndaelAlgorithm rijn = new RijndaelAlgorithm();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                string description = description_creditcreate.Text;
                double value = Convert.ToDouble(value_creditcreate.Text.Replace(".", ","));
                string email = email_creditcreate.Text;
                MySqlCommand command = new MySqlCommand("INSERT INTO `credit_requests` ( `cr_description`, `cr_value`, `cr_email`, `cr_id_user`) VALUES ( @desc, @value, @email, @id)", db.GetConnection());
                command.Parameters.Add("@desc", MySqlDbType.VarChar).Value = description;
                command.Parameters.Add("@value", MySqlDbType.Double).Value = value;
                command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = Globals.id;
                db.OpenConnection();
                if (command.ExecuteNonQuery() == 1)
                {
                    success.Content = "Заявка принята, вас оповестят по почте о решении";
                    success.Foreground = Brushes.Green;
                }
                else
                {
                    success.Content = "Произошла ошибка";
                    success.Foreground = Brushes.Red;
                }
                db.CloseConnection();
            }
            catch
            {
                success.Content = "Произошла ошибка, проверьте введеные данные";
                success.Foreground = Brushes.Red;

            }
        }
    }
}
