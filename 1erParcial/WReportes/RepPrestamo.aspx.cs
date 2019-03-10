using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _1erParcial.WReportes
{
    public partial class RepPrestamo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                MyReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                MyReportViewer.Reset();

                MyReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ReportePrestamo.rdlc");
                MyReportViewer.LocalReport.DataSources.Clear();
                
                MyReportViewer.LocalReport.Refresh();
            }
        }
    }
}