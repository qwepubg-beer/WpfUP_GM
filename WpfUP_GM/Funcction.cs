using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfUP_GM
{
    public class Funcction
    {
        static public bool Enter(string login, string password)
        {
            if (!string.IsNullOrWhiteSpace(login) || !string.IsNullOrWhiteSpace(password))
            {
                User editUser = Core.GMEntities.User.FirstOrDefault(u => u.login == login);
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
        static public bool Reg(User person)
        {
            if (!string.IsNullOrEmpty(person.login) && !string.IsNullOrEmpty(person.password) && !string.IsNullOrEmpty(person.Name))
            {
                return true;
            }
            else
            {
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
    }
}
