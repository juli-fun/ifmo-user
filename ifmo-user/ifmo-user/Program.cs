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
        public string email, login, fname, name, lname, auth_key;
        public DateTime created_at, updated_at, birth_date;
        public bool is_blocked;
        private string password_md5;

        // Cоздание пользователя / регистрация
        // Параметры, которые помечены звездочкой (*), - обязательные,
        // также обязательный сделан логин. Остальные - необязательные
        public User (string _email, string _login, string _password = "",
            string _fname = "Surname", string _name = "Name",
            string _lname = "Middlename")
        {
            //TODO: if password == "" -> генерируем пароль
        }

        // Авторизация по паролю
        public int Auth_Passwd (string _password)
        {
            return 0;
        }

        // Авторизация по ключу
        public int Auth_by_Key (string _auth_key)
        {
            return 0;
        }

        // Восстановление пароля
        public int Recover_Passwd ()
        {
            return 0;
        }

        // Расчет возраста
        public int Get_Age ()
        {
            return 0;
        }

        // Вывод полных ФИО
        public string Get_Full_Initials ()
        {
            return "";
        }

        // Вывод сокращенных ФИО
        public string Get_Short_Initials()
        {
            return "";
        }

        // Eдаление пользователя
        ~User()
        {

        }

        // Вместо создания метода обновления пользователя, мы сделали
        // редактируемыми опции объекта 
        }
}
