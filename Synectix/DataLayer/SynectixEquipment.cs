using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;


namespace DataLayer
{
    public class SynectixEquipment : ISynectixEquipment
    {
        #region /*  Выключатели  */

        #region Загрузка источников
        //список автоматических выключателей
        public List<CurrentBreaker> GetAllCbr()
        {
            using (DataEntities db = new DataEntities())
            {
                return db.CurrentBreakers.ToList();
            }
        }

        //список производителей
        public List<Manufacturer> GetAllManuf()
        {
            using (DataEntities db = new DataEntities())
            {
                return db.Manufacturers.ToList();
            }
        }

        //список ном.токов выключателей
        public List<CbCurrent> GetAllCbCur()
        {
            using (DataEntities db = new DataEntities())
            {
                return db.CbCurrents.ToList();
            }
        }

        //список ном.токов расцепителей
        public List<DisCurrent> GetAllDisCur()
        {
            using (DataEntities db = new DataEntities())
            {
                return db.DisCurrents.ToList();
            }
        }

        //список моделей расцепителей
        public List<DisModel> GetAllDisModel()
        {
            using (DataEntities db = new DataEntities())
            {
                return db.DisModels.ToList();
            }
        }

        //список типов расцепителей
        public List<DisType> GetAllDisType()
        {
            using (DataEntities db = new DataEntities())
            {
                return db.DisTypes.ToList();
            }
        }

        //список значенией отключающей способности
        public List<IcuValue> GetAllIcu()
        {
            using (DataEntities db = new DataEntities())
            {
                return db.IcuValues.ToList();
            }
        }

        //список буквенных обозначений отключающей способности
        public List<IcuLiteral> GetAllIcuLiteral()
        {
            using (DataEntities db = new DataEntities())
            {
                return db.IcuLiterals.ToList();
            }
        }


        //список серий
        public List<Seria> GetAllSeria()
        {
            using (DataEntities db = new DataEntities())
            {
                return db.Serias.ToList();
            }
        }

        //список полюсов
        public List<PoleNumber> GetAllPoleNumber()
        {
            using (DataEntities db = new DataEntities())
            {
                return db.PoleNumbers.ToList();
            }
        }

        //список значений напряжения
        public List<Voltage> GetAllVoltage()
        {
            using (DataEntities db = new DataEntities())
            {
                return db.Voltages.ToList();
            }
        }

        #endregion

        #region Выбор автоматических выключателей / Подбор аналогов

        //выбор основных
        public List<CurrentBreaker> GetCbrByParams(object[] filters)
        {
            string conditions = "";
            string sql = "";
            string[] cbColumns = { "IdManufacturer", "IdDisCurrent", "IdCbCurrent", "IdIcuValue", "IdDisType", "IdDisModel"};
            bool firstparam = true;

            for(int i=0; i < filters.Length; i++)
            {
                if (filters[i] != null)
                {
                    if (firstparam)
                    {
                        conditions += cbColumns[i] + "=" + filters[i] + " ";
                        firstparam = false;
                    }
                    else
                    {
                        conditions += " AND " + cbColumns[i] + "=" + filters[i] + " ";
                    }
                }
            }

            sql = @"SELECT * FROM CurrentBreaker WHERE ";
            if (conditions != "") sql += conditions + ";";

            using (DataEntities db = new DataEntities())
            {
                if (conditions != "")
                {
                    var query = db.CurrentBreakers.SqlQuery(sql);
                    return query.ToList();
                }
                else
                {
                    return null;
                }
            }
        }

