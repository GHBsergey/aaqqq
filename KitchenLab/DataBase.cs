using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;

namespace KitchenLab
{
    class DataBase
    {
        //static string connection_string = "";
        static string connection_string1 = @"Data Source=SERGEYA\SA;Initial Catalog=KitchLab;Integrated Security=True; Initial Catalog=KitchLab; Integrated Security=True";


        SqlConnection sqlConnection = new SqlConnection(connection_string1);

        public void OpenConection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }


        public void ClosedConection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }


        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }


        public SqlDataAdapter Connect(string query)
        {
            try
            {
                sqlConnection.Open();//открывает подключение
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);// в объект эскьюэль команд вставляется команда и где ее исполнить 
                SqlDataReader reader = sqlCommand.ExecuteReader();//позволяет считать все строки выполненые коммандой

                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);//хранит ответ на запрос 

                reader.Close();
                sqlConnection.Close();

                return adapter;
            }
            catch (Exception err)
            {
                MessageBox.Show("Данные отсуствуют");
                MessageBox.Show(err.Message);
                sqlConnection.Close();
                return null;
            }
        }
    }
}
