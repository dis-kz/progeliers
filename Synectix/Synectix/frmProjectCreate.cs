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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Synectix
{
    public partial class frmProjectCreate : Form
    {        
        List<FileInfo> listFileInfo = new List<FileInfo>();
        ImageList listIcon = new ImageList();
        User _user;

        public frmProjectCreate()
        {
            InitializeComponent();
        }

        #region События формы

        //загрузка
        private void frmProjectCreate_Load(object sender, EventArgs e)
        {
            projectBindingSource.DataSource = new Project();
            projectNumberBindingSource.DataSource = new ProjectNumber();

            _user = ProjectServices.GetLoggedIn(frmLogin.Instance.UserInfo);
            txtManager.Text = _user.UserName;
        }

        //закрытие
        private void frmProjectCreate_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if(MessageBox.Show("Выйти без сохранения?","Информация",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
            //{
            //    e.Cancel = true;
            //}
        }
       
        //удаление файла - нажатие Delete
        private void listFiles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (listViewFiles.SelectedIndices.Count > 0)
                {
                    int index = listViewFiles.SelectedIndices[0];            //индекс выделенного элемента

                    listViewFiles.Items.RemoveAt(index);                     //удалить элемент из просмотра
                    listFileInfo.RemoveAt(index);                           //удалить файл из списка
                }
            }
        }

        //просмотр файла в ассоциированном приложении - DoubleClick
        private void listViewFiles_DoubleClick(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedIndices.Count > 0)
            {               
                int index = listViewFiles.SelectedIndices[0]; //индекс выделенного элемента

                Process prc = new Process();
                prc.StartInfo.FileName = listFileInfo.ElementAt(index).FullName;
                prc.Start();
                prc.Close();
            }
        }

        #endregion

        #region  Очистка цвета заднего фона при редактировании полей
        private void txtProjectNumber_TextChanged(object sender, EventArgs e)
        {
            txtProjectNumber.BackColor = System.Drawing.Color.White;
        }
        private void txtProjectDescription_TextChanged(object sender, EventArgs e)
        {
            txtProjectDescription.BackColor = System.Drawing.Color.White;
        }
        private void txtSpecialRequire_TextChanged(object sender, EventArgs e)
        {
            txtSpecialRequire.BackColor = System.Drawing.Color.White;
        }
        #endregion

        #region Кнопки

        /* [ Прикрепить ] */
        private void btnBindFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDlg.Multiselect = true;

            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                #region Отображение списка файлов на форме
                listViewFiles.SmallImageList = listIcon;

                /*множественный выбор*/
                foreach (string file in openFileDlg.FileNames)
                {
                    FileInfo fi = new FileInfo(file/*openFileDlg.FileName*/);
                    Image icon = ProjectFiles.GetIcon(Path.GetExtension(fi.FullName));
                    listIcon.Images.Add(icon);
                    long fsize = fi.Length / 1024;
                    if (fsize == 0) fsize = 1;
                    string fileName = fi.Name.Remove(fi.Name.LastIndexOf(@"."));

                    ListViewItem lvi = new ListViewItem();
                    int i = listViewFiles.Items.Add(lvi).Index;
                    lvi.ImageIndex = listIcon.Images.Count - 1;

                    lvi.Text = "  " + fileName;                                         //имя
                    listViewFiles.Items[i].SubItems.Add(fi.LastWriteTime.ToString());    //дата изменения
                    listViewFiles.Items[i].SubItems.Add(fi.Extension);                   //тип
                    listViewFiles.Items[i].SubItems.Add(fsize.ToString() + " кб");       //размер
                    #endregion

                    listFileInfo.Add(fi); //добавить в список файлов
                }
            }
        }

        /* [ Сохранить ] */
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProjectDescription.Text) || string.IsNullOrEmpty(txtProjectNumber.Text)
                                                                 || string.IsNullOrEmpty(txtSpecialRequire.Text))
            {
                MessageBox.Show("Необходимо заполнить все поля", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                foreach (Control ctr in this.Controls)
                {
                    if (ctr.GetType() == typeof(TextBox))
                    {
                        if (string.IsNullOrEmpty(ctr.Text))
                        {
                            ctr.BackColor = Color.FromArgb(255, 203, 195);
                        }
                    }
                }
                return;
            }
            else
            {
                try
                {
                    int newProjectId = ProjectServices.InsertProjectNumber(projectNumberBindingSource.Current as ProjectNumber);

                    if(newProjectId != 0)
                    {
                        ProjectServices.Create(projectBindingSource.Current as Project, newProjectId, _user.Id);
                        ProjectFiles.Attach(newProjectId, _user, listFileInfo);
                        MessageBox.Show("Проект успешно создан", "Инфморация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Проект с идентификатором " + txtProjectNumber.Text + " уже существует.\r\n" +
                                       "Повторное создание запрещено", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtProjectNumber.BackColor = Color.FromArgb(255, 203, 195);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        #endregion

    }
}