        //подбор аналогов 2.0
        public bool GetCbrAnalog(ProjectEquipment pe, CurrentBreaker cbr)
        {
            using(DataEntities db = new DataEntities())
            {
                var listAnalog = from cban in db.CurrentBreakers
                                 where cban.IdDisCurrent == cbr.IdDisCurrent && cban.IdCbCurrent == cbr.IdCbCurrent
                                    && cban.IdIcuValue == cbr.IdIcuValue && cban.IdDisType == cbr.IdDisType &&
                                       cban.IdPoleNumber == cbr.IdPoleNumber
                                 select cban;

                if (listAnalog.Count() > 1)
                {
                    foreach (CurrentBreaker c in listAnalog)
                    {
                        ProjectEquipment newpe = new ProjectEquipment();

                        if(c.Id != cbr.Id) //исключить текущий выключатель из подбора аналогов
                        {
                            if (pe.IdProjectNumber != null) newpe.IdProjectNumber = pe.IdProjectNumber;
                            newpe.IdCbr = c.Id;
                            newpe.Analog = true;
                            newpe.IdNote = pe.IdNote;

                            db.ProjectEquipments.Add(newpe);
                        }
                    }
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    ProjectEquipment notAnalog = new ProjectEquipment();
                    if (pe.IdProjectNumber != null) notAnalog.IdProjectNumber = pe.IdProjectNumber;
                    notAnalog.IdCbr = 4354; // нет аналога
                    notAnalog.Analog = true;
                    notAnalog.IdNote = pe.IdNote;
                    db.ProjectEquipments.Add(notAnalog);

                    db.SaveChanges();
                    return false;
                }
            }
        }

        #endregion

        #region Взаимная фильтрация выпадающих списков

        //фильтрация тока расцепителя по производителю
        public List<DisCurrent> GetAllDisCur(int idManufacturer)
        {
            using(DataEntities db = new DataEntities())
            {
                var sql = from dc in db.DisCurrents
                          join cdm in db.ManufDisCurrents on dc.Id equals cdm.IdDisCurrent
                          join mnf in db.Manufacturers on cdm.IdManufacturer equals mnf.Id
                          where mnf.Id == idManufacturer
                          select dc;
                return sql.ToList();
            }
        }

        //фильтрация тока выключателя по току расцепителя
        public List<CbCurrent> GetAllCbCur(int idDisCurrent)
        {
            using (DataEntities db = new DataEntities())
            {
                var sql = from cb in db.CbCurrents                                     //исходная таблица
                          join cdc in db.DisCurrentCbs on cb.Id equals cdc.IdCbCurrent //отфильтровать по значению в промежуточной таблице
                          join dc in db.DisCurrents on cdc.IdDisCurrent equals dc.Id   //отфильтровать по значению связанной таблицы
                          where dc.Id == idDisCurrent                                  //условие
                          select cb;
                return sql.ToList();
            }
        }

        //фильтрация отк.способности по току выключателя
        public List<IcuValue> GetAllIcu(int idCbCurrent)
        {
            using (DataEntities db = new DataEntities())
            {
                var sql = from ic in db.IcuValues                                      
                          join cci in db.CbCurrentIcus on ic.Id equals cci.IdIcuValue  
                          join cb in db.CbCurrents on cci.IdCbCurrent equals cb.Id     
                          where cb.Id == idCbCurrent                                   
                          select ic;
                return sql.ToList();
            }
        }

        //фильтрация типа расцепителя по току расцепителя
        public List<DisType> GetAllDisType(int idDisCurrent)
        {
            using (DataEntities db = new DataEntities())
            {
                var sql = from dt in db.DisTypes                                        
                          join dct in db.DisCurrentTypes on dt.Id equals dct.IdDisType  
                          join dc in db.DisCurrents on dct.IdDisCurrent equals dc.Id    
                          where dc.Id == idDisCurrent                                   
                          select dt;
                return sql.ToList();
            }
        }

        //фильтрация моделей расцепителя по производителю и типу
        public List<DisModel> GetAllDisModel(int idManufacturer, int idDisType)
        {
            using (DataEntities db = new DataEntities())
            {
                var sql = from dm in db.DisModels                                       
                          join dtm in db.DisTypeModels on dm.Id equals dtm.IdDisModel   
                          join dt in db.DisTypes on dtm.IdDisType equals dt.Id          
                          join mn in db.Manufacturers on dtm.IdManufacturer equals mn.Id
                          where dt.Id == idDisType && mn.Id == idManufacturer           
                          select dm;
                return sql.ToList();
            }
        }


        //фильтрация моделей расцепителя по производителю
        public List<DisModel> GetAllDisModel(int idManufacturer)
        {
            using (DataEntities db = new DataEntities())
            {
                var sql = from dm in db.DisModels                                        
                          join dtm in db.DisTypeModels on dm.Id equals dtm.IdDisModel    
                          join mn in db.Manufacturers on dtm.IdManufacturer equals mn.Id 
                          where mn.Id == idManufacturer                                  
                          select dm;
                return sql.ToList();
            }
        }
        #endregion

