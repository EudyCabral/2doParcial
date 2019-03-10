using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioDepositos: Repositorio<Depositos>
    {
        public override bool Guardar(Depositos depositos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
               

                if (contexto.depositos.Add(depositos) != null)
                {

                    var cuenta = contexto.cuentasbancarias.Find(depositos.CuentaId).Balance += depositos.Monto;
                    //Incrementar el balance
                    


                    contexto.SaveChanges();
                    paso = true;

                   
                }
                contexto.Dispose();

            }
            catch (Exception) { throw; }

            return paso;
        }

        public override bool Modificar(Depositos depositos)
        {

            bool paso = false;
            Contexto contexto = new Contexto();
            Repositorio<Depositos> repositorio = new Repositorio<Depositos>();
            try
            {
               
                //Buscar

                var depositosanterior = repositorio.Buscar(depositos.DepositoId);

                var Cuenta = contexto.cuentasbancarias.Find(depositos.CuentaId);
                var Cuentasanterior = contexto.cuentasbancarias.Find(depositosanterior.CuentaId);

                if(depositos.CuentaId != depositosanterior.CuentaId)
                {
                    Cuenta.Balance += depositos.Monto;
                    Cuentasanterior.Balance -= depositosanterior.Monto;
                }

               

                //identificar la diferencia ya sea restada o sumada
                decimal diferencia;
                diferencia = depositos.Monto - depositosanterior.Monto;
              
              
             
                //aplicar diferencia al inventario 
                Cuenta.Balance += diferencia;

                contexto.Entry(depositos).State = EntityState.Modified;

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();

            }
            catch (Exception) { throw; }

            return paso;
        }


        public override bool Eliminar(int id)
        {

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                Depositos depositos = contexto.depositos.Find(id);

                if (depositos != null)
                {
                    var cuenta = contexto.cuentasbancarias.Find(depositos.CuentaId);
                    //Incrementar la cantidad
                    cuenta.Balance -= depositos.Monto;

                    contexto.Entry(depositos).State = EntityState.Deleted;

                }

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                    contexto.Dispose();
                }


            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public bool VerificarDeposito(decimal deposito)
        {
            bool paso = false;

            if(deposito > 0)
            {
                paso = true;
            }
            else
            {
                paso = false;
            }

            return paso;
        }


    }
}
