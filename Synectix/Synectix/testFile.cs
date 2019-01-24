using Model;
using ServicesLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Synectix
{
    public partial class testFile : Form
    {
        List<FileData> listFile = new List<FileData>();
        string tempFolder = @"C:\tempFiles\";

        public testFile()
        {
            InitializeComponent();
            if (!Directory.Exists(tempFolder)) Directory.CreateDirectory(tempFolder);
        }

        //получить список файлов
        private void button1_Click(object sender, EventArgs e)
        {
            listFile = FileServices.GetList(2);

            for(int i = 0; i < listFile.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                int j = listViewFiles.Items.Add(lvi).Index;

                lvi.Text = "  " + listFile.ElementAt(i).Name;                                   //имя
                listViewFiles.Items[j].SubItems.Add(listFile.ElementAt(i).Date.ToString());     //дата изменения
                listViewFiles.Items[j].SubItems.Add(listFile.ElementAt(i).Extension);           //тип
                listViewFiles.Items[j].SubItems.Add(listFile.ElementAt(i).Size + " кб");        //размер
            }
        }

        //открыть файл из списка
        private void listViewFiles_DoubleClick(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedIndices.Count > 0)
            {
                int index = listViewFiles.SelectedIndices[0];                                   //индекс выделенного элемента

                FileData fd = FileServices.GetById(listFile.ElementAt(index).Id);        //скачать массив байтов (данные файла) из БД               
                string filename = tempFolder + fd.Name + fd.Extension;

                FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.Write); //создать и записать файл на жёсткий диск клиента
                fs.Write(fd.Data, 0, fd.Data.Length);
                fs.Flush();
                fs.Close();

                Process prc = new Process();
                prc.StartInfo.FileName = filename;
                prc.Start();
                prc.Close();
            }
        }

        //закрытие формы
        private void testFile_FormClosing(object sender, FormClosingEventArgs e)
        {
            Directory.Delete(tempFolder, true);
        }
    }
}
