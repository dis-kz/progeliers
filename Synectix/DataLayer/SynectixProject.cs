using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataLayer
{
    public class SynectixProject : ISynectixProject
    {
        string subString = "";
        string fitlerToLoad = @"SELECT Project.Id,Project.IdNumber,Project.Description,Project.Note,
                               Project.IdManager,Project.IdImplementer,Project.IdEditor,
                               Project.Version,Project.Date,Project.IdState,Project.IdStage
                               FROM (SELECT MAX(Project.Date) AS Date,Project.IdNumber AS Number
                                     FROM synectix.dbo.Project Project
                                     GROUP BY Project.IdNumber) SubQuery1
                               LEFT OUTER JOIN synectix.dbo.Project Project
                               ON SubQuery1.Number = Project.IdNumber
                                  AND SubQuery1.Date = Project.Date
                               WHERE ";

        #region Загрузка источников
        //поиск проекта по номеру
        public Project GetById(int id)
        {
            using (DataEntities db = new DataEntities())
            {
                var sql = (from prct in db.Projects
                          where prct.Id == id
                          select prct).SingleOrDefault();
                return sql;
            }       
        }

        //список проектов
        public List<Project> GetAllProject()
        {
            using (DataEntities db = new DataEntities())
            {
                var sql = from pr in db.Projects
                          group pr by pr.IdNumber into g
                          select g.OrderByDescending(t=>t.Date).FirstOrDefault();

                return sql.ToList();
            }
        }

        //список идентификаторов проекта
        public List<ProjectNumber> GetAllProjectNum()
        {
            using (DataEntities db = new DataEntities())
            {
                return db.ProjectNumbers.ToList();
            }
        }

        //список этапов проекта
        public List<ProjectStage> GetAllProjectStage()
        {
            using (DataEntities db = new DataEntities())
            {
                return db.ProjectStages.ToList();
            }
        }

        //список состояний проекта
        public List<ProjectState> GetAllProjectState()
        {
            using (DataEntities db = new DataEntities())
            {
                return db.ProjectStates.ToList();
            }
        }

        //поиск этапа проекта по id
        public ProjectStage GetStageById(int stageId)
        {
            using(DataEntities db = new DataEntities())
            {
                var sql = (from pstg in db.ProjectStages
                          where pstg.Id == stageId
                           select pstg).SingleOrDefault();

                return sql;
            }
        }

        //поиск состояния проекта по id
        public ProjectState GetStateById(int stateId)
        {
            using (DataEntities db = new DataEntities())
            {
                var sql = (from pst in db.ProjectStates
                           where pst.Id == stateId
                           select pst).SingleOrDefault();

                return sql;
            }
        }

        //список сотрудников по ролям (должностям)
        public List<User> GetAllEmployees(string role)
        {
            using (DataEntities db = new DataEntities())
            {
                var sql = from ur in db.Users
                          join r in db.Roles on ur.RoleId equals r.Id
                          where r.RoleName == role
                          select ur;
                return sql.ToList();
            }

        }

        //текущий пользователь программы
        public User GetLoggedIn(User user)
        {
            using (DataEntities db = new DataEntities())
            {
                var sql = (from ur in db.Users
                           where ur.Id == user.Id
                           select ur).SingleOrDefault();

                return sql;
            }
        }
        #endregion

        #region Фильтры при открытии

        //список проектов по последнему статутсу
        public List<Project> GetByStageId(int idStage, int idState)
        {
            using (DataEntities db = new DataEntities())
            {
                if(idState != 0)
                {
                    if(idStage != 0)
                    {
                        subString = "Project.IdStage = " + idStage.ToString();
                        subString += " AND Project.IdState = " + idState.ToString();
                    }
                    else
                        subString += "Project.IdState = " + idState.ToString();
                }

                var query = db.Projects.SqlQuery(fitlerToLoad + subString);

                subString = "";
                return query.ToList();
            }
        }

        #endregion

        #region Работа с проектом

        //создание идентификатора проекта
        public int InsertProjectNumber(ProjectNumber projectNumber)
        {
            using(DataEntities db = new DataEntities())
            {
                var check = (from prmnb in db.ProjectNumbers
                             where prmnb.Number == projectNumber.Number
                             select prmnb).SingleOrDefault();

                if(check == null)
                {
                    db.ProjectNumbers.Add(projectNumber);
                    db.SaveChanges();

                    var id = (from prnmb in db.ProjectNumbers
                              where prnmb.Number == projectNumber.Number
                              select prnmb.Id).SingleOrDefault();

                    return id;
                }
                else
                    return 0;
            }
        }

        //получить id-проекта
        public int GetProjectNumberId(ProjectNumber projectNumber)
        {
            using(DataEntities db = new DataEntities())
            {
                var result = (from prid in db.ProjectNumbers
                                     where prid.Number == projectNumber.Number
                                     select prid).SingleOrDefault();
                if (result == null)
                    return 0;
                else
                    return result.Id;
            }
        }

        //получить идентификатор (номер) проекта
        public string GetProjectNumber(Project project)
        {
            using(DataEntities db = new DataEntities())
            {
                var result = (from prnmb in db.ProjectNumbers
                           where prnmb.Id == project.IdNumber
                           select prnmb.Number).SingleOrDefault();
                return result;
            }
        }

        //создание проекта
        public void Create(Project project, int projectId, int idManager)
        {
            using (DataEntities db = new DataEntities())
            {
                //при создании проекта:
                // - записать Identifier проекта
                // - указать менеджера проекта,
                // - установить начальное значение версии,
                // - зафиксировать дату создания,
                // - установить стадию проекта = (инициализация)

                project.IdNumber = projectId;
                project.IdManager = idManager;
                project.Version = 1;
                project.Date = DateTime.Now;
                project.IdState = 1;
                project.IdStage = 1;

                db.Projects.Add(project);
                db.SaveChanges();
            }
        }

        //фильтрация списка проектов
        public List<Project> GetAllProject(int idNumber, int idState, int idManager, int idImplementer, string dateFrom, string dateTo, int idStage)
        {
            object[] parameters = new object[7];
            //string sqlQuery = @"SELECT * FROM Project WHERE ";
            string sqlQuery = @"SELECT Project.Id,Project.IdNumber,Project.Description,Project.Note,
                               Project.IdManager,Project.IdImplementer,Project.IdEditor,
                               Project.Version,Project.Date,Project.IdState,Project.IdStage
                               FROM(SELECT MAX(Project.Date) AS Date, Project.IdNumber AS Number
                                     FROM synectix.dbo.Project Project
                                     GROUP BY Project.IdNumber) SubQuery1
                                LEFT OUTER JOIN synectix.dbo.Project Project
                               ON SubQuery1.Number = Project.IdNumber
                                  AND SubQuery1.Date = Project.Date
                               WHERE ";

            parameters[0] = DateTime.Parse(dateFrom);
            parameters[1] = DateTime.Parse(dateTo);
            string conditions = @"Project.Date BETWEEN {0} AND {1} ";

            #region добавление условий в строку запроса
            if (idNumber != 0)
            {
                parameters[2] = idNumber;
                conditions += @"AND Project.IdNumber = {2} ";
            }

            if(idState != 0)
            {
                parameters[3] = idState;
                conditions += @"AND Project.IdState = {3} ";
            }

            if(idManager != 0)
            {
                parameters[4] = idManager;
                conditions += @"AND Project.IdManager = {4} ";
            }

            if(idImplementer != 0)
            {
                parameters[5] = idImplementer;
                conditions += @"AND Project.IdImplementer = {5} ";
            }

            if (idStage != 0)
            {
                parameters[6] = idStage;
                conditions += @"AND Project.IdStage = {6} ";
            }
            #endregion

            sqlQuery += conditions;

            using(DataEntities db = new DataEntities())
            {
                var query = db.Projects.SqlQuery(sqlQuery, parameters);
                return query.ToList();
            }
        }

        //добавление ТКП в проект
        public bool AddTCO(Project project, User user, int idStage)
        {
            using(DataEntities db = new DataEntities())
            {
                try
                {
                    Project _project = project;

                    _project.IdImplementer = user.Id;
                    _project.IdStage = idStage;
                    _project.Date = DateTime.Now;

                    db.Projects.Add(_project);
                    db.SaveChanges();

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        //редактирование проекта
        public bool Edit(Project project, User user)
        {
            using (DataEntities db = new DataEntities())
            {
                try
                {
                    var lastVersion = (from pr in db.Projects
                                       where pr.IdNumber == project.IdNumber
                                       select pr.Version).Max();

                    Project edited = project;

                    edited.IdEditor = user.Id;
                    edited.Version = (int)++lastVersion;
                    edited.Date = DateTime.Now;

                    db.Projects.Add(edited);
                    db.SaveChanges();

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        //заморозить/разморозить проект
        public bool FreezeWarm(Project project, User user, int idState)
        {
            using(DataEntities db = new DataEntities())
            {
                try
                {
                    Project _project = project;

                    _project.IdEditor = user.Id;
                    _project.IdState = idState;
                    _project.Date = DateTime.Now;

                    db.Projects.Attach(_project);
                    db.Entry(_project).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        //список изменений проекта (история)
        public List<Project> GetProjectHistory(Project project)
        {
            using(DataEntities db = new DataEntities())
            {
                var sql = from pr in db.Projects
                          where pr.IdNumber == project.IdNumber
                          select pr;
                return sql.ToList();
            }
        }

        //описание изменений проекта на данном этапе
        public string GetProjectNote(Project project)
        {
            using(DataEntities db = new DataEntities())
            {
                var result = (from pr in db.Projects
                             where pr.Id == project.Id
                             select pr.Note).SingleOrDefault();

                return result;
            }
        }

        //получить проект по его идентификатору (номеру проекта)
        public Project GetByNumber(string projectNumber)
        {
            using(DataEntities db = new DataEntities())
            {
                var project = (from pr in db.Projects
                               join pn in db.ProjectNumbers on pr.IdNumber equals pn.Id
                               where pn.Number.Equals(projectNumber)
                               select pr).DefaultIfEmpty(null).FirstOrDefault();

                return project;
            }
        }

        #endregion

    }
}
