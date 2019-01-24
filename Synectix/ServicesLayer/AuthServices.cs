using DataLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer
{
    public static class AuthServices
    {
        static ISynectixAuthentication authobject;

        //инициализация статического члена класса
        static AuthServices()
        {
            authobject = new SynectixAuthentication();
        }

        #region данные типа User
        
        //список всех пользователей
        public static List<User> GetAllUser()
        {
            return authobject.GetAllUser();
        }

        //поиск пользователя по Id
        public static User GetUserById(int userId)
        {
            return authobject.GetUserById(userId);
        }

        //добавление нового пользователя
        public static User InsertUser(User obj)
        {
            return authobject.InsertUser(obj);
        }

        //обновление данных пользователя
        public static void UpdateUser(User obj)
        {
            authobject.UpdateUser(obj);
        }

        //удалить пользователя
        public static void DeleteUser(User obj)
        {
            authobject.DeleteUser(obj);
        }

        //авторизация при входе в программу
        public static User TryLogin(string login, string password)
        {
            return authobject.TryLogin(login, password);
        }

        //проверка наличия проектов, связанных с данным пользователем
        public static bool UserProject(User user)
        {
            return authobject.UserProject(user);
        }
        #endregion

        #region данные типа Role
        //список ролей
        public static List<Role> GetAllRole()
        {
            return authobject.GetAllRole();
        }

        //добавление роли
        public static Role InsertRole(Role obj)
        {
            return authobject.InsertRole(obj);
        }

        //обновление роли
        public static void UpdateRole(Role obj)
        {
            authobject.UpdateRole(obj);
        }

        //удаление роли
        public static void DeleteRole(Role obj)
        {
            authobject.DeleteRole(obj);
        }
        #endregion

        #region данные типа Function
        //список ролей
        public static List<Function> GetAllFunction()
        {
            return authobject.GetAllFunction();
        }

        //добавление роли
        public static Function InsertFunction(Function obj)
        {
            return authobject.InsertFunction(obj);
        }

        //обновление роли
        public static void UpdateFunction(Function obj)
        {
            authobject.UpdateFunction(obj);
        }

        //удаление роли
        public static void DeleteFunction(Function obj)
        {
            authobject.DeleteFunction(obj);
        }
        #endregion

        #region данные типа FunctionRole

        //список закреплённых функций
        public static List<FunctionRole> GetAllFunctionRole(Role role)
        {
            return authobject.GetAllFunctionRole(role);
        }

        //закрепить функцию роли пользователя
        public static void AddFunctionRole(Function function, Role role)
        {
            authobject.AddFunctionRole(function, role);
        }

        //открепить функцию роли пользователя
        public static void RemoveFunctionRole(FunctionRole obj)
        {
            authobject.RemoveFunctionRole(obj);
        }
        #endregion

        #region главное окно

        //создать пункты меню в зависимости от типа пользователя
        public static List<MainMenuItem> GetMenuItem (String login)
        {
            return authobject.GetMenuItem(login);
        }

        #endregion

        #region сесуриту

        //поменять пароль
        public static bool ChangePassword(string newpassword, User user)
        {
            return authobject.ChangePassword(newpassword, user);
        }

        //хэш
        public static string GetHash(string pswd)
        {
            return authobject.GetHash(pswd);
        }

        #endregion
    }

}
