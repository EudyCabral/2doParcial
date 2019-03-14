using _1erParcial.Utilidades;
using _1erParcial.WReportes;
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
    public partial class CPrestamos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");

            }
        }

       
        Expression<Func<Prestamos, bool>> filtro = x => true;

        public void Mensaje()
        {

            Repositorio<Prestamos> repositorio = new Repositorio<Prestamos>();
            
            if (repositorio.GetList(filtro).Count() == 0)
            {
                util.ShowToastr(this.Page, "No Existe o ", "Informacion", "info");
                return;
            }

        }


        private void Filtro()
        {
            PrestamoGridView.DataBind();
          
            Repositorio<Prestamos> repositorio = new Repositorio<Prestamos>();

      
            int id;

            DateTime desde = Convert.ToDateTime(DesdeTextBox.Text);
            DateTime hasta = Convert.ToDateTime(HastaTextBox.Text);

            switch (TipodeFiltro.SelectedIndex)
            {
                case 0://ID

                    id = util.ToInt(TextCriterio.Text);
                  
                        filtro = x => x.PrestamoId == id && (x.Fecha >= desde && x.Fecha <= hasta);
                    Mensaje();
                    break;

                case 1:// CuentaId
                    int cuentaid = util.ToInt(TextCriterio.Text);
                  
                        filtro = x => x.Cuenta == cuentaid && (x.Fecha >= desde && x.Fecha <= hasta);

                    Mensaje();

                    break;



                case 2:// NombredeCuenta

                
                        filtro = x => x.NombreCuenta.Contains(TextCriterio.Text) && (x.Fecha >= desde && x.Fecha <= hasta);
                    Mensaje();
                    break;

                case 3:// Capital
                    decimal capital = util.ToDecimal(TextCriterio.Text);
                    
                        filtro = x => x.Capital == capital && (x.Fecha >= desde && x.Fecha <= hasta);
                    Mensaje();
                    break;

                case 4://Interes
                    decimal interes = util.ToDecimal(TextCriterio.Text);
                        filtro = x => x.Interes ==  interes && (x.Fecha >= desde && x.Fecha <= hasta);
                    Mensaje();
                    break;

                case 5: //Tiempo
                    int tiempo = util.ToInt(TextCriterio.Text);
                    filtro = x => x.Tiempo == tiempo && (x.Fecha >= desde && x.Fecha <= hasta);
                    Mensaje();
                    break;


                case 6: //Balance
                    decimal Balance = util.ToInt(TextCriterio.Text);
                    filtro = x => x.Balance == Balance && (x.Fecha >= desde && x.Fecha <= hasta);
                    Mensaje();
                    break;


                case 7: //Todo
                    
                    filtro = x => true && (x.Fecha >= desde && x.Fecha <= hasta);
                    Mensaje();
                    break;





            }
            var ListaPrestamo = repositorio.GetList(filtro);
            Session["Prestamo"] = ListaPrestamo;
            PrestamoGridView.DataSource = ListaPrestamo;
         
            PrestamoGridView.DataBind();

            if (PrestamoGridView.Rows.Count > 0)
            {
                ImprimirButton.Visible = true;
            }
            else { ImprimirButton.Visible = false; }
            TextCriterio.Text = "";
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            Filtro();
        }
    


        protected void ImprimirButton_Click(object sender, EventArgs e)
        {
          
   
            Response.Write("<script>window.open('/WReportes/RepPrestamo.aspx','_blank');</script");
        }
    }
}