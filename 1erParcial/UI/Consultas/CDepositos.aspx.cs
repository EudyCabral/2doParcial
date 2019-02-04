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
    public partial class CDepositos : System.Web.UI.Page
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
            DepositosGridView.DataBind();
            Expression<Func<Depositos, bool>> filtro = x => true;
            Repositorio<Depositos> repositorio = new Repositorio<Depositos>();

            int id;

            DateTime desde = Convert.ToDateTime(DesdeTextBox.Text);
            DateTime hasta = Convert.ToDateTime(HastaTextBox.Text);

            switch (TipodeFiltro.SelectedIndex)
            {
                case 0://ID

                    id = util.ToInt(TextCriterio.Text);
                    if (Fechacheckbox.Checked == true)
                    {
                        filtro = x => x.DepositoId == id && (x.Fecha >= desde && x.Fecha <= hasta);
                    }
                    else
                    {
                        filtro = c => c.DepositoId == id;
                    }

                    if (repositorio.GetList(filtro).Count() == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
              "toastr.info('Deposito ID no Existe','Informacion',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
                        return;
                    }

                    break;

                case 1:// CuentaId
                    int cuentaid = util.ToInt(TextCriterio.Text);
                    if (Fechacheckbox.Checked == true)
                    {
                        filtro = x => x.CuentaId == cuentaid && (x.Fecha >= desde && x.Fecha <= hasta);
                    }
                    else
                    {
                        filtro = c => c.CuentaId == cuentaid;
                    }

                    if (repositorio.GetList(filtro).Count() == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
              "toastr.info('Nombre no Existe','Informacion',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
                        return;
                    }

                    break;



                case 2:// Concepto

                    if (Fechacheckbox.Checked == true)
                    {
                        filtro = x => x.Concepto.Contains(TextCriterio.Text) && (x.Fecha >= desde && x.Fecha <= hasta);
                    }
                    else
                    {
                        filtro = c => c.Concepto.Contains(TextCriterio.Text);
                    }
                    if (repositorio.GetList(filtro).Count() == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
              "toastr.info('Balance no Existe','Informacion',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
                        return;
                    }
                    break;

                case 3:// Monto
                    decimal monto = util.ToDecimal(TextCriterio.Text);
                    if (Fechacheckbox.Checked == true)
                    {
                        filtro = x => x.Monto == monto && (x.Fecha >= desde && x.Fecha <= hasta);
                    }
                    else
                    {
                        filtro = c => c.Monto == monto;
                    }

                    if (repositorio.GetList(filtro).Count() == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
              "toastr.info('Nombre no Existe','Informacion',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
                        return;
                    }

                    break;

                case 4://Todos

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

            DepositosGridView.DataSource = repositorio.GetList(filtro);
            DepositosGridView.DataBind();
        }
    }
}