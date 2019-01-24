using Model;
using ServicesLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synectix
{
    public static class ProjectFiles
    {
        //ассоциация иконок с расширением файла
        static Dictionary<string, Image> fileIcons = new Dictionary<string, Image>(17)
        {
            [".doc"] = Properties.Resources.file_doc,
            [".docx"] = Properties.Resources.file_doc,
            [".rtf"] = Properties.Resources.file_doc,
            [".txt"] = Properties.Resources.file_txt,
            [".xls"] = Properties.Resources.file_xls,
            [".xlsx"] = Properties.Resources.file_xls,
            [".csv"] = Properties.Resources.file_xls,
            [".accdb"] = Properties.Resources.file_adp,
            [".accde"] = Properties.Resources.file_adp,
            [".rar"] = Properties.Resources.file_rar,
            [".zip"] = Properties.Resources.file_zip,
            [".bmp"] = Properties.Resources.file_bmp,
            [".jpg"] = Properties.Resources.file_jpg,
            [".png"] = Properties.Resources.file_png,
            [".gif"] = Properties.Resources.file_png,
            [".tif"] = Properties.Resources.file_tiff,
            [".pdf"] = Properties.Resources.file_pdf
        };

        public static Image GetIcon(string _fileExtension)
        {
            return fileIcons[_fileExtension];
        }

        //запись файлов в базу
        public static List<int> Insert(List<FileInfo> finfo, string author)
        {
            List<int> listFileId = new List<int>();
            foreach (FileInfo fi in finfo)
            {
                FileStream fs = new FileStream(fi.FullName, FileMode.Open, FileAccess.Read);
                BinaryReader rdr = new BinaryReader(fs);
                byte[] fileData = rdr.ReadBytes((int)fs.Length);
                rdr.Close();
                fs.Close();

                long fsize = fi.Length / 1024;
                if (fsize == 0) fsize = 1;
                string fileName = fi.Name.Remove(fi.Name.LastIndexOf(@"."));

                listFileId.Add(FileServices.Insert(fileName, fi.LastWriteTime, fi.Extension, fsize, author, fileData));
            }
            return listFileId;
        }

        //прикрепить файл к проекту
        public static void Attach(int projectId, User user, List<FileInfo> finfo)
        {
            FileServices.Attach(projectId, Insert(finfo, user.UserName).ToArray());
        }
    }
}
