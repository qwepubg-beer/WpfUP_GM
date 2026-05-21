using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace WpfUP_GM
{
    public class Function
    {
        public static double Rewiew(Book book, double Rating)
        {
            int count = Core.GMEntities.Rewiew.Where(a => a.BookID == book.id).Count();
            return (book.Rating * count + Rating) / (count + 1);
        }
        static public bool Enter(string login, string password)
        {
            if (!string.IsNullOrWhiteSpace(login) || !string.IsNullOrWhiteSpace(password))
            {
                User editUser = Core.GMEntities.User.FirstOrDefault(u => u.login == login || u.email == login);
                if (editUser != null)
                {
                    if (editUser.password == password)
                    {
                        Static.user = editUser;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else { return false; }
            }
            else
            {
                return false;
            }
        }
        static public bool Reg(string login, string email, string name, string password)
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(name) && Emailvalidation(email))
            {
                User editUser = Core.GMEntities.User.FirstOrDefault(u => u.login == login || u.email == email);
                if (editUser != null)
                {
                    User newuser = new User
                    {
                        login = login,
                        email = email,
                        password = password,
                        Name = name,
                        IsActive = true,
                        RoleID = 1
                    };
                    Core.GMEntities.User.Add(newuser);
                    Static.user = newuser;
                    return true;
                }
                else { MessageBox.Show("Вы уже зарегистрированы!"); return false; }

            }
            else
            {
                MessageBox.Show("Заполните поля!");
                return false;
            }
        }
        public static bool IsReg()
        {
            if (Static.user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool UserIsActive()
        {
            return Static.user.IsActive;
        }
        private static bool Emailvalidation(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, emailPattern);
        }
    }
}
