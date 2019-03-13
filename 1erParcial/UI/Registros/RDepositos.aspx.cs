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
    public partial class RDepositos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DepositosidTextBox.Text = "0";
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }

        }

        public void LimpiarBE()
        {
            CuentaidTextBox.Text = string.Empty;
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            ConceptoTextBox.Text = string.Empty;
            MontoTextBox.Text = string.Empty;
        }

        private void LlenaCampos(Depositos depositos)

        {
            DepositosidTextBox.Text = depositos.DepositoId.ToString();
            CuentaidTextBox.Text = depositos.CuentaId.ToString();
            FechaTextBox.Text = depositos.Fecha.ToString("yyyy-MM-dd");
            ConceptoTextBox.Text = depositos.Concepto;
            MontoTextBox.Text = depositos.Monto.ToString();


        }


        public Depositos Llenaclase()
        {
            Depositos depositos = new Depositos();

            depositos.DepositoId = util.ToInt(DepositosidTextBox.Text);
            depositos.CuentaId = util.ToInt(CuentaidTextBox.Text);
            depositos.Fecha = Convert.ToDateTime(FechaTextBox.Text);
            depositos.Concepto = ConceptoTextBox.Text;
            depositos.Monto = util.ToDecimal(MontoTextBox.Text);
            
            return depositos;
        }

        public void Limpiar()
        {
            DepositosidTextBox.Text = "0";
            CuentaidTextBox.Text = string.Empty;
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            ConceptoTextBox.Text = string.Empty;
            MontoTextBox.Text = string.Empty;
        }


        protected void LimpiarButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }



        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Depositos> repositorio = new Repositorio<Depositos>();


            Depositos depositos = repositorio.Buscar(util.ToInt(DepositosidTextBox.Text));

            LimpiarBE();
            if (depositos != null)
            {
                LlenaCampos(depositos);

                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
               "toastr.success('Encontrada','Exito',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
             "toastr.info('Numero de Deposito no Existe','No Existe',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
            }
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {

            RepositorioDepositos repositorio = new RepositorioDepositos();
            Depositos depositos = Llenaclase();
            Repositorio<CuentasBancarias> cuentas = new Repositorio<CuentasBancarias>();

            var validar = cuentas.Buscar(util.ToInt(CuentaidTextBox.Text));

            bool paso = false;
        
            if (validar != null)
            {

                if (Page.IsValid)
                {
                    if (repositorio.VerificarDeposito(util.ToDecimal(MontoTextBox.Text)))
                    {
                        if (depositos.DepositoId == 0)
                        {
                            paso = repositorio.Guardar(depositos);

                        }

                        else
                        {
                            var verificar = repositorio.Buscar(util.ToInt(DepositosidTextBox.Text));
                            if (verificar != null)
                            {
                                paso = repositorio.Modificar(depositos);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
                             "toastr.error('Este Deposito No Existe','Fallo',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
                                return;
                            }
                        }

                        if (paso)

                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
                             "toastr.success('Deposito Registrado','Exito',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);

                        }

                        else

                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
                         "toastr.error('No pudo Guardar','Fallo',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
                        }
                        Limpiar();
                        return;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
                                "toastr.error('Debe Hacer un Deposit Mayor a 0','Fallo',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
                        return;
                    }

                  
                }


            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
               "toastr.error('Numero de Cuenta no Existe','Fallo',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
                return;


            }
        }

        protected void ElminarButton_Click(object sender, EventArgs e)
        {
            LimpiarBE();
            RepositorioDepositos repositorio = new RepositorioDepositos();
            Repositorio<Depositos> dep = new Repositorio<Depositos>();


            int id = util.ToInt(DepositosidTextBox.Text);
            var depositos = repositorio.Buscar(id);


            if (depositos == null)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
               "toastr.info('Este Numero de Deposito no Existe o ya a Sido Eliminado','Informacion',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
            }

            else
            {
                repositorio.Eliminar(id);



                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script:
               "toastr.success('Deposito a sido Borrada','Eliminado',{ 'progressBar': true,'positionClass': 'toast-bottom-right'});", addScriptTags: true);
                Limpiar();
            }

        }
    }
}