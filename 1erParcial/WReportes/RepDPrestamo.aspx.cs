﻿using BLL;
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
    public partial class RepDPrestamo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Repositorio<Prestamos> repositorio = new Repositorio<Prestamos>();
                Repositorio<PrestamoDetalles> repositorioD = new Repositorio<PrestamoDetalles>();

                MyReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                MyReportViewer.Reset();
                MyReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\Prestamo.rdlc");
                MyReportViewer.LocalReport.DataSources.Clear();

          

                MyReportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSetPrestamo", (List<Prestamos>)Session["Prestamo"]));
                MyReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Detalle", (List<PrestamoDetalles>)Session["PrestamoD"]));
                MyReportViewer.LocalReport.Refresh();
            }
        }
    }
}