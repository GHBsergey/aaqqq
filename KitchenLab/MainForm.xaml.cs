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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;

namespace KitchenLab
{
    /// <summary>
    /// Логика взаимодействия для MainForm.xaml
    /// </summary>
    public partial class MainForm : Window
    {
        string connectionString = @"Data Source=SERGEYA\SA;Initial Catalog=KitchLab;Integrated Security=True";

        public MainForm()
        {

            InitializeComponent();
            LoadDataTable();
            LoadDataTable1();
            LoadDataTable2();
            LoadDataTable3();
            LoadDataTable4();
        }

         DataTable dataTable = new DataTable();
         SqlDataAdapter adapter = new SqlDataAdapter();
        
        private void LoadDataTable()

        {
            try
            {
                // 1. Подключение к базе данных
                using (SqlConnection connection = new SqlConnection(connectionString))

                {
                    connection.Open();

                    // 2. Запрос для получения данных из таблицы
                    string query = "SELECT * FROM Categories"; 
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // 3. Чтение данных в DataTable
                        adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataTable);

                        // 4. Отображение данных в DataGrid
                        DataGrid1.ItemsSource = dataTable.DefaultView;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        private void LoadDataTable1()
        {
            try
            {
                // 1. Подключение к базе данных
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // 2. Запрос для получения данных из таблицы
                    string query1 = "SELECT * FROM Recipe";
                    using (SqlCommand command = new SqlCommand(query1, connection))
                    {
                        // 3. Чтение данных в DataTable
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable1 = new DataTable();
                        adapter.Fill(dataTable1);

                        // 4. Отображение данных в DataGrid
                        DataGrid2.ItemsSource = dataTable1.DefaultView;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        private void LoadDataTable2()
        {
            try
            {
                // 1. Подключение к базе данных
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // 2. Запрос для получения данных из таблицы
                    string query2 = "SELECT * FROM Ingredients";
                    using (SqlCommand command = new SqlCommand(query2, connection))
                    {
                        // 3. Чтение данных в DataTable
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable2 = new DataTable();
                        adapter.Fill(dataTable2);

                        // 4. Отображение данных в DataGrid
                        DataGrid3.ItemsSource = dataTable2.DefaultView;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        private void LoadDataTable3()
        {
            try
            {
                // 1. Подключение к базе данных
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // 2. Запрос для получения данных из таблицы
                    string query3 = "SELECT * FROM Calorie_Diary";
                    using (SqlCommand command = new SqlCommand(query3, connection))
                    {
                        // 3. Чтение данных в DataTable
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable3 = new DataTable();
                        adapter.Fill(dataTable3);

                        // 4. Отображение данных в DataGrid
                        DataGrid4.ItemsSource = dataTable3.DefaultView;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        private void LoadDataTable4()
        {
            try
            {
                // 1. Подключение к базе данных
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // 2. Запрос для получения данных из таблицы
                    string query1 = "SELECT * FROM Allergy";
                    using (SqlCommand command = new SqlCommand(query1, connection))
                    {
                        // 3. Чтение данных в DataTable
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable1 = new DataTable();
                        adapter.Fill(dataTable1);

                        // 4. Отображение данных в DataGrid
                        DataGrid5.ItemsSource = dataTable1.DefaultView;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dataTable.Clear();
            string text1 = tbkb1.Text;
            string text2 = tbkb2.Text;
            // ... добавить строки для получения текста из других TextBox

            if (string.IsNullOrEmpty(text1) || string.IsNullOrEmpty(text2))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("INSERT INTO Categories (Category_name, Description) VALUES (@Text1, @Text2)", connection))
                    {
                        command.Parameters.AddWithValue("@Text1", text1);
                        command.Parameters.AddWithValue("@Text2", text2);
                        
                        command.ExecuteNonQuery();
                        LoadDataTable();

                    }
                }
                
                MessageBox.Show("Текст успешно добавлен в базу данных!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении текста: " + ex.Message);
            }
        }

        private void add_recipe_Click(object sender, RoutedEventArgs e)
        {
            dataTable.Clear();
            string text1 = tbr1.Text;
            string text2 = tbr2.Text;
            string text3 = tbr3.Text;
            // ... добавить строки для получения текста из других TextBox

            if (string.IsNullOrEmpty(text1) || string.IsNullOrEmpty(text2) || string.IsNullOrEmpty(text3))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("INSERT INTO Recipe (Title, Description, Cooking_instructions) VALUES (@Text1, @Text2, @Text3)", connection))
                    {
                        command.Parameters.AddWithValue("@Text1", text1);
                        command.Parameters.AddWithValue("@Text2", text2);
                        command.Parameters.AddWithValue("@Text3", text3);

                        command.ExecuteNonQuery();
                        LoadDataTable1();

                    }
                }

                MessageBox.Show("Текст успешно добавлен в базу данных!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении текста: " + ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dataTable.Clear();
            string text1 = bti1.Text;
            string text2 = bti2.Text;
            string text3 = bti3.Text;
            string text4 = bti4.Text;
            string text5 = bti5.Text;
            // ... добавить строки для получения текста из других TextBox

            if (string.IsNullOrEmpty(text1) || string.IsNullOrEmpty(text2) || string.IsNullOrEmpty(text3) || string.IsNullOrEmpty(text4) || string.IsNullOrEmpty(text5))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("INSERT INTO Ingredients (Name_ingredient, Calorie_content, Squirrels, Fats, Carbohydrates) VALUES (@Text1, @Text2, @Text3,@Text4, @Text5)", connection))
                    {
                        command.Parameters.AddWithValue("@Text1", text1);
                        command.Parameters.AddWithValue("@Text2", text2);
                        command.Parameters.AddWithValue("@Text3", text3);
                        command.Parameters.AddWithValue("@Text4", text4);
                        command.Parameters.AddWithValue("@Text5", text5);

                        command.ExecuteNonQuery();
                        LoadDataTable2();

                    }
                }

                MessageBox.Show("Текст успешно добавлен в базу данных!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении текста: " + ex.Message);
            }
        }

        private void add_dk_Click(object sender, RoutedEventArgs e)
        {
            dataTable.Clear();
            string text1 = tbdk1.Text;
            string text2 = tbdk2.Text;
            string text3 = tbdk3.Text;
            string text4 = tbdk4.Text;
            string text5 = tbdk5.Text;
            string text6 = tbdk6.Text;
            string text7 = tbdk7.Text;
            // ... добавить строки для получения текста из других TextBox

            if (string.IsNullOrEmpty(text1) || string.IsNullOrEmpty(text2) || string.IsNullOrEmpty(text3) || string.IsNullOrEmpty(text4) || string.IsNullOrEmpty(text5))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("INSERT INTO Calorie_Diary (Squirrels, Fats, Carbohydrates, Calorie_content, Name_recipe, eating, day) VALUES (@Text1, @Text2, @Text3,@Text4, @Text5, @Text6, @Text7)", connection))
                    {
                        command.Parameters.AddWithValue("@Text1", text1);
                        command.Parameters.AddWithValue("@Text2", text2);
                        command.Parameters.AddWithValue("@Text3", text3);
                        command.Parameters.AddWithValue("@Text4", text4);
                        command.Parameters.AddWithValue("@Text5", text5);
                        command.Parameters.AddWithValue("@Text6", text6);
                        command.Parameters.AddWithValue("@Text7", text7);

                        command.ExecuteNonQuery();
                        LoadDataTable3();

                    }
                }

                MessageBox.Show("Текст успешно добавлен в базу данных!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении текста: " + ex.Message);
            }
        }

        private void delete_kt_Click(object sender, RoutedEventArgs e)
        {
            // Получение значения из TextBox
            string idToDelete = tbkb1.Text;
            dataTable.Clear();

            try
            {
                // Создание соединения с базой данных
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Создание команды для удаления данных
                    string deleteQuery = "DELETE FROM Categories WHERE Category_name = @Category_name";
                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        // Добавление параметра для Id
                        command.Parameters.AddWithValue("@Category_name", idToDelete);

                        // Открытие соединения
                        connection.Open();

                        // Выполнение команды удаления
                        int rowsAffected = command.ExecuteNonQuery();
                        LoadDataTable();

                        // Вывод результата
                        MessageBox.Show($"Удалено {rowsAffected} строк.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Обработка исключений
                MessageBox.Show($"Ошибка: {ex.Message}");
            }

        }

        private void delete_recipe_Click(object sender, RoutedEventArgs e)
        {
            // Получение значения из TextBox
            string idToDelete = tbr1.Text;
            dataTable.Clear();

            try
            {
                // Создание соединения с базой данных
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Создание команды для удаления данных
                    string deleteQuery = "DELETE FROM Recipe WHERE Title = @Title";
                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        // Добавление параметра для Id
                        command.Parameters.AddWithValue("@Title", idToDelete);

                        // Открытие соединения
                        connection.Open();

                        // Выполнение команды удаления
                        int rowsAffected = command.ExecuteNonQuery();
                        LoadDataTable1();

                        // Вывод результата
                        MessageBox.Show($"Удалено {rowsAffected} строк.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Обработка исключений
                MessageBox.Show($"Ошибка: {ex.Message}");
            }

        }

        private void delite_ingredient_Click(object sender, RoutedEventArgs e)
        {
            // Получение значения из TextBox
            string idToDelete = bti1.Text;
            dataTable.Clear();

            try
            {
                // Создание соединения с базой данных
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Создание команды для удаления данных
                    string deleteQuery = "DELETE FROM Ingredients WHERE Name_ingredient = @Name_ingredient";
                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        // Добавление параметра для Id
                        command.Parameters.AddWithValue("@Name_ingredient", idToDelete);

                        // Открытие соединения
                        connection.Open();

                        // Выполнение команды удаления
                        int rowsAffected = command.ExecuteNonQuery();
                        LoadDataTable2();

                        // Вывод результата
                        MessageBox.Show($"Удалено {rowsAffected} строк.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Обработка исключений
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        
    }

        private void delete_dk_Click(object sender, RoutedEventArgs e)
        {
            // Получение значения из TextBox
            string idToDelete = tbdk5.Text;
            dataTable.Clear();

            try
            {
                // Создание соединения с базой данных
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Создание команды для удаления данных
                    string deleteQuery = "DELETE FROM Calorie_Diary WHERE Name_recipe = @Name_recipe";
                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        // Добавление параметра для Id
                        command.Parameters.AddWithValue("@Name_recipe", idToDelete);

                        // Открытие соединения
                        connection.Open();

                        // Выполнение команды удаления
                        int rowsAffected = command.ExecuteNonQuery();
                        LoadDataTable3();

                        // Вывод результата
                        MessageBox.Show($"Удалено {rowsAffected} строк.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Обработка исключений
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void add_all_Click(object sender, RoutedEventArgs e)
        {
            dataTable.Clear();
            string text1 = tba.Text;
            string text2 = tba1.Text;
          
            if (string.IsNullOrEmpty(text1) || string.IsNullOrEmpty(text2))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("INSERT INTO Allergy (Name, Description) VALUES (@Text1, @Text2)", connection))
                    {
                        command.Parameters.AddWithValue("@Text1", text1);
                        command.Parameters.AddWithValue("@Text2", text2);

                        command.ExecuteNonQuery();
                        LoadDataTable4();

                    }
                }

                MessageBox.Show("Текст успешно добавлен в базу данных!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении текста: " + ex.Message);
            }
        }

        private void delete_allerg_Click(object sender, RoutedEventArgs e)
        {
            // Получение значения из TextBox
            string idToDelete = tba.Text;
            dataTable.Clear();

            try
            {
                // Создание соединения с базой данных
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Создание команды для удаления данных
                    string deleteQuery = "DELETE FROM Allergy WHERE Name = @Name";
                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        // Добавление параметра для Id
                        command.Parameters.AddWithValue("@Name", idToDelete);

                        // Открытие соединения
                        connection.Open();

                        // Выполнение команды удаления
                        int rowsAffected = command.ExecuteNonQuery();
                        LoadDataTable4();

                        // Вывод результата
                        MessageBox.Show($"Удалено {rowsAffected} строк.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Обработка исключений
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void update_kt_Click(object sender, RoutedEventArgs e)
        {
            string newName = tbkb1.Text;
            string newparameters = tbkb2.Text;
            dataTable.Clear();
            try
            {
                // Создание соединения с базой данных
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Создание команды для обновления данных
                    string updateQuery = "UPDATE Categories SET Category_name = @newName, Description = @newEmail " +
                                         // ... добавить обновления для других столбцов
                                         "WHERE Category_name = @newName";
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        // Добавление параметров
                        command.Parameters.AddWithValue("@newName", newName);
                        command.Parameters.AddWithValue("@newEmail", newparameters);
                        // ... добавить параметры для других столбцов

                        // Открытие соединения
                        connection.Open();

                        // Выполнение команды обновления
                        int rowsAffected = command.ExecuteNonQuery();
                        LoadDataTable();

                        // Вывод результата
                        MessageBox.Show($"Обновлено {rowsAffected} строк.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Обработка исключений
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void update_recipe_Click(object sender, RoutedEventArgs e)
        {
            string newName = tbr1.Text;
            string newparameters = tbr2.Text;
            string newparameters1 = tbr3.Text;
            dataTable.Clear();
            try
            {
                // Создание соединения с базой данных
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Создание команды для обновления данных
                    string updateQuery = "UPDATE Recipe SET Title = @newName, Description = @newEmail, Cooking_instructions = @Cooking_instructions WHERE Title = @newName";
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        // Добавление параметров
                        command.Parameters.AddWithValue("@newName", newName);
                        command.Parameters.AddWithValue("@newEmail", newparameters);
                        command.Parameters.AddWithValue("@Cooking_instructions", newparameters1);
                        // ... добавить параметры для других столбцов

                        // Открытие соединения
                        connection.Open();

                        // Выполнение команды обновления
                        int rowsAffected = command.ExecuteNonQuery();
                        LoadDataTable1();

                        // Вывод результата
                        MessageBox.Show($"Обновлено {rowsAffected} строк.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Обработка исключений
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void update_ingredient_Click(object sender, RoutedEventArgs e)
        {
            string newName = bti1.Text;
            string newparameters = bti2.Text;
            string newparameters1 = bti3.Text;
            string newparameters2 = bti4.Text;
            string newparameters3 = bti5.Text;
            dataTable.Clear();
            try
            {
                // Создание соединения с базой данных
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Создание команды для обновления данных
                    string updateQuery = "UPDATE Ingredients SET Name_ingredient = @newName, Calorie_content = @newEmail, Squirrels = @Squirrels, Fats = @Fats, Carbohydrates = @Carbohydrates WHERE Name_ingredient = @newName";
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        // Добавление параметров
                        command.Parameters.AddWithValue("@newName", newName);
                        command.Parameters.AddWithValue("@newEmail", newparameters);
                        command.Parameters.AddWithValue("@Squirrels", newparameters1);
                        command.Parameters.AddWithValue("@Fats", newparameters2);
                        command.Parameters.AddWithValue("@Carbohydrates", newparameters3);
                        // ... добавить параметры для других столбцов

                        // Открытие соединения
                        connection.Open();

                        // Выполнение команды обновления
                        int rowsAffected = command.ExecuteNonQuery();
                        LoadDataTable2();

                        // Вывод результата
                        MessageBox.Show($"Обновлено {rowsAffected} строк.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Обработка исключений
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void update_dk_Click_1(object sender, RoutedEventArgs e)
        {
            string newName = tbdk1.Text;
            string newparameters = tbdk2.Text;
            string newparameters1 = tbdk3.Text;
            string newparameters2 = tbdk4.Text;
            string newparameters3 = tbdk5.Text;
            string newparameters4 = tbdk6.Text;
            string newparameters5 = tbdk7.Text;
            dataTable.Clear();
            try
            {
                // Создание соединения с базой данных
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Создание команды для обновления данных
                    string updateQuery = "UPDATE Calorie_Diary SET Name_recipe = @newName, Squirrels = @newEmail, Fats = @Fats, Carbohydrates = @Carbohydrates, Calorie_content = @Calorie_content, eating = @eating, day = @day WHERE Name_recipe = @newName";
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        // Добавление параметров
                        command.Parameters.AddWithValue("@newName", newName);
                        command.Parameters.AddWithValue("@newEmail", newparameters);
                        command.Parameters.AddWithValue("@Fats", newparameters1);
                        command.Parameters.AddWithValue("@Carbohydrates", newparameters2);
                        command.Parameters.AddWithValue("@Calorie_content", newparameters3);
                        command.Parameters.AddWithValue("@eating", newparameters4);
                        command.Parameters.AddWithValue("@day", newparameters5);
                        // ... добавить параметры для других столбцов

                        // Открытие соединения
                        connection.Open();

                        // Выполнение команды обновления
                        int rowsAffected = command.ExecuteNonQuery();
                        LoadDataTable3();

                        // Вывод результата
                        MessageBox.Show($"Обновлено {rowsAffected} строк.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Обработка исключений
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void update_allerg_Click(object sender, RoutedEventArgs e)
        {
            string newName = tba.Text;
            string newparameters = tba1.Text;
            dataTable.Clear();
            try
            {
                // Создание соединения с базой данных
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Создание команды для обновления данных
                    string updateQuery = "UPDATE Allergy SET Name = @newName, Description = @newEmail " +
                                         // ... добавить обновления для других столбцов
                                         "WHERE Name = @newName";
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        // Добавление параметров
                        command.Parameters.AddWithValue("@newName", newName);
                        command.Parameters.AddWithValue("@newEmail", newparameters);
                        // ... добавить параметры для других столбцов

                        // Открытие соединения
                        connection.Open();

                        // Выполнение команды обновления
                        int rowsAffected = command.ExecuteNonQuery();
                        LoadDataTable4();

                        // Вывод результата
                        MessageBox.Show($"Обновлено {rowsAffected} строк.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Обработка исключений
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}
    



