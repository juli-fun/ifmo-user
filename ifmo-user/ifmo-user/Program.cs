using System;

namespace ifmo_user
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем тестового пользователя
            var User1 = new User("berezhkov@ifmo.ru", "P@ssw0rd_123",
            "berezhkov", "Бережков", "Андрей", "Вячеславович");
        }
    }

    public class User
    {
        public string email, login, password, fname, name, lname, auth_key;
        public DateTime created_at, updated_at, birth_date;
        public bool is_blocked;

        // Cоздание пользователя
        // Параметры, которые помечены звездочкой (*), - обязательные,
        // также обязательный сделан логин. Остальные - необязательные
        public User (string _email, string _password, string _login,
            string _fname = "Surname", string _name = "Name",
            string _lname = "Middlename")
        {

        }

        // Eдаление пользователя
        ~User()
        {

        }

        // Вместо создания метода обновления пользователя, мы сделали
        // редактируемыми опции объекта 

        public 
    }
}