        #region Вспомогательные методы

        //список выключателей по Id
        public List<CurrentBreaker> GetCbrById(int[] idArray)
        {
            using (DataEntities db = new DataEntities())
            {
                var sql = from cb in db.CurrentBreakers
                          where (idArray.Contains(cb.Id))
                          select cb;
                return sql.ToList();
            }
        }

        //поиск выключателя по Id
        public CurrentBreaker GetById(int id)
        {
            using (DataEntities db = new DataEntities())
            {
                var sql = (from cb in db.CurrentBreakers
                           where cb.Id == id
                           select cb).SingleOrDefault();
                return sql;
            }
        }

        #endregion

        #region В проекте

        //создать новое "наименование присоединения"
        public int InsertProjectNote(CurrentBreaker cbr, Project project, string connectionNumber)
        {
            using(DataEntities db = new DataEntities())
            {
                EquipNote pn = new EquipNote();
                pn.Text = connectionNumber;
                if (project != null) pn.IdProjectNumber = project.IdNumber;

                db.EquipNotes.Add(pn);
                db.SaveChanges();

                return pn.Id;
            }
        }

        //добавить выключатель в проект
        public ProjectEquipment AttachCbr(Project project, CurrentBreaker cbr, string connectionNumber)
        {
            using (DataEntities db = new DataEntities())
            {
                ProjectEquipment pe = new ProjectEquipment();

                if (project.IdNumber != 0)
                {
                    pe.IdProjectNumber = project.IdNumber;
                    pe.IdNote = InsertProjectNote(cbr, project, connectionNumber);
                }
                else
                {
                    pe.IdNote = InsertProjectNote(cbr, null, connectionNumber);
                }
                pe.IdCbr = cbr.Id;
                pe.Analog = false;

                db.ProjectEquipments.Add(pe);
                db.SaveChanges();

                return pe;
            }
        }

        //список выключателей в проекте
        public List<CurrentBreaker> GetProjectCbr(Project project, bool analog)
        {
            using (DataEntities db = new DataEntities())
            {
                /*работа с проектом*/
                if (project.IdNumber != 0)
                {
                    var inProject = from cbr in db.CurrentBreakers
                                    join pe in db.ProjectEquipments on cbr.Id equals pe.IdCbr
                                    join pcn in db.ProjectNumbers on pe.IdProjectNumber equals pcn.Id
                                    where pcn.Id == project.IdNumber && pe.Analog == analog
                                    select cbr;

                    return inProject.ToList();
                }
                /*подборка оборудования без привязки к проекту*/
                else
                {
                    var notInProject = from cbr in db.CurrentBreakers
                                       join pe in db.ProjectEquipments on cbr.Id equals pe.IdCbr
                                       where pe.IdProjectNumber == null && pe.Analog == analog
                                       select cbr;

                    return notInProject.ToList();
                }

            }
        }

        //список записей ProjectEquipment (CurrentBreaker)
        public List<ProjectEquipment> GetAllEquipCbr()
        {
            using (DataEntities db = new DataEntities()) //всех
            {
                var sql = from pe in db.ProjectEquipments
                          where pe.IdCont == null && pe.IdCtr == null && pe.IdModulEq == null
                          select pe;

                return sql.ToList();
            }
        }
        public List<ProjectEquipment> GetAllEquipCbr(Project project, bool analog)
        {
            using(DataEntities db = new DataEntities()) //базовых или аналоговых
            {
                if(project.IdNumber != 0)
                {
                    var inProject = from pe in db.ProjectEquipments
                              where pe.IdProjectNumber == project.IdNumber && pe.Analog == analog && pe.IdCont == null && pe.IdCtr == null && pe.IdModulEq == null
                              select pe;

                    return inProject.ToList();
                }
                else
                {
                    var notInProject = from pe in db.ProjectEquipments
                                       where pe.IdProjectNumber == null && pe.Analog == analog && pe.IdCont == null && pe.IdCtr == null && pe.IdModulEq == null
                                       select pe;

                    return notInProject.ToList();
                }

            }
        }

        #endregion

        #endregion

        #region /*  Контакторы  */

