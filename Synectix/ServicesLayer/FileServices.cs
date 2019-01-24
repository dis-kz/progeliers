using DataLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer
{
    public class FileServices
    {
        static ISynectixFile fileobject;

        //инициализация статического члена класса
        static FileServices()
        {
            fileobject = new SynectixFile();
        }

        //запись файла в базу данных
        public static int Insert(string name, DateTime date, string extension, long size, string author, byte[] data)
        {
            return fileobject.Insert(name, date, extension, size, author, data);
        }

        //прикрепить файл к проекту
        public static void Attach(int projectId, int[] idFiles)
        {
            fileobject.Attach(projectId, idFiles);
        }

        //удалить файл из базы по Id
        public static void Delete(int idFile)
        {
            fileobject.Delete(idFile);
        }

        //список файлов проекта
        public static List<FileData> GetList(int idProjectNumber)
        {
            return fileobject.GetList(idProjectNumber);
        }

        //скачать файл по id
        public static FileData GetById(int id)
        {
            return fileobject.GetById(id);
        }
    }
}
