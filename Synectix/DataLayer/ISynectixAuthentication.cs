using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface ISynectixAuthentication

    {
        //данные типа User
        User TryLogin(String login, String password);
        List<User> GetAllUser();
        User InsertUser(User obj);
        void UpdateUser(User obj);
        void DeleteUser(User obj);
        bool UserProject(User user);
        User GetUserById(int userId);

        //данные типа Role
        List<Role> GetAllRole();
        Role InsertRole(Role obj);
        void UpdateRole(Role obj);
        void DeleteRole(Role obj);

        //данные типа Function
        List<Function> GetAllFunction();
        Function InsertFunction(Function obj);
        void UpdateFunction(Function obj);
        void DeleteFunction(Function obj);

        //данные типа FunctionRole
        List<FunctionRole> GetAllFunctionRole(Role obj);
        void AddFunctionRole(Function function, Role role);
        void RemoveFunctionRole(FunctionRole obj);

        //главное окно
        List<MainMenuItem> GetMenuItem(String login);

        //сесуриту
        bool ChangePassword(String newpassword, User user);
        string GetHash(string pswd);
    }

    //меню главного окна
    public class MainMenuItem
    {
        public string FunctionName { get; set; }
        public string FormName { get; set; }
    }

}
