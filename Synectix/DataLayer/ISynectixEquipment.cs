using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface ISynectixEquipment
    {
        #region /*  Выключатели  */

        //выключатели
        List<CurrentBreaker> GetAllCbr();
        List<CurrentBreaker> GetCbrById(int[] idArray);
        List<CurrentBreaker> GetCbrByParams(object[] filters);
        CurrentBreaker GetById(int id);

        //свойства выключателей
        List<Manufacturer> GetAllManuf();
        List<Seria> GetAllSeria();
        List<IcuLiteral> GetAllIcuLiteral();
        List<PoleNumber> GetAllPoleNumber();
        List<Voltage> GetAllVoltage();
        List<DisCurrent> GetAllDisCur();
        List<DisCurrent> GetAllDisCur(int idManufacturer);
        List<CbCurrent> GetAllCbCur();
        List<CbCurrent> GetAllCbCur(int idDisCurrent);
        List<IcuValue> GetAllIcu();
        List<IcuValue> GetAllIcu(int idCbCurrent);
        List<DisType> GetAllDisType();
        List<DisType> GetAllDisType(int idDisCurrent);
        List<DisModel> GetAllDisModel();
        List<DisModel> GetAllDisModel(int idManufacturer);
        List<DisModel> GetAllDisModel(int idManufacturer, int idDisType);

        //в проекте
        int InsertProjectNote(CurrentBreaker cbr, Project project, string connectionNumber);
        int GetCbrId(Project project, string connectionNumber);
        ProjectEquipment AttachCbr(Project project, CurrentBreaker cbr, string connectionNumber);
        ProjectEquipment ReplaceProjectCbr(Project project, string connectionNumber, CurrentBreaker newCbr);
        List<CurrentBreaker> GetProjectCbr(Project project, bool analog);    
        List<ProjectEquipment> GetAllEquipCbr();
        List<ProjectEquipment> GetAllEquipCbr(Project project, bool analog);
        bool GetCbrAnalog(ProjectEquipment pe, CurrentBreaker cbr);
        bool CheckDuplicate(Project project, string connectionNumber);

        #endregion

        #region /*  Контакторы  */

        List<NumericParam> GetAllMotorPow();
        List<NumericParam> GetAllMotorCur();
        List<NumericParam> GetAllContCur();

        List<StringParam> GetHasRelay();
        List<StringParam> GetCoordType();
        List<StringParam> GetCoilType();

        List<Contactor> GetAllContactor();
        List<Contactor> GetContByParams(object[] filters);

        //оборудование
        ProjectEquipment AttachContactor(Project project, Contactor cont, string note);
        List<Contactor> GetProjectCont(Project project);

        List<ProjectCnt> GetAllProjectCont(Project project, bool analog);

        #endregion

        List<ProjectEquipment> GetAllTempEquip();
        void RemoveTemp(List<ProjectEquipment> tempPrEqList);
        List<EquipNote> GetAllProjectNote();
        List<EquipNote> UpdateTable(ProjectEquipment pe, string newText);
        List<ProjectEquipment> DisattachBase(ProjectEquipment pe, Project project);
        List<ProjectEquipment> DisattachAnalog(ProjectEquipment pe, Project project, bool justAnalog);

        bool HasAnyBlocks(Project project);

    }
}