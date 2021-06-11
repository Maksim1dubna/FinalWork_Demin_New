using MySql.Data.MySqlClient;

namespace FinalWork_Demin
{
    class DB
    {
        MySqlConnection connection = new MySqlConnection("server = localhost; port = 3306; username = root; password = root;database = users2"); // информация для входа в БД
        public void openConnection() // метод класса открыть соединение
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }
        public void closeConnection() // метод класса закрыть соединение
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public MySqlConnection getConnection() // метод класса получить соединение
        {
            return connection;
        }
    }
}
