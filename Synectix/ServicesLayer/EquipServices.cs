using DataLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer
{
    public static class EquipServices
    {
        static ISynectixEquipment equipobj;

        //инициализация статического члена класса
        static EquipServices()
        {
            equipobj = new SynectixEquipment();
        }

        #region /*  Выключатели  */

        #region загрузка источников
        //список выключателей
        public static List<CurrentBreaker> GetAllCbr()
        {
            return equipobj.GetAllCbr();
        }

        //список производителей
        public static List<Manufacturer> GetAllManuf()
        {
            return equipobj.GetAllManuf();
        }

        //список ном.токов выключателей
        public static List<CbCurrent> GetAllCbCur()
        {
            return equipobj.GetAllCbCur();
        }

        //список ном.токов расцепителей
        public static List<DisCurrent> GetAllDisCur()
        {
            return equipobj.GetAllDisCur();
        }

        //список моделей расцепителей
        public static List<DisModel> GetAllDisModel()
        {
            return equipobj.GetAllDisModel();
        }

        //список типов расцепителей
        public static List<DisType> GetAllDisType()
        {
            return equipobj.GetAllDisType();
        }

        //список значенией отключающей способности
        public static List<IcuValue> GetAllIcu()
        {
            return equipobj.GetAllIcu();
        }

        //список буквенных обозначений отключающей способности
        public static List<IcuLiteral> GetAllIcuLiteral()
        {
            return equipobj.GetAllIcuLiteral();
        }

        //список серий выключателей
        public static  List<Seria> GetAllSeria()
        {
            return equipobj.GetAllSeria();
        }

        //список полюсов
        public static List<PoleNumber> GetAllPoleNumber()
        {
            return equipobj.GetAllPoleNumber();
        }

        //список рабочих напряжений
        public static List<Voltage> GetAllVoltage()
        {
            return equipobj.GetAllVoltage();
        }

        #endregion

        #region Выбор автоматических выключателей

        //поиск основных
        public static List<CurrentBreaker> GetCbrByParams(object[] filters)
        {
            return equipobj.GetCbrByParams(filters);
        }

        #endregion

        #region Взаимная фильтрация выпадающих списков

        //фильтрация тока расцепителя по производителю
        public static List<DisCurrent> GetAllDisCur(int idManufacturer)
        {
            return equipobj.GetAllDisCur(idManufacturer);
        }

        //фильтрация тока выключателя по току расцепителя
        public static List<CbCurrent> GetAllCbCur(int idDisCurrent)
        {
            return equipobj.GetAllCbCur(idDisCurrent);
        }

        //фильтрация отк.способности по току выключателя
        public static List<IcuValue> GetAllIcu(int idCbCurrent)
        {
            return equipobj.GetAllIcu(idCbCurrent);
        }

        //фильтрация типа расцепителя по току расцепителя
        public static List<DisType> GetAllDisType(int idDisCurrent)
        {
            return equipobj.GetAllDisType(idDisCurrent);
        }

        //фильтрация моделей расцепителя по производителю и типу
        public static List<DisModel> GetAllDisModel(int idManufacturer, int idDisType)
        {
            return equipobj.GetAllDisModel(idManufacturer, idDisType);
        }

        //фильтрация моделей расцепителя по производителю
        public static List<DisModel> GetAllDisModel(int idManufacturer)
        {
            return equipobj.GetAllDisModel(idManufacturer);
        }

        #endregion

        #region Работа с проектом
 
        //подбор аналогов 2.0
        public static bool GetCbrAnalog(ProjectEquipment pe, CurrentBreaker cbr)
        {
            return equipobj.GetCbrAnalog(pe, cbr);
        }

        #endregion

        #region Вспомогательные методы

        //список выключателей по id
        public static List<CurrentBreaker> GetById(int[] idArray)
        {
            return equipobj.GetCbrById(idArray);
        }

        //поиск выключателя по id
        public static CurrentBreaker GetById(int id)
        {
            return equipobj.GetById(id);
        }

        #endregion

        #region В проекте

        //добавить выключатель в проект
        public static ProjectEquipment AttachCbr(Project project, CurrentBreaker cbr, string connectionNumber)
        {
            return equipobj.AttachCbr(project, cbr, connectionNumber);
        }

        //список выключателей в проекте
        public static List<CurrentBreaker> GetProjectCbr(Project project, bool analog)
        {
            return equipobj.GetProjectCbr(project, analog);
        }

        //список записей ProjectEquipment (CurrentBreaker)
        public static List<ProjectEquipment> GetAllEquipCbr()
        {
            return equipobj.GetAllEquipCbr(); //всех
        }
        public static List<ProjectEquipment> GetAllEquipCbr(Project project, bool analog)
        {
            return equipobj.GetAllEquipCbr(project, analog); //базовых или аналоговых
        }

        #endregion

        #endregion

        #region /*  Контакторы  */

        #region Загрузка источников

        //список мощностей двигателя
        public static List<NumericParam> GetAllMotorPow()
        {
            return equipobj.GetAllMotorPow();
        }

        //список токов двигателя
        public static List<NumericParam> GetAllMotorCur()
        {
            return equipobj.GetAllMotorCur();
        }

        //список номинальных токов контактора
        public static List<NumericParam> GetAllContCur()
        {
            return equipobj.GetAllContCur();
        }

        //список контакторов
        public static List<Contactor> GetAllContactor()
        {
            return equipobj.GetAllContactor();
        }

        //наличие теплового реле
        public static List<StringParam> GetHasRealy()
        {
            return equipobj.GetHasRelay();
        }

        //тип координации
        public static List<StringParam> GetCoordType()
        {
            return equipobj.GetCoordType();
        }

        //ток управления
        public static List<StringParam> GetCoilType()
        {
            return equipobj.GetCoilType();
        }

        #endregion

        //выбор контакторов
        public static List<Contactor> GetContByParams(object[] filters)
        {
            return equipobj.GetContByParams(filters);
        }

        #region В проекте

        //добавить контактор в проект
        public static ProjectEquipment AttachContactor(Project project, Contactor cont, string note)
        {
            return equipobj.AttachContactor(project, cont, note);
        }

        //список контакторов в проекте
        public static List<Contactor> GetProjectCont(Project project)
        {
            return equipobj.GetProjectCont(project);
        }

        //список контакторов в проекте
        public static List<ProjectCnt> GetAllProjectCont(Project project, bool analog)
        {
            return equipobj.GetAllProjectCont(project, analog);
        }

        #endregion

        #endregion

        #region Общее

        //обновить таблицу оборудования
        public static List<EquipNote> UpdateTable(ProjectEquipment pe, string newText)
        {
            return equipobj.UpdateTable(pe, newText);
        }

        //открепить оборудование от проекта
        public static List<ProjectEquipment> DisattachBase(ProjectEquipment pe, Project project)
        {
            return equipobj.DisattachBase(pe, project);
        }

        //открепить аналоги оборудования от проекта
        public static List<ProjectEquipment> DisattachAnalog(ProjectEquipment pe, Project project, bool justAnalog)
        {
            return equipobj.DisattachAnalog(pe, project, justAnalog);
        }

        //список временных данных
        public static List<ProjectEquipment> GetAllTempEquip()
        {
            return equipobj.GetAllTempEquip();
        }

        //удаление временных данных 2.0
        public static void RemoveTemp(List<ProjectEquipment> tempPrEqList)
        {
            equipobj.RemoveTemp(tempPrEqList);
        }

        //список всех обозначений
        public static List<EquipNote> GetAllProjectNote()
        {
            return equipobj.GetAllProjectNote();
        }

        //id-выключателя в базе по номеру
        public static int GetCbrId(Project project, string connectionNumber)
        {
            return equipobj.GetCbrId(project, connectionNumber);
        }

        //проверить повторяющиеся наименования присоединений
        public static  bool CheckDuplicate(Project project, string connectionNumber)
        {
            return equipobj.CheckDuplicate(project, connectionNumber);
        }

        //замена выключателя в проекте
        public static ProjectEquipment ReplaceProjectCbr(Project project, string connectionNumber, CurrentBreaker newCbr)
        {
            return equipobj.ReplaceProjectCbr(project, connectionNumber, newCbr);
        }

        //проверка наличия сконфигурированных блоков
        public static bool HasAnyBlocks(Project project)
        {
            return equipobj.HasAnyBlocks(project);
        }
        #endregion
    }
}
