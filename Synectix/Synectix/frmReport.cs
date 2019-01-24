using Microsoft.Reporting.WinForms;
using Model;
using ServicesLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Synectix
{
    public partial class frmReport : Form
    {
        ReportParameter prmProject;
        string paramValue;
        bool inProject;
        int idProjectNumber, analog;

        #region конструктор
        public frmReport(Project project)
        {
            InitializeComponent();

            if (project.IdNumber != 0)
            {
                paramValue = ProjectServices.GetProjectNumber(project) + " (" + project.Date.ToString() + ") \r\n" + project.Description;
                inProject = true;
                idProjectNumber = (int)project.IdNumber;
            }
            else
            {
                paramValue = "Подбор оборудования\r\n" + project.Date.ToString();
                inProject = false;
                idProjectNumber = (int)project.IdNumber;
            }

            prmProject = new ReportParameter("prmProject", paramValue);
        }

        #endregion

        #region Кнопки

        /* [ Базовые ] */
        private void btnBase_Click(object sender, EventArgs e)
        {
            analog = 0;

            this.rpvCbr.LocalReport.ReportEmbeddedResource = "Synectix.Report_CurrentBreaker.rdlc";

            this.dtTabAdapter.Fill(this.dsReport.dtReport, inProject, idProjectNumber, analog);
            this.rpvCbr.LocalReport.SetParameters(new ReportParameter[] { prmProject });
            this.rpvCbr.RefreshReport();
        }

        /* [ Аналоги ] */
        private void btnAnalog_Click(object sender, EventArgs e)
        {
            analog = 1;

            this.rpvCbr.LocalReport.ReportEmbeddedResource = "Synectix.Report_CurrentBreaker_Analog.rdlc";

            this.dtTabAdapterAnalog.Fill(this.dsReportAnalog.dtReportAnalog, inProject, idProjectNumber, analog);
            this.rpvCbr.LocalReport.SetParameters(new ReportParameter[] { prmProject });
            this.rpvCbr.RefreshReport();
        }

        #endregion
    }
}
