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

namespace _1erParcial.UI.Consultas
{
    public partial class CCuentasBancarias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");

            }

        }

        Expression<Func<CuentasBancarias, bool>> filtro = x => true;
      

        public void Mensaje()
        {

            Repositorio<CuentasBancarias> repositorio = new Repositorio<CuentasBancarias>();
            if (repositorio.GetList(filtro).Count() == 0)
            {
                util.ShowToastr(this.Page, "No Existe", "Informacion", "info");
                return;
            }

        }

        public void Filtro()
        {
            CuentasGridView.DataBind();
         
            Repositorio<CuentasBancarias> repositorio = new Repositorio<CuentasBancarias>();

            int id;

            DateTime desde = Convert.ToDateTime(DesdeTextBox.Text);
            DateTime hasta = Convert.ToDateTime(HastaTextBox.Text);

            switch (TipodeFiltro.SelectedIndex)
            {
                case 0://ID

                    id = util.ToInt(TextCriterio.Text);
                   
                        filtro = x => x.CuentaId == id && (x.Fecha >= desde && x.Fecha <= hasta);

                    Mensaje();

                    break;

                case 1:// Nombre

                        filtro = x => x.Nombre.Contains(TextCriterio.Text) && (x.Fecha >= desde && x.Fecha <= hasta);
                        Mensaje();
                        break;



                case 2:// Balance

                    decimal balance = util.ToDecimal(TextCriterio.Text);
                 
                        filtro = x => x.Balance == balance && (x.Fecha >= desde && x.Fecha <= hasta);
                        Mensaje();
                        break;

                case 3://Todos

                  
                        filtro = x => true && (x.Fecha >= desde && x.Fecha <= hasta);
                        Mensaje();
                        break;

            }
            var listacuenta = repositorio.GetList(filtro);
            Session["Cuentas"] = listacuenta;
            CuentasGridView.DataSource = listacuenta;
            CuentasGridView.DataBind();

            if (CuentasGridView.Rows.Count > 0)
            {
                ImprimirButton.Visible = true;
            }
            else { ImprimirButton.Visible = false; }




        }

      
        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            Filtro();
        }
        protected void ImprimirButton_Click(object sender, EventArgs e)
        {

            Response.Write("<script>window.open('/WReportes/RepCuentas.aspx','_blank');</script");
        }
    }
}
