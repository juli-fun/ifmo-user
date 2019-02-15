using System;
using System.Security.Cryptography; // для md5
using System.Text; // для md5

namespace ifmo_user
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем тестового пользователя
            var User1 = new User("berezhkov@ifmo.ru", "P@ssw0rd_123",
            "berezhkov", "Бережков", "Андрей", "Вячеславович");
            // Выводим ФИО
            Console.WriteLine("ФИО полностью: " + User1.Get_Full_Initials());
            // Выводим сокращенные ФИО
            Console.WriteLine("ФИО сокращенно: " + User1.Get_Short_Initials());
            // Выводим возраст
            Console.WriteLine("Возраст: " + User1.Get_Age());
        }
    }

    public class User
    {
        // TODO: сделать геттеры и сеттеры для всех public-атрибутров
        public string email, login, fname, name, lname, auth_key;
        public DateTime created_at, updated_at, birth_date;
        private bool is_blocked;
        private bool is_authorized;
        private string password_md5;

        // Cоздание пользователя / регистрация
        // Параметры, которые помечены звездочкой (*), - обязательные,
        // также обязательный сделан логин. Остальные - необязательные
        public User (string _email, string _login, string _password = "",
            string _fname = "Surname", string _name = "Name",
            string _lname = "Middlename",
            string _birth_date = "1 / 1 / 1970 0:0:0 AM")
        {
            //TODO: if password == "" -> генерируем пароль
            //TODO: сохранение пароля в md5

            // Берем значения из параметров
            email = _email;
            login = _login;
            fname = _fname;
            name = _name;
            lname = _lname;
            birth_date = DateTime.Parse(_birth_date,
                System.Globalization.CultureInfo.InvariantCulture);

            // Хешируем пароль
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(_password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                password_md5 = sb.ToString();
            }

            // Временные метки
            created_at = DateTime.Now;
            updated_at = DateTime.Now;
        }

        // Авторизация по паролю
        public int Auth_Passwd (string _password)
        {
            var password_to_check = "";

            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(_password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                password_to_check = sb.ToString();
            }

            if (password_to_check == password_md5)
            {
                is_authorized = true;
                Console.WriteLine("Authorized!");
                return 0;
            }
            else
            {
                Console.WriteLine("Not authorized!");
                return 1;
            }
        }

        // Авторизация по ключу
        public int Auth_by_Key (string _auth_key)
        {
            // TODO: Реализовать полноценную авториазцию по ключу. Тут для
            // примера реализуем авторищзацию по md5-хэшу (хотя это небезопасно)

            if (_auth_key == password_md5)
            {
                is_authorized = true;
                Console.WriteLine("Authorized!");
                return 0;
            }
            else
            {
                Console.WriteLine("Not authorized!");
                return 1;
            }
        }

        // Восстановление пароля
        public int Recover_Passwd ()
        {
            // TODO: отправить ссылку на восстановление пароля на E-Mail и
            // реализовать метод восстановления пароля по ссылке
            return 0;
        }

        // Расчет возраста
        public int Get_Age ()
        {
            return (int.Parse(DateTime.Now.ToString("yyyyMMdd")) -
                int.Parse(birth_date.ToString("yyyyMMdd"))) / 10000;
        }

        // Вывод полных ФИО
        public string Get_Full_Initials ()
        {
            return fname + " " + name + " " + lname;
        }

        // Вывод сокращенных ФИО
        public string Get_Short_Initials ()
        {
            return fname + " " + name.Substring(0,1) + "." +
                lname.Substring(0, 1) + ".";
        }

        // Удаление пользователя реализуется деструктором по умолчанию (~User)
        // и отдельного описания не требует

        // Вместо создания метода обновления пользователя, мы сделали
        // редактируемыми опции объекта
        }
}
