using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class SynectixFile : ISynectixFile
    {

        //записать файл в базу данных
        public int Insert(string name, DateTime date, string extension, long size, string author, byte[] data)
        {
            using (DataEntities db = new DataEntities())
            {
                try
                {
                    FileData file = new FileData();
                    Guid guid = Guid.NewGuid();

                    file.GUID = guid;
                    file.Name = name;
                    file.Date = date;
                    file.Extension = extension;
                    file.Size = size;
                    file.Data = data;
                    file.Author = author;

                    db.FileDatas.Add(file);
                    db.SaveChanges();

                    var id = (from fd in db.FileDatas
                              where fd.GUID == guid
                              select fd.Id).SingleOrDefault();

                    return id;

                }
                catch
                {
                    return -1;
                }
            }
        }

        //прикрепить файл к проекту
        public void Attach(int projectId, int[] idFiles)
        {
            using (DataEntities db = new DataEntities())
            {
                foreach (int id in idFiles)
                {
                    if (id != 0)
                    {
                        ProjectFile pf = new ProjectFile();
                        pf.IdProjectNumber = projectId;
                        pf.IdFile = id;

                        db.ProjectFiles.Add(pf);
                    }
                }
                db.SaveChanges();
            }
        }

        //удалить файл из базы по Id
        public void Delete(int idFile)
        {
            using (DataEntities db = new DataEntities())
            {
                var sql = (from fd in db.FileDatas
                           where fd.Id == idFile
                           select fd).SingleOrDefault();

                FileData file = sql as FileData;

                db.FileDatas.Attach(file);
                db.FileDatas.Remove(file);
                db.SaveChanges();
            }
        }

        //список файлов проекта
        public List<FileData> GetList(int idProjectNumber)
        {
            using (DataEntities db = new DataEntities())
            {
                var sql = from fd in db.FileDatas
                          join pf in db.ProjectFiles on fd.Id equals pf.IdFile
                          where pf.IdProjectNumber == idProjectNumber
                          select fd;

                foreach (FileData f in sql)
                {
                    f.Data = null;
                }

                return sql.ToList();
            }
        }

        //скачать файл по id
        public FileData GetById(int id)
        {
            using (DataEntities db = new DataEntities())
            {
                var sql = (from fd in db.FileDatas
                           where fd.Id == id
                           select fd).SingleOrDefault();

                return sql;
            }
        }
    }
}
