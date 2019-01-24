using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataLayer
{
    public class SynectixAuthentication : ISynectixAuthentication
    {
        #region данные типа User

        //список пользователей
        public List<User> GetAllUser()
        {
            using (DataEntities db = new DataEntities())
            {
                return db.Users.ToList();
            }
        }

        //поиск пользователя по Id
        public User GetUserById(int userId)
        {
            using (DataEntities db = new DataEntities())
            {
                  var sql = (from ur in db.Users
                             where ur.Id == userId
                             select ur).SingleOrDefault();
                return sql;
            }
        }

        //добавить пользователя
        public User InsertUser(User obj)
        {
            using(DataEntities db = new DataEntities())
            {
                obj.Password = GetHash(obj.Password);
                db.Users.Add(obj);
                db.SaveChanges();
                return obj;
            }  
        }

        //обновить данные пользователя
        public void UpdateUser(User obj)
        {
            using (DataEntities db = new DataEntities())
            {
                obj.Password = GetHash(obj.Password);
                db.Users.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        //удалить пользователя
        public void DeleteUser(User obj)
        {
            using (DataEntities db = new DataEntities())
            {
                db.Users.Attach(obj);
                db.Users.Remove(obj);
                db.SaveChanges();
            }
        }

        //вход в программу (авторизация)
        public User TryLogin(string login, string password)
        {
            //проверка наличия пары "логин-пароль" в базе
            using (DataEntities db = new DataEntities())
            {
                var sql = (from user in db.Users
                           where user.Login == login && user.Password == password
                           select user).SingleOrDefault();

                return sql;
            }
        }

        //проверка наличия проектов, связанных с данным пользователем
        public bool UserProject(User user)
        {
            using(DataEntities db = new DataEntities())
            {
                var sql = (from pr in db.Projects
                          where pr.IdImplementer == user.Id || pr.IdManager == user.Id
                          select pr).DefaultIfEmpty(null).FirstOrDefault();

                if(sql != null)
                {
                    return true;
                }
                return false;
            }
        }

        #endregion

        #region данные типа Role
        //список ролей
        public List<Role> GetAllRole()
        {
            using (DataEntities db = new DataEntities())
            {
                return db.Roles.ToList();
            }
        }

        //добавить роль
        public Role InsertRole(Role obj)
        {
            using (DataEntities db = new DataEntities())
            {
                db.Roles.Add(obj);
                db.SaveChanges();
                return obj;
            }
        }

        //обновить роль
        public void UpdateRole(Role obj)
        {
            using (DataEntities db = new DataEntities())
            {
                db.Roles.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        //удалить роль
        public void DeleteRole(Role obj)
        {
            using (DataEntities db = new DataEntities())
            {
                db.Roles.Attach(obj);
                db.Roles.Remove(obj);
                db.SaveChanges();
            }
        }
        #endregion

        #region данные типа Function
        //список функций
        public List<Function> GetAllFunction()
        {
            using (DataEntities db = new DataEntities())
            {
                return db.Functions.ToList();
            }
        }

        //добавить функцию
        public Function InsertFunction(Function obj)
        {
            using (DataEntities db = new DataEntities())
            {
                db.Functions.Add(obj);
                db.SaveChanges();
                return obj;
            }
        }

        //обновить функцию
        public void UpdateFunction(Function obj)
        {
            using (DataEntities db = new DataEntities())
            {
                db.Functions.Attach(obj);
                db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        //удалить функцию
        public void DeleteFunction(Function obj)
        {
            using (DataEntities db = new DataEntities())
            {
                db.Functions.Attach(obj);
                db.Functions.Remove(obj);
                db.SaveChanges();
            }
        }
        #endregion

        #region данные типа FunctionRole
        //список всех закреплённых функций
        public List<FunctionRole> GetAllFunctionRole(Role obj)
        {
            using (DataEntities db = new DataEntities())
            {
                return db.FunctionRoles.Where(r => r.RoleId == obj.Id).ToList();
            }
        }

        //закрепить функцию роли пользователя
        public void AddFunctionRole(Function function, Role role)
        {
            using(DataEntities db = new DataEntities())
            {
                FunctionRole fr = db.FunctionRoles.Where(p => p.FunctionId == function.Id && p.RoleId == role.Id).SingleOrDefault();
                if(fr == null)
                {
                    FunctionRole obj = new FunctionRole() { RoleId = role.Id, FunctionId = function.Id };
                    db.FunctionRoles.Add(obj);
                    db.SaveChanges();
                }
            }
        }

        //открепить функцию роли пользователя
        public void RemoveFunctionRole(FunctionRole obj)
        {
            using(DataEntities db = new DataEntities())
            {
                db.FunctionRoles.Attach(obj);
                db.FunctionRoles.Remove(obj);
                db.SaveChanges();
            }
        }
        #endregion

        #region главное окно
        
        //список элементов меню
        public List<MainMenuItem> GetMenuItem(string login)
        {
            using(DataEntities db = new DataEntities())
            {
                var sql = from ur in db.Users
                          join fr in db.FunctionRoles on ur.RoleId equals fr.RoleId
                          join f in db.Functions on fr.FunctionId equals f.Id
                          where ur.Login == login
                          select new MainMenuItem()
                          {
                              FunctionName = f.FunctionName,
                              FormName = f.FormName
                          };
                return sql.ToList();
            }
        }
        #endregion

        #region сесуриту

        //поменять пароль
        public bool ChangePassword(string newpassword, User user)
        {
            using (DataEntities db = new DataEntities())
            {
                User obj = db.Users.Where(u => u.Login == user.Login).SingleOrDefault();
                if (obj != null)
                {
                    obj.Password = newpassword;
                    db.SaveChanges();
                    return true;
                }
                else return false;
            }
        }

        //хэш
        public string GetHash(string pswd)
        {
            using (var hash = SHA384Cng.Create())
            {
                string sHash = string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(pswd)).Select(x => x.ToString("x2")));
                for(int i = 0; i < 10; i++)
                {
                    sHash = string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(sHash)).Select(x => x.ToString("x2")));
                }
                return sHash;
            }
        }

        #endregion
    }

}
