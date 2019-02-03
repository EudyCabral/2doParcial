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

                    var cuenta = contexto.cuentasbancarias.Find(depositos.CuentaId);
                    //Incrementar el balance
                    cuenta.Balance += depositos.Monto;


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


                var depositoanterior = repositorio.Buscar(depositos.DepositoId);

                //identificar la diferencia ya sea restada o sumada
                decimal diferencia;
                diferencia = depositos.Monto - depositoanterior.Monto;

                //Buscar
                var cuentas = contexto.cuentasbancarias.Find(depositoanterior.CuentaId);

                //aplicar diferencia al inventario 
                cuentas.Balance += diferencia;




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


    }
}
