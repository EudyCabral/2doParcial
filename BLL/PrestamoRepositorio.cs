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
    public class PrestamoRepositorio : Repositorio<Prestamos>
    {

        public override bool Guardar(Prestamos prestamos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {


                if (contexto.prestamos.Add(prestamos) != null)
                {

                    var cuenta = contexto.cuentasbancarias.Find(prestamos.Cuenta);
                    //Incrementar el balance
                    cuenta.Balance += prestamos.Balance;


                    contexto.SaveChanges();
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
                Prestamos prestamos = contexto.prestamos.Find(id);

                if (prestamos != null)
                {
                    var cuenta = contexto.cuentasbancarias.Find(prestamos.Cuenta);
                    //Incrementar la cantidad
                    cuenta.Balance -= prestamos.Balance;

                    contexto.Entry(prestamos).State = EntityState.Deleted;

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
        public override Prestamos Buscar(int id)
        {
            Prestamos prestamos = new Prestamos();

            try
            {
                prestamos = _contexto.prestamos.Find(id);

                if (prestamos != null)
                {
                    prestamos.Detalles.Count();

                    foreach (var item in prestamos.Detalles)
                    {
                        // string s = item.prestamos.NombreCuenta;

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return prestamos;
        }

        public override bool Modificar(Prestamos prestamos)
        {

            bool paso = false;

            Repositorio<Prestamos> repositorio = new Repositorio<Prestamos>();
            try
            {
                _contexto = new Contexto();
                //Buscar la entidades que no estan para removerlas
                var CuotasAnt = _contexto.prestamoDetalles.Where(x => x.PrestamoId == prestamos.PrestamoId).AsNoTracking().ToList();

                foreach (var item in CuotasAnt)
                {
                    _contexto.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                }


                var prestamoanterior = repositorio.Buscar(prestamos.PrestamoId);


                var Cuenta = _contexto.cuentasbancarias.Find(prestamos.Cuenta);
                var Cuentasanterior = _contexto.cuentasbancarias.Find(prestamoanterior.Cuenta);

                if (prestamos.Cuenta != prestamoanterior.Cuenta)
                {
                    Cuenta.Balance += prestamos.Balance;
                    Cuentasanterior.Balance -= prestamoanterior.Balance;
                }



                //identificar la diferencia ya sea restada o sumada
                decimal diferencia;
                diferencia = prestamos.Balance - prestamoanterior.Balance;



                //aplicar diferencia al inventario 
                Cuenta.Balance += diferencia;



                foreach (var item in prestamos.Detalles)
                {
                    _contexto.Entry(item).State = EntityState.Added;
                }

                _contexto.Entry(prestamos).State = EntityState.Modified;

                paso = _contexto.SaveChanges() > 0 ? true : false;
            }
            catch (Exception) { throw; }

            return paso;
        }

        public decimal CapitalCuota(decimal capital, int tiempo)
        {
            decimal capitalcuota = 0;

            capitalcuota = capital / tiempo;

            return capitalcuota;
        }


        public decimal InteresCuota(decimal capital, int tiempo, decimal interes)
        {
            decimal interesCuota = 0;
            interes /= 100;

            interesCuota = CapitalCuota(capital, tiempo) * interes;

            return interesCuota;
        }

        public decimal BalanceCuota(decimal capital, decimal interes)
        {
            decimal BalanceCuota = 0;

            interes /= 100;


            BalanceCuota = (capital * interes) + capital;
            return BalanceCuota;


        }


    }
}