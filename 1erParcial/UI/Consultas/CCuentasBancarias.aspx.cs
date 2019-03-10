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

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            CuentasGridView.DataBind();
            Expression<Func<CuentasBancarias, bool>> filtro = x => true;
            Repositorio<CuentasBancarias> repositorio = new Repositorio<CuentasBancarias>();

            int id;

            DateTime desde = Convert.ToDateTime(DesdeTextBox.Text);
            DateTime hasta = Convert.ToDateTime(HastaTextBox.Text);

            switch (TipodeFiltro.SelectedIndex)
            {
                case 0://ID

                    id = util.ToInt(TextCriterio.Text);
                    if (Fechacheckbox.Checked == true)
                    {
                        filtro = x => x.CuentaId == id && (x.Fecha >= desde && x.Fecha <= hasta);
                    }
                    else
                    {
                        filtro = c => c.CuentaId == id;
                    }

                    if (repositorio.GetList(filtro).Count() == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
              "toastr.info('ID no Existe','Informacion',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
                        return;
                    }

                    break;

                case 1:// Nombre

                    if (Fechacheckbox.Checked == true)
                    {
                        filtro = x => x.Nombre.Contains(TextCriterio.Text) && (x.Fecha >= desde && x.Fecha <= hasta);
                    }
                    else
                    {
                        filtro = c => c.Nombre.Contains(TextCriterio.Text);
                    }

                    if (repositorio.GetList(filtro).Count() == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
              "toastr.info('Nombre no Existe','Informacion',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
                        return;
                    }

                    break;



                case 2:// Balance

                   decimal balance = util.ToDecimal(TextCriterio.Text);
                    if (Fechacheckbox.Checked == true)
                    {
                        filtro = x => x.Balance == balance && (x.Fecha >= desde && x.Fecha <= hasta);
                    }
                    else
                    {
                        filtro = c => c.Balance == balance;
                    }
                    if (repositorio.GetList(filtro).Count() == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
              "toastr.info('Balance no Existe','Informacion',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
                        return;
                    }
                    break;

                case 3://Todos

                    if (Fechacheckbox.Checked == true)
                    {
                        filtro = x => true && (x.Fecha >= desde && x.Fecha <= hasta);
                    }
                    else
                    {
                        filtro = x => true;
                    }
                   
                    if (repositorio.GetList(filtro).Count() == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
              "toastr.info('No Existen Cuentas','Informacion',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
                        return;
                    }
                    break;

            }

            CuentasGridView.DataSource = repositorio.GetList(filtro);
            CuentasGridView.DataBind();

            ImprimirButton.Visible = true;

        }

        protected void ImprimirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"~\WReportes\RepCuentas.aspx");
        }
    }
}
