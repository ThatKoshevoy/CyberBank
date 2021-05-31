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
    /// Логика взаимодействия для Credit.xaml
    /// </summary>
    public partial class Credit : UserControl
    {
        double value_need;
        double cache;
        public Credit()
        {
            InitializeComponent();
            Querys q = new Querys();
            value_need = Math.Round(Convert.ToDouble(q.select_by_id_if("cr_c_need_cache", "credit_cards", "cr_c_id_user", Globals.id)), 2);
            cache = Math.Round(Convert.ToDouble(q.select_by_id("cr_ca_cache", "credit_cards", "cr_c_id_user", Globals.id)), 2);
            credit_need.Content = $"Вам необходимо для Закрытия: {value_need} ₽";
            credit_value.Content = $"У вас есть: {cache}₽";
        }

        private void delete_credit_button_Click(object sender, RoutedEventArgs e)
        {
            if(value_need == cache)
            {
                DataBase db = new DataBase();
                db.OpenConnection();
                MySqlCommand command = new MySqlCommand("Delete FROM `credit_cards` where cr_c_id_user = @id", db.GetConnection());
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = Globals.id;
                command.ExecuteNonQuery();
                command = new MySqlCommand("UPDATE `users` SET `u_havecredit` = 0 where `u_id` = @id", db.GetConnection());
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = Globals.id;
                command.ExecuteNonQuery();
                db.CloseConnection();
                success.Content = "Успешно";
                success.Foreground = Brushes.Green;
            }
            else
            {
                success.Content = "Недостаточно денег на счете";
                success.Foreground = Brushes.Red;
            }
        }
    }
}
