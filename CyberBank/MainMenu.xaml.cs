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
using IronPython.Hosting;
using IronPython.Runtime;
using IronPython;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;

namespace CyberBank
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        BackgroundWorker bw, bw1;
        int x = 1;
        public MainMenu()
        {

            InitializeComponent();
            if (Globals.role == "admin")
            {
                admin_button.Visibility = Visibility.Visible;
            }
            else admin_button.Visibility = Visibility.Collapsed;
            bw = new BackgroundWorker();
            bw.DoWork += (obj, ea) => get_card_info(1);
            bw.RunWorkerAsync();
            bw1 = new BackgroundWorker();
            bw1.DoWork += (obj, ea) => get_news(1);
            bw1.RunWorkerAsync();

        }

        private async void get_card_info(int times)
        {
            while (true)
            {
                RijndaelAlgorithm rijn = new RijndaelAlgorithm();
                DataBase db = new DataBase();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                db.OpenConnection();
                MySqlCommand command = new MySqlCommand("SELECT u_surname FROM users where u_username = @login and u_password = @pass", db.GetConnection());
                command.Parameters.Add("@login", MySqlDbType.VarChar).Value = Globals.login;
                command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = Globals.pass;
                adapter.SelectCommand = command;

                this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Background, new System.Windows.Threading.DispatcherOperationCallback(delegate
                {
                    if (command.ExecuteScalar() != null)
                    {
                        Globals.surname = command.ExecuteScalar().ToString();
                        Globals.surname = RijndaelAlgorithm.Decrypt(Globals.surname, rijn.passPhrase, rijn.saltValue, rijn.hashAlgorithm, rijn.passwordIterations, rijn.initVector, rijn.keySize);
                        Globals.cardholder = $"{Globals.name} {Globals.surname}";
                        Globals.cardholder = Globals.cardholder.ToUpper();
                        cardnumber_on_card.Content = Globals.cardnumber;
                        cardholder_name_on_card.Content = Globals.cardholder;
                        cvv_on_card.Content = Globals.cvv;
                    }
                    return null;
                }), null);
                db.CloseConnection();
                await Task.Delay(1000);
            }
        }
        private async void get_news(int times)
        {
            string folder = Environment.CurrentDirectory;
            Process proc = new Process();
            int check = 1;
            while (true)
            {
                try
                {
                    await Task.Delay(1000);
                    proc.StartInfo.FileName = $@"{folder}\py_script\start_script_invise.vbs";
                    proc.StartInfo.WorkingDirectory = $@"{folder}\py_script";
                    proc.Start();
                    await Task.Delay(1000);
                    this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Background, new System.Windows.Threading.DispatcherOperationCallback(delegate
                    {
                        news.Text = File.ReadAllText($"py_script/news{check}.txt", Encoding.Default).ToString();

                        return null;
                    }), null);
                    await Task.Delay(10000);
                    check++;
                    if (check == 5)
                    {
                        check = 1;
                    }
                }
                catch
                {

                }
            }

        }
        private void admin_button_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            MainMenuGrid.Children.Clear();
            usc = new AdminMainMenu();
            MainMenuGrid.Children.Add(usc);
        }

        private void to_trans_button_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            MainMenuGrid.Children.Clear();
            usc = new Transaction();
            MainMenuGrid.Children.Add(usc);
        }

        private void credit_button_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            MainMenuGrid.Children.Clear();
            usc = new CreditCreate();
            MainMenuGrid.Children.Add(usc);

        }

        private void reverse_Click(object sender, RoutedEventArgs e)
        {
            if (x % 2 != 0)
            {
                frontcard.Visibility = Visibility.Hidden;
                backcard.Visibility = Visibility.Visible;
                cvv_on_card.Visibility = Visibility.Visible;
                cardholder_name_on_card.Visibility = Visibility.Hidden;
                cardnumber_on_card.Visibility = Visibility.Hidden;
            }
            else
            {
                frontcard.Visibility = Visibility.Visible;
                backcard.Visibility = Visibility.Hidden;
                cvv_on_card.Visibility = Visibility.Hidden;
                cardholder_name_on_card.Visibility = Visibility.Visible;
                cardnumber_on_card.Visibility = Visibility.Visible;
            }
            x++;
        }
    }
}
