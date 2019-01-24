using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface ISynectixFile
    {
        //работа с файлами
        int Insert(string name, DateTime date, string extension, long size, string author, byte[] data);
        void Attach(int projectId, int[] idFiles);
        void Delete(int idFile);
        List<FileData> GetList(int idProjectNumber);
        FileData GetById(int id);
    }
}
