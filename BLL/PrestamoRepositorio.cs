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

            Repositorio<Depositos> repositorio = new Repositorio<Depositos>();
            try
            {
                //Buscar la entidades que no estan para removerlas
                var anterior = _contexto.prestamos.Find(prestamos.PrestamoId);

                foreach (var item in anterior.Detalles)
                {
                    if(!prestamos.Detalles.Exists(x => x.Id == item.Id))
                    {
                     
                        _contexto.Entry(item).State = EntityState.Deleted;
                    }

                }

                foreach (var item in prestamos.Detalles)
                {
                    var estado = item.Id > 0 ? EntityState.Modified : EntityState.Added;
                    _contexto.Entry(item).State = estado;

                }

                _contexto.Entry(prestamos).State = EntityState.Modified;


                if (_contexto.SaveChanges() > 0)
                {
                    paso = true;
                }


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

        public decimal BalanceCuota(decimal capital, int tiempo, decimal interes)
        {
            decimal BalanceCuota = 0;
           
            interes /= 100;

            decimal ci = (capital * interes) + capital;
            decimal pa = CapitalCuota(capital, tiempo) + (CapitalCuota(capital, tiempo) *interes);
            BalanceCuota =  ci - pa;
            return BalanceCuota;


        }
    }
}