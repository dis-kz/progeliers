using Model;
using System;
using System.Collections.Generic;

namespace DataLayer
{
    public interface ISynectixProject
    {
        //проекты
        List<Project> GetAllProject();
        List<Project> GetAllProject(int numberId, int idState, int idManager, int idImplementer, string dateFrom, string dateTo, int idStage);
        List<Project> GetProjectHistory(Project project);
        List<ProjectNumber> GetAllProjectNum();

        int InsertProjectNumber(ProjectNumber projectNumber);
        int GetProjectNumberId(ProjectNumber projectNumber);
        string GetProjectNumber(Project project);

        void Create(Project project, int idNumber, int idmanager);
        Project GetById(int id);

        Project GetByNumber(string projectNumber);
        
        bool Edit(Project project, User user);
        bool AddTCO(Project project, User implementer, int idStage);

        //фильтры при открытии
        List<Project> GetByStageId(int idStage, int idState);

        //свойства проектов
        List<ProjectStage> GetAllProjectStage();
        List<ProjectState> GetAllProjectState();
        ProjectStage GetStageById(int stageId);
        ProjectState GetStateById(int stateId);
        bool FreezeWarm(Project project, User user, int idState);
        string GetProjectNote(Project project);

        //авторы и исполнители проектов
        List<User> GetAllEmployees(string role);
        User GetLoggedIn(User user);

    }
}
