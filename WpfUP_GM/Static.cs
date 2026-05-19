using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfUP_GM
{
    public class Static
    {
        public static User user=null;
    }
    //изменение в бд
    //лист заявок для админа
    // изменить книгу для автора bookinfo
    // adminpage navigation
    // authorpage navigation
    // edit/add book window
    // admin list of rewiew
    // admin list of report
    // дизайн
    // перенос бд
    /*
       public string Type => GetTypeReport();

        public string GetTypeReport()
        {
            if(User1 != null)
            {
                return $"жалоба на автора {User1.login}";
            }
            else if(Book != null)
            {
                return $"жалоба на книгу {Book.Name} автора {Book.User.login}";
            }
            else
            {
                return $"жалоба на отзыв пользователя {Rewiew.User.login}";
            }
        }
            public int ReturnRoleID()
        {
            Role role = Core.GMEntities.Role.Find(RoleID);
            return role != null? role.id : 1;
        }
     */
}
