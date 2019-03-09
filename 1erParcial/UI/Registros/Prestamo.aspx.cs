using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _1erParcial.UI.Registros
{
    public partial class Prestamo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CuentasBancarias cuentas = new CuentasBancarias();

            if(!Page.IsPostBack)
            {
                Repositorio<CuentasBancarias> repositorio = new Repositorio<CuentasBancarias>();

                CuentasDropDownList.DataSource = repositorio.GetList(t => true);
                CuentasDropDownList.DataValueField = "CuentaId";
                CuentasDropDownList.DataTextField = "Nombre";
                CuentasDropDownList.DataBind();

                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");

                ViewState["Prestamo"] = new Prestamos();
            }

           
        }

        protected void BindGrid()
        {
            DetalleGridView.DataSource = ((Prestamos)ViewState["Prestamos"]).Detalles;
            DetalleGridView.DataBind();
        }

        public void Limpiar()
        {
            DepositoIdTextBox.Text = "";
            CapitalTextBox.Text = "";
            InteresTextBox.Text = "";
            TiempoTextBox.Text = "";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            DetalleGridView.DataSource = null;
        }


        protected void LimpiarButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void CalcularButton_Click(object sender, EventArgs e)
        {
            PrestamoRepositorio repositorio = new PrestamoRepositorio();

            int fila = Utilidades.util.ToInt(TiempoTextBox.Text);

            decimal cuotainteres = repositorio.InteresCuota(Utilidades.util.ToDecimal(CapitalTextBox.Text), Utilidades.util.ToInt(TiempoTextBox.Text), Utilidades.util.ToInt(InteresTextBox.Text));

            decimal capitalcuota = repositorio.CapitalCuota(Utilidades.util.ToDecimal(CapitalTextBox.Text), Utilidades.util.ToInt(TiempoTextBox.Text));

            decimal balancecuota = repositorio.BalanceCuota(Utilidades.util.ToDecimal(CapitalTextBox.Text), Utilidades.util.ToInt(TiempoTextBox.Text), Utilidades.util.ToInt(InteresTextBox.Text));

            DateTime fecha = Convert.ToDateTime(FechaTextBox.Text);

            for (int i = 0; i < fila; i++)
            {
                Prestamos prestamo = new Prestamos();
               

                prestamo = (Prestamos)ViewState["Prestamos"];
                prestamo.AgregarDetalle(0,0,fecha,cuotainteres,capitalcuota,balancecuota);

                ViewState["Prestamos"] = prestamo;

                this.BindGrid();
              
            }
        }
    }
}