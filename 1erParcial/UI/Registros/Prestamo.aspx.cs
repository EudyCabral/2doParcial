using _1erParcial.Utilidades;
using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

            if (!Page.IsPostBack)
            {

                LLenacombobox();
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");


            }


        }

        protected void BindGrid()
        {
            DetalleGridView.DataSource = ((Prestamos)ViewState["Prestamos"]).Detalles;

            DetalleGridView.DataBind();
        }

        public void LLenacombobox()
        {
            Repositorio<CuentasBancarias> repositorio = new Repositorio<CuentasBancarias>();

            CuentasDropDownList.DataSource = repositorio.GetList(t => true);
            CuentasDropDownList.DataValueField = "CuentaId";
            CuentasDropDownList.DataTextField = "Nombre";
            CuentasDropDownList.DataBind();
            ViewState["Prestamos"] = new Prestamos();
        }




        public void Limpiar()
        {
            PrestamoidTextBox.Text = "";
            CapitalTextBox.Text = "";
            InteresTextBox.Text = "";
            TiempoTextBox.Text = "";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            ViewState["Prestamos"] = new Prestamos();
            this.BindGrid();
          
            BalanceTextBox.Visible = false;
            Labelbalance.Visible = false;
        }


        protected void LimpiarButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void CalcularButton_Click(object sender, EventArgs e)
        {
           
            ViewState["Prestamos"] = new Prestamos();
            this.BindGrid();


            PrestamoRepositorio repositorio = new PrestamoRepositorio();
            Prestamos prestamo = new Prestamos();
            PrestamoDetalles cuota = new PrestamoDetalles();


            int fila = Utilidades.util.ToInt(TiempoTextBox.Text);
            DateTime fecha = Convert.ToDateTime(FechaTextBox.Text);


            decimal interes = Utilidades.util.ToInt(InteresTextBox.Text);
            int tiempo = Utilidades.util.ToInt(TiempoTextBox.Text);
            decimal capital = Utilidades.util.ToDecimal(CapitalTextBox.Text);
            BalanceTextBox.Text = repositorio.BalanceCuota(capital, interes).ToString();
            interes /= 100;

            for (int i = 1; i <= fila; i++)
            {

                cuota.Interes = (interes * capital) / tiempo;
                cuota.Capital = capital / tiempo;

                decimal monto = (cuota.Interes * tiempo) + capital;
                if (i == 1)
                {

                    cuota.Balance = monto - (cuota.Interes + cuota.Capital);
                }
                else
                {
                    cuota.Balance = cuota.Balance - (cuota.Capital + cuota.Interes);
                }

                prestamo = (Prestamos)ViewState["Prestamos"];


                prestamo.AgregarDetalle(0, Utilidades.util.ToInt(PrestamoidTextBox.Text), i, cuota.Fecha.AddMonths(i), cuota.Interes, cuota.Capital, cuota.Balance);

                ViewState["Prestamos"] = prestamo;

                this.BindGrid();

            }
      
            BalanceTextBox.Visible = true;
            Labelbalance.Visible = true;
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
      
            if(DetalleGridView.DataSource == null)
            {
                util.ShowToastr(this.Page, "El Grid esta Vacio, Favor de llenar!!", "Informacio!!", "info");
                return;
            }
            PrestamoRepositorio prestamoRepositorio = new PrestamoRepositorio();
            Prestamos prestamos = LlenaClase();
            bool paso = false;

            if (prestamos.PrestamoId == 0)
            {
                paso = prestamoRepositorio.Guardar(prestamos);
            }
            else
            {
                paso = prestamoRepositorio.Modificar(prestamos);
            }

            if (paso)
            {
                util.ShowToastr(this.Page, "Guardado con exito!!", "Guardado!!", "success");
                Limpiar();
            }



        }

        private Prestamos LlenaClase()
        {
            Prestamos prestamo = new Prestamos();

            prestamo = (Prestamos)ViewState["Prestamos"];
            prestamo.PrestamoId = util.ToInt(PrestamoidTextBox.Text);
            prestamo.Fecha = Convert.ToDateTime(FechaTextBox.Text);
            prestamo.Cuenta = util.ToInt(CuentasDropDownList.SelectedValue);
            prestamo.NombreCuenta = RetornarNombre(util.ToInt(CuentasDropDownList.SelectedValue));
            prestamo.Capital = util.ToInt(CapitalTextBox.Text);
            prestamo.Interes = util.ToInt(InteresTextBox.Text);
            prestamo.Tiempo = util.ToInt(TiempoTextBox.Text);
            prestamo.Balance = util.ToDecimal(BalanceTextBox.Text);

            return prestamo;

        }


        public static string RetornarNombre(int id)
        {
            Repositorio<CuentasBancarias> repositorio = new Repositorio<CuentasBancarias>();
            string descripcion = string.Empty;
            var lista = repositorio.GetList(x => x.CuentaId == id);
            foreach (var item in lista)
            {
                descripcion = item.Nombre;
            }

            return descripcion;
        }

        protected void ElminarButton_Click(object sender, EventArgs e)
        {
           
            int id = util.ToInt(PrestamoidTextBox.Text);

            PrestamoRepositorio repositorio = new PrestamoRepositorio();

            if (repositorio.Eliminar(id))
            {
                util.ShowToastr(this.Page, "Eliminado con exito!!", "Eliminado", "info");
                Limpiar();
            }
            else
            {
                util.ShowToastr(this.Page, "Fallo al Eliminar :(", "Error", "error");
            }
        }
        private void Llenacampos(Prestamos prestamos)
        {


            Expression<Func<PrestamoDetalles, bool>> filtro = x => true;
            Repositorio<PrestamoDetalles> repositorio = new Repositorio<PrestamoDetalles>();

            PrestamoidTextBox.Text = prestamos.PrestamoId.ToString();
            FechaTextBox.Text = prestamos.Fecha.ToString("yyyy-MM-dd");
            CuentasDropDownList.Text = prestamos.Cuenta.ToString();
            CapitalTextBox.Text = prestamos.Capital.ToString();
            InteresTextBox.Text = prestamos.Interes.ToString();
            TiempoTextBox.Text = prestamos.Tiempo.ToString();
            BalanceTextBox.Text = prestamos.Balance.ToString();

            filtro = x => x.PrestamoId == prestamos.PrestamoId;
            DetalleGridView.DataSource = repositorio.GetList(filtro);
            DetalleGridView.DataBind();

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            
            PrestamoRepositorio repositorio = new PrestamoRepositorio();
            var prestamo = repositorio.Buscar(util.ToInt(PrestamoidTextBox.Text));

            if (prestamo != null)
            {
                Limpiar();
                Llenacampos(prestamo);
                BalanceTextBox.Visible = true;
                Labelbalance.Visible = true;
                util.ShowToastr(this, "Busqueda exitosa", "Exito", "success");
            }
            else
            {
                util.ShowToastr(this.Page, "El usuario que intenta buscar no existe", "Error", "error");
                Limpiar();
            }
        }

        protected void ImprimirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~\WReportes\RepPrestamo.aspx");
            
        }
    }
}