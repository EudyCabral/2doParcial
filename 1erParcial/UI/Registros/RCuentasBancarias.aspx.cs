using _1erParcial.Utilidades;
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
    public partial class RCuentasBancarias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                BalanceTextBox.Text = "0";
                CuentaidTextBox.Text = "0";
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        protected void LimpiarButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Repositorio<CuentasBancarias> repositorio = new Repositorio<CuentasBancarias>();

            CuentasBancarias cuenta = Llenaclase();

            bool paso = false;

            if (Page.IsValid)
            {
                if (cuenta.CuentaId == 0)
                {
                    paso = repositorio.Guardar(cuenta);

                }


                else
                {
                    var verificar = repositorio.Buscar(util.ToInt(CuentaidTextBox.Text));

                    if (verificar != null)
                    {
                        paso = repositorio.Modificar(cuenta);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
                     "toastr.error('Esta Cuenta No Existe','Fallo',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
                        return;
                    }
                }

                if (paso)

                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
                     "toastr.success('Cuenta Registrada','Exito',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);

                }

                else

                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
                 "toastr.error('No pudo Guardar','Fallo',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
                }
                Limpiar();
                return;
            }

        }

        public CuentasBancarias Llenaclase()
        {
            CuentasBancarias cuentas = new CuentasBancarias();

            cuentas.CuentaId = util.ToInt(CuentaidTextBox.Text);
            cuentas.Fecha = Convert.ToDateTime(FechaTextBox.Text);
            cuentas.Nombre = NombreTextBox.Text;
            cuentas.Balance = 0;
            return cuentas;
        }
        public void Limpiar()
        {
            CuentaidTextBox.Text ="0";
            NombreTextBox.Text = string.Empty;
            BalanceTextBox.Text = 0.ToString();
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        protected void ElminarButton_Click(object sender, EventArgs e)
        {
            LimpiarBE();
            Repositorio<CuentasBancarias> repositorio = new Repositorio<CuentasBancarias>();


     
            int id = util.ToInt(CuentaidTextBox.Text);
            var cuenta = repositorio.Buscar(id);


            if (cuenta == null)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
               "toastr.info('Este Numero de Cuenta no Existe o ya a Sido Eliminado','Informacion',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
            }

            else
            {
                repositorio.Eliminar(id);
                               
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
               "toastr.success('Cuenta a sido Borrada','Eliminado',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
                Limpiar();
            }

        }

        private void LlenaCampos(CuentasBancarias cuenta)

        {

            CuentaidTextBox.Text = cuenta.CuentaId.ToString();
            FechaTextBox.Text = cuenta.Fecha.ToString("yyyy-MM-dd");
            NombreTextBox.Text = cuenta.Nombre;
            BalanceTextBox.Text = cuenta.Balance.ToString();

           
        }

        public void LimpiarBE()
        {
            NombreTextBox.Text = string.Empty;
            BalanceTextBox.Text = "0";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {

       
            Repositorio<CuentasBancarias> repositorio = new Repositorio<CuentasBancarias>();
           

            CuentasBancarias cuenta = repositorio.Buscar(util.ToInt(CuentaidTextBox.Text));

            LimpiarBE();
            if (cuenta != null)
            {
                LlenaCampos(cuenta);

                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
               "toastr.success('Encontrada','Exito',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
             "toastr.info('Numero de Cuenta no Existe','No Existe',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
            }
        }
    }
}