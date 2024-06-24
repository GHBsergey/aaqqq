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
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace KitchenLab
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString = @"Data Source=SERGEYA\SA;Initial Catalog=KitchLab;Integrated Security=True";
        DataBase dataBase = new DataBase();
        public MainWindow()
        {
            InitializeComponent();       
        }


        public bool UserExists(string username, string hashedPassword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM User1 WHERE login = @Username AND password = @password", connection);

                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@password", hashedPassword);

                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }

        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashedBytes = sha256.ComputeHash(passwordBytes);
                return Convert.ToBase64String(hashedBytes);
            }
        }



        private void loginbt_Click(object sender, RoutedEventArgs e)
        {
            string username = login.Text;
            string password = pass.Text;

            string hashedPassword = HashPassword(password);

            if (UserExists(username, hashedPassword))
            {
                MessageBox.Show("Авторизация успешна!");
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль!");
            }
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            string username = login.Text;
            string password = pass.Text;
            string hashedPassword = HashPassword(password);

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }


            try
            {
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    using (SqlCommand command = new SqlCommand("INSERT INTO User1 (login, password) VALUES (@username, @Password)", connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", hashedPassword);
                        
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Регистрация прошла успешно!");
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при регистрации: " + ex.Message);
            }

          
            
        }
    }
}
