using DataLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer
{
    public class ConfigServices
    {
        static ISynectixConfigurator confobject;

        //инициализация статического члена класса
        static ConfigServices()
        {
            confobject = new SynectixConfigurator();
        }

        #region Обозначения
        //получить обозначение выключателя
        public static string GetCbrTitle(ProjectCbr cbr)
        {
            return confobject.GetCbrTitle(cbr);
        }

        //получить обозначение трансформатора тока
        public static string GetCtrTitile(ProjectCtr peCtr)
        {
            return confobject.GetCtrTitile(peCtr);
        }

        //получить обозначение контактора
        public static string GetCntTitle(ProjectCnt peCnt)
        {
            return confobject.GetCntTitle(peCnt);
        }

        //код производителя
        public static string GetManufLiter(ProjectCbr cbr)
        {
            return confobject.GetManufLiter(cbr);
        }
        #endregion

        #region Загрузка источников
        //список схем
        public static List<Schema> GetAllSchema()
        {
            return confobject.GetAllSchema();
        }

        //список размеров
        public static List<VerticalSize> GetAllVertSizes(ProjectCbr cbr, Schema sch)
        {
            return confobject.GetAllVertSizes(cbr, sch);
        }

        //базовые размеры
        public static List<BaseSize> GetBaseSizes(string attribute)
        {
            return confobject.GetBaseSizes(attribute);
        }

        //количество блоков в проекте
        public static int BlockCount(Project project)
        {
            return confobject.BlockCount(project);
        }
        #endregion

        //добавить блок в проект
        public static int InsertBlock(string title, string functional, int[] parameters, List<BlockEquipment> blockEquips)
        {
            return confobject.InsertBlock(title, functional, parameters, blockEquips);
        }

        //список выключателей в проекте
        public static List<ProjectCbr> GetProjectCbr(Project project, bool analog)
        {
            return confobject.GetProjectCbr(project, analog);
        }

        //получить связанный трансформатор тока
        public static List<ProjectCtr> GetBindedCurTrans(ProjectCbr peCbr)
        {
            return confobject.GetBindedCurTrans(peCbr);
        }

        //получить связанный контактор
        public static ProjectCnt GetBindedCont(ProjectCbr peCbr)
        {
            return confobject.GetBindedCont(peCbr);
        }

        //список оборудования в конкретном блоке
        public static List<BlockEquipment> GetAllBlockEquip(int idBlock)
        {
            return confobject.GetAllBlockEquip(idBlock);
        }
    }
}
