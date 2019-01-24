using DataLayer;
using Model;
using System;
using System.Collections.Generic;

namespace ServicesLayer
{
    public class ProjectServices
    {
        static ISynectixProject prjobject;

        //инициализация статического члена класса
        static ProjectServices()
        {
            prjobject = new SynectixProject();
        }

        #region Загрузка источников

        //поиск проекта по номеру
        public static  Project GetProjectById(int id)
        {
            return prjobject.GetById(id);
        }

        //список всех проектов
        public static List<Project> GetAllProject()
        {
            return prjobject.GetAllProject();
        }

        //список идентификаторов проекта
        public static List<ProjectNumber> GetAllProjectNum()
        {
            return prjobject.GetAllProjectNum();
        }

        //список этапов проекта
        public static List<ProjectStage> GetAllProjectStage()
        {
            return prjobject.GetAllProjectStage();
        }

        //список состояний проекта
        public static List<ProjectState> GetAllProjectState()
        {
            return prjobject.GetAllProjectState();
        }

        //поиск этапа проекта по id
        public static ProjectStage GetStageById(int stageId)
        {
            return prjobject.GetStageById(stageId);
        }

        //поиск состояния проекта по id
        public static ProjectState GetStateById(int stateId)
        {
            return prjobject.GetStateById(stateId);
        }

        //список сотрудников
        public static List<User> GetAllEmployees(string role)
        {
            return prjobject.GetAllEmployees(role);
        }

        //текущий пользователь программы
        public static User GetLoggedIn(User user)
        {
            return prjobject.GetLoggedIn(user);
        }

        #endregion

        #region Фильтры при открытии

        //список проектов по последнему статусу
        public static List<Project> GetByStageId(int idStage, int idState)
        {
            return prjobject.GetByStageId(idStage, idState);
        }

        #endregion

        #region Работа с проектом

        //создание идентификатора проекта
        public static int InsertProjectNumber(ProjectNumber projectNumber)
        {
            return prjobject.InsertProjectNumber(projectNumber);
        }

        //получить id-проекта
        public static int GetProjectNumberId(ProjectNumber projectNumber)
        {
            return prjobject.GetProjectNumberId(projectNumber);
        }

        //получить идентификатор (номер) проекта
        public static string GetProjectNumber(Project project)
        {
            return prjobject.GetProjectNumber(project);
        }

        //создание проекта
        public static void Create(Project project, int projectId, int idmanager)
        {
            prjobject.Create(project, projectId, idmanager);
        }

        //фильтрация списка проектов
        public static List<Project> GetAllProject(int idNumber, int idState, int idManager, int idImplementer, string dateFrom, string dateTo, int idStage)
        {
            return prjobject.GetAllProject(idNumber, idState, idManager, idImplementer, dateFrom, dateTo, idStage);
        }

        //добавление ТКП в проект
        public static bool AddTCO(Project project, User implementer, int idStage)
        {
            return prjobject.AddTCO(project, implementer, idStage);
        }

        //редактирование проекта
        public static bool Edit(Project project, User user)
        {
            return prjobject.Edit(project, user);
        }

        //заморозить/разморозить проект
        public static bool FreezeWarm(Project project, User user, int idState)
        {
            return prjobject.FreezeWarm(project, user, idState);
        }

        //список изменений проекта (история)
        public static List<Project> GetProjectHistory(Project project)
        {
            return prjobject.GetProjectHistory(project);
        }

        //описание изменений проекта на данном этапе
        public static string GetProjectNote(Project project)
        {
            return prjobject.GetProjectNote(project);
        }

        //получить проект по его идентификатору (номеру проекта)
        public static Project GetByNumber(string projectNumber)
        {
            return prjobject.GetByNumber(projectNumber);
        }

        #endregion

    }
}
