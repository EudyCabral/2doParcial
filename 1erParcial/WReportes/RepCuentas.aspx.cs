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
    public partial class RepCuentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Repositorio<CuentasBancarias> repositorio = new Repositorio<CuentasBancarias>();
       
                MyReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                MyReportViewer.Reset();
             
                 MyReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\Cuentas.rdlc");
               MyReportViewer.LocalReport.DataSources.Clear();
                MyReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", (List<CuentasBancarias>)Session["Cuentas"]));
                
                MyReportViewer.LocalReport.Refresh();
            }

        }

    }
}