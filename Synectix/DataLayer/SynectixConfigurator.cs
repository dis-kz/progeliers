using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataLayer
{
    public class SynectixConfigurator : ISynectixConfigurator
    {
        #region Обозначения
        //получить обозначение выключателя
        public string GetCbrTitle(ProjectCbr peCbr)
        {
            using (DataEntities db = new DataEntities())
            {

                string pcbrTitle = (from cbr in db.CurrentBreakers
                                   join sr in db.Serias on cbr.IdSeria equals sr.Id
                                   join cbc in db.CbCurrents on cbr.IdCbCurrent equals cbc.Id
                                   join icl in db.IcuLiterals on cbr.IdIcuLiteral equals icl.Id
                                   join dm in db.DisModels on cbr.IdDisModel equals dm.Id
                                   join dcr in db.DisCurrents on cbr.IdDisCurrent equals dcr.Id
                                   where cbr.Id == peCbr.Id
                                   select new ProjectCbr
                                   {
                                       Title = sr.Name + " " + cbc.Value + icl.Literal + " " +
                                               dm.Name + " " + dcr.Value
                                   }).SingleOrDefault().Title;

                return pcbrTitle;
            }
        }

        //получить обозначение трансформатора тока
        public string GetCtrTitile(ProjectCtr peCtr)
        {
            using(DataEntities db = new DataEntities())
            {
                string pctrTitle = (from ctr in db.CurrentTransforms
                                    join mnf in db.Manufacturers on ctr.IdManufacturer equals mnf.Id
                                    where ctr.Id == peCtr.Id
                                    select new ProjectCtr
                                    {
                                        Title = mnf.Name + " " + ctr.TypeSize + " " + ctr.TransFactor + " " +
                                                ctr.MeasureClass + " " + ctr.Power
                                    }).SingleOrDefault().Title;
                return pctrTitle;
            }
        }

        //получить обозначение контактора
        public string GetCntTitle(ProjectCnt peCnt)
        {
            using(DataEntities db = new DataEntities())
            {
                string pcntTitle = (from cnt in db.Contactors
                                    join mnf in db.Manufacturers on cnt.IdManufacturer equals mnf.Id
                                    join sr in db.Serias on cnt.IdSeria equals sr.Id
                                    where cnt.Id == peCnt.Id
                                    select new ProjectCnt
                                    {
                                        Title = /*mnf.Name + " " + */sr.Name + " " + cnt.ContCatNumber + " + реле " + cnt.RelayCabNumber
                                    }).SingleOrDefault().Title;
                return pcntTitle;
            }
        }

        //код производителя
        public string GetManufLiter(ProjectCbr peCbr)
        {
            using(DataEntities db = new DataEntities())
            {
                string code = (from m in db.Manufacturers
                                  where m.Id == peCbr.IdManufacturer
                                  select m.Literal).SingleOrDefault().ToString();
                return code;
            }
        }
        #endregion

        #region Загрузка для источников
        //список схем
        public List<Schema> GetAllSchema()
        {
            using(DataEntities db = new DataEntities())
            {
                return db.Schemata.ToList();
            }
        }

        //список размеров
        public List<VerticalSize> GetAllVertSizes(ProjectCbr peCbr, Schema sch)
        {
            List<VerticalSize> list = new List<VerticalSize>();

            using (DataEntities db = new DataEntities())
            {
                var sql = from vs in db.VSizes
                          where vs.IdManuf == peCbr.IdManufacturer && vs.IdSeria == peCbr.IdSeria &&
                                vs.IdPoleNumber == peCbr.IdPoleNumber && vs.IdCbrCurrent == peCbr.IdCbCurrent &&
                                vs.IdSchema == sch.Id
                          select vs;

                foreach(VSize v in sql)
                {
                    list.Add(new VerticalSize()
                    {
                        Id = v.Id,
                        SizeName = v.SizeName + v.Fraction
                    });
                }

                return list;
            }
        }

        //базовые размеры
        public List<BaseSize> GetBaseSizes(string attribute)
        {
            using(DataEntities db = new DataEntities())
            {
                var sql = from bs in db.BaseSizes
                          where bs.Attribute == attribute
                          select bs;
                return sql.ToList();
            }
        }

        //количество блоков в проекте
        public int BlockCount(Project project)
        {
            using(DataEntities db = new DataEntities())
            {
                int? pid = null;
                if (project.IdNumber != 0)
                    pid = project.IdNumber;

                int count = (from pb in db.ProjectBlocks
                             where pb.IdProjectNumber == pid
                             select pb).Count();

                return count;
            }
        }
        #endregion

        //добавить блок в проект
        public int InsertBlock(string title, string functional, int[] parameters, List<BlockEquipment> blockEquips)
        {
            using(DataEntities db = new DataEntities())
            {
                try
                {
                    #region Добавление блока
                    //
                    ProjectBlock projectBlock = new ProjectBlock();

                    projectBlock.Title = title;
                    projectBlock.Functional = functional;
                    projectBlock.IdBaseH = parameters[0];
                    projectBlock.IdBaseB = parameters[1];
                    projectBlock.IdVSize = parameters[2];
                    projectBlock.IdSchema = parameters[3];
                    if(parameters[4] != 0)
                        projectBlock.IdProjectNumber = parameters[4];

                    db.ProjectBlocks.Add(projectBlock);
                    db.SaveChanges();
                    //
                    #endregion

                    #region Привязка оборудования к блоку
                    int? bid = db.ProjectBlocks.OrderByDescending(x => x.Id).FirstOrDefault().Id;
                    if(bid != null)
                    {
                        foreach(BlockEquipment beq in blockEquips)
                        {
                            beq.IdBlock = bid;
                            db.BlockEquipments.Add(beq);
                        }
                    }
                    db.SaveChanges();
                    return (int)bid;
                    #endregion

                }
                catch
                {
                    return -1; //ошибка
                }
            }
        }

        //список выключателей в проекте
        public List<ProjectCbr> GetProjectCbr(Project project, bool analog)
        {
            using (DataEntities db = new DataEntities())
            {
                int? pid = null;
                if (project.IdNumber != 0)
                    pid = project.IdNumber;

                var listPrCbr = (from cbr in db.CurrentBreakers
                                 join pe in db.ProjectEquipments on cbr.Id equals pe.IdCbr
                                 join en in db.EquipNotes on pe.IdNote equals en.Id
                                 where pe.IdProjectNumber == pid && pe.Analog == analog
                                 select new ProjectCbr
                                 {
                                     Id = cbr.Id,
                                     IdProjectNumber = pid,
                                     IdProjectEquip = pe.Id,
                                     IdNote = pe.IdNote,
                                     ConNum = en.Text,

                                     IdManufacturer = cbr.IdManufacturer,
                                     IdSeria = cbr.IdSeria,
                                     IdPoleNumber = cbr.IdPoleNumber,
                                     IdCbCurrent = cbr.IdCbCurrent,
                                     IdIcuLiteral = cbr.IdIcuLiteral,
                                     IdDisModel = cbr.IdDisModel,
                                     IdDisCurrent = cbr.IdDisCurrent
                                 }).ToList();

                return listPrCbr;
            }
        }

        //получить связанный трансформатор тока
        public List<ProjectCtr> GetBindedCurTrans(ProjectCbr peCbr)
        {
            using(DataEntities db = new DataEntities())
            {
                var listPrCtr = (from ctr in db.CurrentTransforms
                                 join pe in db.ProjectEquipments on ctr.Id equals pe.IdCtr
                                 join en in db.EquipNotes on pe.IdNote equals en.Id
                                 where pe.IdNote == peCbr.IdNote && pe.IdProjectNumber == peCbr.IdProjectNumber
                                 select new ProjectCtr
                                 {
                                     Id = ctr.Id,
                                     IdProjectNumber = peCbr.IdProjectNumber,
                                     IdProjectEquip = pe.Id,
                                     IdNote = pe.IdNote,
                                     ConNum = en.Text,

                                     IdManufacturer = ctr.IdManufacturer,
                                     TypeSize = ctr.TypeSize,
                                     TransFactor = ctr.TransFactor,
                                     MeasureClass = ctr.MeasureClass,
                                     Power = ctr.Power
                                 }).ToList();

                return listPrCtr;
            }
        }

        //получить связанный контактор
        public ProjectCnt GetBindedCont(ProjectCbr peCbr)
        {
            using(DataEntities db = new DataEntities())
            {
                ProjectCnt prCont = (from cnt in db.Contactors
                                       join pe in db.ProjectEquipments on cnt.Id equals pe.IdCont
                                       join en in db.EquipNotes on pe.IdNote equals en.Id
                                       where pe.IdNote == peCbr.IdNote && pe.IdProjectNumber == peCbr.IdProjectNumber
                                       select new ProjectCnt
                                       {
                                           Id = cnt.Id,
                                           IdProjectNumber = peCbr.IdProjectNumber,
                                           IdProjectEquip = pe.Id,
                                           IdNote = pe.IdNote,
                                           ConNum = en.Text,

                                           IdManufacturer = cnt.IdManufacturer,
                                           IdSeria = cnt.IdSeria,
                                           ContCatNumber = cnt.ContCatNumber,
                                           RelayCabNumber = cnt.RelayCabNumber
                                       }).SingleOrDefault();
                return prCont;

            }
        }

        //список оборудования в конкретном блоке
        public List<BlockEquipment> GetAllBlockEquip(int idBlock)
        {
            using(DataEntities db = new DataEntities())
            {
                return db.BlockEquipments.Where(x => x.IdBlock == idBlock).ToList();
            }
        }
    }
}
