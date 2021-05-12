using MySql.Data.MySqlClient;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
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
using System.Windows.Threading;
using System.Xml.Linq;

namespace CyberBank
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int x = 1;
        BackgroundWorker bw, bw1;
        public MainWindow()
        {
            InitializeComponent();
            bw = new BackgroundWorker();
            bw.DoWork += (obj, ea) => get_course(1);
            bw.RunWorkerAsync();
            bw1 = new BackgroundWorker();
            bw1.DoWork += (obj, ea) => get_cache(1);
            bw1.RunWorkerAsync();
        }

        private string change_cardnumber(string cardnumber)
        {
            string first = $"{cardnumber.Substring(0, 4)} ";
            string second = cardnumber.Substring(4, 4) + " ";
            string third = cardnumber.Substring(8, 4) + " ";
            string fourth = cardnumber.Substring(12, 4) + " ";
            string exit = first + second + third + fourth;
            return exit;
        }
        private async void get_cache(int times)
        {
            
            while (true)
            {
                try
                {
                    Querys q = new Querys();
                    DataBase db = new DataBase();
                    DataTable table = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    db.OpenConnection();
                    MySqlCommand command = new MySqlCommand("SELECT u_id FROM users where u_username = @login and u_password = @pass", db.GetConnection());
                    command.Parameters.Add("@login", MySqlDbType.VarChar).Value = Globals.login;
                    command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = Globals.pass;
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    if (table.Rows.Count > 0)
                    {
                        int id = Convert.ToInt32(command.ExecuteScalar());
                        Globals.cache = float.Parse(q.select_by_id_if("ec_cache", "e_carts", "ec_cartholder_id", id));
                        Globals.cvv = q.select_by_id_if("ec_cvv", "e_carts", "ec_cartholder_id", id);
                        Globals.cardnumber = q.select_by_id_if("ec_cartnumber", "e_carts", "ec_cartholder_id", id);
                        Globals.cardnumber = change_cardnumber(Globals.cardnumber);
                        Globals.role = q.select_by_username_pass_if("u_role","users",Globals.login, Globals.pass);
                        this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Background, new System.Windows.Threading.DispatcherOperationCallback(delegate
                        {
                            topicname.Content = Globals.name;
                            carts.Content = "Ваша карта";
                            cart_value.Content = $"Баланс: {Globals.cache}₽";
                            cart_cvv.Content = $"CVV {Globals.cvv}";
                            cart_number.Content = Globals.cardnumber;
                            is_admin.Content = Globals.role;
                            return null;
                        }), null);                        
                    }
                        db.CloseConnection();
                        await Task.Delay(1000);
                    
                }
                catch (MySql.Data.MySqlClient.MySqlException)
                {

                }
            }
        }
        private async void get_course(int times)
        {
            while (true)
            {
                Ping ping = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = ping.Send(host, timeout, buffer, pingOptions);
                if (reply.Status == IPStatus.Success)
                {
                    WebClient client = new WebClient();
                    var xml = client.DownloadString("https://www.cbr-xml-daily.ru/daily.xml");
                    XDocument xdoc = XDocument.Parse(xml);
                    var el = xdoc.Element("ValCurs").Elements("Valute");
                    string usd = el.Where(x => x.Attribute("ID").Value == "R01235").Select(x => x.Element("Value").Value).FirstOrDefault();
                    string eur = el.Where(x => x.Attribute("ID").Value == "R01239").Select(x => x.Element("Value").Value).FirstOrDefault();
                    double eur_double = Convert.ToDouble(eur);
                    double usd_double = Convert.ToDouble(usd);
                    eur_double = Math.Round(eur_double, 2);
                    usd_double = Math.Round(usd_double, 2);
                    this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Background, new System.Windows.Threading.DispatcherOperationCallback(delegate
                    {
                        EUR.Content = $"Евро: {eur_double}";
                        USD.Content = $"Доллар: {usd_double}";
                        return null;
                    }), null);
                }
                await Task.Delay(5000);
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Frame_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
            string aboba = "kek";
        }

        private void login_button_Click(object sender, RoutedEventArgs e)
        {
            Querys q = new Querys();
            Ping ping = new Ping();
            DataBase db = new DataBase();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            String host = "google.com";
            byte[] buffer = new byte[32];
            int timeout = 1000;
            PingOptions pingOptions = new PingOptions();
            PingReply reply = ping.Send(host, timeout, buffer, pingOptions);
            if (reply.Status == IPStatus.Success)
            {
                try {
                    error.Content = "";
                    Globals.login = Userbox.Text;
                    if (x % 2 == 0)
                    {
                        Globals.pass = pass_reveal.Text;
                    }
                    else Globals.pass = Passbox.Password;
                    Userbox.Text = "";
                    Passbox.Password = "";
                    db.OpenConnection();
                    MySqlCommand command = new MySqlCommand("SELECT u_name FROM users where u_username = @login and u_password = @pass", db.GetConnection());
                    command.Parameters.Add("@login", MySqlDbType.VarChar).Value = Globals.login;
                    command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = Globals.pass;
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    if (table.Rows.Count > 0)
                    {
                        Globals.name = command.ExecuteScalar().ToString();
                        db.CloseConnection();
                        topicname.Content = Globals.name;
                        String havecart = q.select_by_username_pass("u_havecart", "users", Globals.login, Globals.pass);
                        if (havecart == "1")
                        {
                            int id = Convert.ToInt32(q.select_by_username_pass("u_id", "users", Globals.login, Globals.pass));

                            Globals.cardnumber = q.select_by_id("ec_cartnumber", "e_carts", "ec_cartholder_id", id);
                            Globals.cardnumber = change_cardnumber(Globals.cardnumber);
                            Globals.cvv = q.select_by_id("ec_cvv", "e_carts", "ec_cartholder_id", id);
                            Globals.cache = float.Parse(q.select_by_id("ec_cache", "e_carts", "ec_cartholder_id", id));
                            Globals.role = q.select_by_username_pass("u_role", "users", Globals.login, Globals.pass);

                            cart_number.Content = Globals.cardnumber;
                            cart_cvv.Content = $"CVV {Globals.cvv}";
                            cart_value.Content = $"Баланс: {Globals.cache}₽";
                            carts.Content = "Ваша карта";
                            is_admin.Content = Globals.role;

                            UserControl usc = null;
                            GridMain.Children.Clear();
                            usc = new MainMenu();
                            GridMain.Children.Add(usc);

                        }
                        else
                        {
                            UserControl usc = null;
                            GridMain.Children.Clear();
                            usc = new CartCreate();
                            GridMain.Children.Add(usc);
                        }
                    }
                    else
                    {
                        error.Content = "Учетная запись не найдена";
                        error.Foreground = Brushes.Red;
                    }
                }
                catch (MySqlException)
                {
                    error.Content = "Нет связи с БД";
                    error.Foreground = Brushes.Red;
                }
            }
            else
            {
                error.Content = "Нет соединения с интернетом";
                error.Foreground = Brushes.Red;
            }
        }

        private void registration_button_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();
            usc = new registration();
            GridMain.Children.Add(usc);
        }

        private void go_home_Click(object sender, RoutedEventArgs e)
        {
            if (Globals.login == "")
            {
                GridMain.Children.Clear();
            }
            else
            {
                UserControl usc = null;
                GridMain.Children.Clear();
                usc = new MainMenu();
                GridMain.Children.Add(usc);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (x % 2 != 0)
            {
                pass_reveal.Text = Passbox.Password;
                passbox_bord.Visibility = Visibility.Hidden;
                pass_reveal_bord.Visibility = Visibility.Visible;
            }
            else
            {
                Passbox.Password = pass_reveal.Text;
                passbox_bord.Visibility = Visibility.Visible;
                pass_reveal_bord.Visibility = Visibility.Hidden;
            }
            x++;
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            if (Globals.login != "")
            {
                GridMain.Children.Clear();
                cart_number.Content = "";
                cart_value.Content = "";
                carts.Content = "";
                cart_cvv.Content = "";
                topicname.Content = "";
                is_admin.Content = "";
                Globals.login = "";
                Globals.role = "";
            }
        }
    }
}