        #region Загрузка источников
        //список мощностей двигателя
        public List<NumericParam> GetAllMotorPow()
        {
            using (DataEntities db = new DataEntities())
            {
                var result = (from np in db.NumericParams
                              join cnt in db.Contactors on np.Id equals cnt.IdMotorPow
                              select np).Distinct(); // Distinct - извлечь уникальные (неповторяющиеся) значения

                return result.ToList();
            }
        }

        //список токов двигателя
        public List<NumericParam> GetAllMotorCur()
        {
            using (DataEntities db = new DataEntities())
            {
                var result = (from np in db.NumericParams
                              join cnt in db.Contactors on np.Id equals cnt.IdMotorCur
                              select np).Distinct();

                return result.ToList();
            }
        }

        //список номинальных токов контактора
        public List<NumericParam> GetAllContCur()
        {
            using (DataEntities db = new DataEntities())
            {
                var result = (from np in db.NumericParams
                              join cnt in db.Contactors on np.Id equals cnt.IdContCur
                              select np).Distinct();

                return result.ToList();
            }
        }

        //список контакторов
        public List<Contactor> GetAllContactor()
        {
            using (DataEntities db = new DataEntities())
            {
                return db.Contactors.ToList();
            }
        }

        //наличие теплового реле
        public List<StringParam> GetHasRelay()
        {
            using (DataEntities db = new DataEntities())
            {
                var result = (from np in db.StringParams
                              join cnt in db.Contactors on np.Id equals cnt.IdHasRelay
                              select np).Distinct();

                return result.ToList();
            }
        }

        //тип координации
        public List<StringParam> GetCoordType()
        {
            using (DataEntities db = new DataEntities())
            {
                var result = (from np in db.StringParams
                              join cnt in db.Contactors on np.Id equals cnt.IdTypeCord
                              select np).Distinct();

                return result.ToList();
            }
        }

        //ток управления
        public List<StringParam> GetCoilType()
        {
            using (DataEntities db = new DataEntities())
            {
                var result = (from np in db.StringParams
                              join cnt in db.Contactors on np.Id equals cnt.IdTypeCoilCur
                              select np).Distinct();

                return result.ToList();
            }
        }

        #endregion

        #region Поиск по критериям

        //выбор контакторов
        public List<Contactor> GetContByParams(object[] filters)
        {
            string conditions = "";
            string sql = "";
            string[] cbColumns = { "IdMotorPow", "IdHasRelay", "IdTypeCord", "IdTypeCoilCur", "IdContCur" };
            bool firstparam = true;

            for (int i = 0; i < filters.Length; i++)
            {
                if (filters[i] != null)
                {
                    if (firstparam)
                    {
                        conditions += cbColumns[i] + "=" + filters[i] + " ";
                        firstparam = false;
                    }
                    else
                    {
                        conditions += " AND " + cbColumns[i] + "=" + filters[i] + " ";
                    }
                }
            }

            sql = @"SELECT * FROM Contactor WHERE ";
            if (conditions != "") sql += conditions + ";";

            using (DataEntities db = new DataEntities())
            {
                if (conditions != "")
                {
                    var query = db.Contactors.SqlQuery(sql);
                    return query.ToList();
                }
                else
                {
                    return null;
                }
            }
        }

        #endregion

        #region В проекте

        //добавить контактор в проект
        public ProjectEquipment AttachContactor(Project project, Contactor cont, string note)
        {
            using (DataEntities db = new DataEntities())
            {
                ProjectEquipment pe = new ProjectEquipment();

                if (project.IdNumber != 0) pe.IdProjectNumber = project.IdNumber;
                pe.IdCont = cont.Id;
                pe.Analog = false;

                db.ProjectEquipments.Add(pe);
                db.SaveChanges();

                return pe;
            }
        }

        //список контакторов в проекте
        public List<Contactor> GetProjectCont(Project project)
        {
            using (DataEntities db = new DataEntities())
            {
                /*работа с проектом*/
                if (project.IdNumber != 0)
                {
                    var inProject = from cont in db.Contactors
                                    join pe in db.ProjectEquipments on cont.Id equals pe.IdCont
                                    join pcn in db.ProjectNumbers on pe.IdProjectNumber equals pcn.Id
                                    where pcn.Id == project.IdNumber
                                    select cont;

                    return inProject.ToList();
                }
                /*подборка оборудования без привязки к проекту*/
                else
                {
                    var notInProject = from cbr in db.Contactors
                                       join pe in db.ProjectEquipments on cbr.Id equals pe.IdCont
                                       where pe.IdProjectNumber == null
                                       select cbr;

                    return notInProject.ToList();
                }

            }
        }

