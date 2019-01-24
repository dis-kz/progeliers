using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataLayer
{
    public interface ISynectixConfigurator
    {
        List<ProjectCbr> GetProjectCbr(Project project, bool analog);
        List<ProjectCtr> GetBindedCurTrans(ProjectCbr peCbr);
        ProjectCnt GetBindedCont(ProjectCbr peCbr);
        List<BlockEquipment> GetAllBlockEquip(int idBlock);

        string GetManufLiter(ProjectCbr peCbr);
        string GetCbrTitle(ProjectCbr peCbr);
        string GetCtrTitile(ProjectCtr peCtr);
        string GetCntTitle(ProjectCnt peCnt);

        List<Schema> GetAllSchema();
        List<VerticalSize> GetAllVertSizes(ProjectCbr cbr, Schema sch);
        List<BaseSize> GetBaseSizes(string attribute);
        int BlockCount(Project project);
        int InsertBlock(string title, string functional, int[] parameters, List<BlockEquipment> blockEquips );
    }

    public class VerticalSize
    {
        public int Id { get; set; }
        public string SizeName { get; set; }
    }
}
