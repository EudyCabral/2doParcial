using BLL;
using Entidades;
using Microsoft.Reporting.WebForms;
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
            if (!Page.IsPostBack)
            {
                Repositorio<Prestamos> repositorio = new Repositorio<Prestamos>();
                Repositorio<PrestamoDetalles> repositorioD = new Repositorio<PrestamoDetalles>();

                MyReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                MyReportViewer.Reset();
                MyReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ReportePrestamo.rdlc");
                MyReportViewer.LocalReport.DataSources.Clear();
                MyReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Prestamos", repositorio.GetList(x => true)));
                MyReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Detalle", repositorioD.GetList(x => true)));
                MyReportViewer.LocalReport.Refresh();
            }
        }
    }
}