        //список контакторов в проекте
        public List<ProjectCnt> GetAllProjectCont(Project project, bool analog)
        {
            using (DataEntities db = new DataEntities())
            {
                int? pid = null;
                if (project.IdNumber != 0)
                    pid = project.IdNumber;

                var listPrCnt = (from cnt in db.Contactors
                                 join pe in db.ProjectEquipments on cnt.Id equals pe.IdCbr
                                 join en in db.EquipNotes on pe.IdNote equals en.Id
                                 where pe.IdProjectNumber == pid && pe.Analog == analog
                                 select new ProjectCnt
                                 {
                                     Id = cnt.Id,
                                     IdProjectNumber = pid,
                                     IdProjectEquip = pe.Id,
                                     IdNote = pe.IdNote,
                                     ConNum = en.Text,

                                     IdManufacturer = cnt.IdManufacturer,
                                     IdSeria = cnt.IdSeria,
                                     IdContCur = cnt.IdContCur,
                                     IdTypeCord = cnt.IdTypeCord,
                                     IdTypeCoilCur = cnt.IdTypeCoilCur,
                                     ContCatNumber = cnt.ContCatNumber
                                 }).ToList();

                return listPrCnt;
            }
        }

        #endregion

        #endregion

        #region Общее
        //обновить таблицу обозначений оборудования
        public List<EquipNote> UpdateTable(ProjectEquipment pe, string newText)
        {
            using(DataEntities db = new DataEntities())
            {
                EquipNote note = (from pn in db.EquipNotes
                                  where pn.Id == pe.IdNote
                                    select pn).SingleOrDefault();
                note.Text = newText;

                db.EquipNotes.Attach(note);
                db.Entry(note).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return db.EquipNotes.ToList();
            }
        }

        //открепить основное оборудование от проекта
        public List<ProjectEquipment> DisattachBase(ProjectEquipment pe, Project project)
        {
            using (DataEntities db = new DataEntities())
            {
                var notes = from pn in db.EquipNotes
                            where pn.Id == pe.IdNote
                                   select pn;
                foreach(EquipNote note in notes)
                {
                    db.EquipNotes.Attach(note);
                    db.EquipNotes.Remove(note);
                }

                db.ProjectEquipments.Attach(pe);
                db.ProjectEquipments.Remove(pe);
                db.SaveChanges();

                return GetAllEquipCbr(project, false);
            }
        }

        //открепить аналоги оборудования от проекта
        public List<ProjectEquipment> DisattachAnalog(ProjectEquipment pe, Project project, bool justAnalog)
        {
            using (DataEntities db = new DataEntities())
            {
                if (!justAnalog)
                {
                    var sql = from pean in db.ProjectEquipments
                              where pean.IdNote == pe.IdNote && pean.Analog == true
                              select pean;
                    if (sql != null)
                    {
                        foreach (ProjectEquipment peq in sql)
                        {
                            db.ProjectEquipments.Attach(peq);
                            db.ProjectEquipments.Remove(peq);
                        }
                    }
                }
                else
                {
                    db.ProjectEquipments.Attach(pe);
                    db.ProjectEquipments.Remove(pe);
                }

                db.SaveChanges();

                return GetAllEquipCbr(project, true);
            }
        }

        //список временных данных
        public List<ProjectEquipment> GetAllTempEquip()
        {
            using(DataEntities db = new DataEntities())
            {
                return db.ProjectEquipments.Where(x => x.IdProjectNumber == null).ToList();
            }
        }

        //удаление временных данных 2.0
        public void RemoveTemp(List<ProjectEquipment> tempPrEqList)
        {
            using (DataEntities db = new DataEntities())
            {
                foreach (ProjectEquipment peq in tempPrEqList)
                {
                    if (peq.IdProjectNumber == null)
                    {
                        db.ProjectEquipments.Attach(peq);
                        db.ProjectEquipments.Remove(peq);
                    }

                    var equipNotes = db.EquipNotes.Where(x => x.IdProjectNumber == null).ToList();

                    foreach (EquipNote epn in equipNotes)
                    {
                        db.EquipNotes.Attach(epn);
                        db.EquipNotes.Remove(epn);
                    }
                }
                db.SaveChanges();
            }
        }

        //список всех обозначений
        public List<EquipNote> GetAllProjectNote()
        {
            using(DataEntities db = new DataEntities())
            {
                return db.EquipNotes.ToList();
            }
        }

        //id-выключателя в базе по номеру
        public int GetCbrId(Project project, string connectionNumber)
        {
            using(DataEntities db = new DataEntities())
            {
                if(project.IdNumber != 0) //связанное с проектом
                {
                    var idCbr = (from pe in db.ProjectEquipments
                                 join cbr in db.CurrentBreakers on pe.IdCbr equals cbr.Id
                                 join en in db.EquipNotes on pe.IdNote equals en.Id
                                 where en.Text == connectionNumber && pe.IdProjectNumber == project.IdNumber && pe.Analog == false
                                 select pe.IdCbr).SingleOrDefault();

                    return (int)idCbr;
                }
                else
                {
                    var idCbr = (from pe in db.ProjectEquipments
                                join cbr in db.CurrentBreakers on pe.IdCbr equals cbr.Id
                                join en in db.EquipNotes on pe.IdNote equals en.Id
                                where en.Text == connectionNumber && pe.IdProjectNumber == null && pe.Analog == false
                                 select pe.IdCbr).SingleOrDefault();

                    return (int)idCbr;
                }
            }
        }

        //проверить повторяющиеся наименования присоединений
        public bool CheckDuplicate(Project project, string connectionNumber)
        {
            using(DataEntities db = new DataEntities())
            {
                if(project.IdNumber != 0) //связанное с проектом
                {
                    var sql = (from pe in db.ProjectEquipments
                               join en in db.EquipNotes on pe.IdNote equals en.Id
                               where pe.IdProjectNumber == project.IdNumber && en.Text == connectionNumber
                               select pe).FirstOrDefault();
                    if (sql != null)
                        return true;
                }
                else
                {
                    var sql = (from pe in db.ProjectEquipments
                              join en in db.EquipNotes on pe.IdNote equals en.Id
                              where pe.IdProjectNumber == null && en.Text == connectionNumber
                               select pe).FirstOrDefault();
                    if (sql != null)
                        return true;
                }
                return false;
            }
        }

        //замена выключателя в проекте
        public ProjectEquipment ReplaceProjectCbr(Project project, string connectionNumber, CurrentBreaker newCbr)
        {
            using (DataEntities db = new DataEntities())
            {
                int? pidn = null;
                if (project.IdNumber != 0)
                    pidn = project.IdNumber; //если связан с проектом

                var peCbr = (from pe in db.ProjectEquipments
                             join cbr in db.CurrentBreakers on pe.IdCbr equals cbr.Id
                             join en in db.EquipNotes on pe.IdNote equals en.Id
                             where en.Text == connectionNumber && pe.IdProjectNumber == pidn && pe.Analog == false
                             select pe).SingleOrDefault();

                DisattachAnalog(peCbr, project, false); //удалить связанные аналоги

                if (peCbr != null)
                {
                    peCbr.IdCbr = newCbr.Id;
                    db.ProjectEquipments.Attach(peCbr);
                    db.Entry(peCbr).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    var peCbrnew = (from pe in db.ProjectEquipments
                                  where pe.Id == peCbr.Id
                                  select pe).SingleOrDefault();
                    return peCbrnew;
                }
                else return null;
            }
        }

        //проверка наличия сконфигурированных блоков
        public bool HasAnyBlocks(Project project)
        {
            using(DataEntities db = new DataEntities())
            {
                var block = (from pb in db.ProjectBlocks
                             join pn in db.ProjectNumbers on pb.IdProjectNumber equals pn.Id
                             where pn.Id == project.Id
                             select pb).DefaultIfEmpty(null).First();

                if (block != null)
                    return true;
                return false;
            }
        }
        #endregion
    }

}
