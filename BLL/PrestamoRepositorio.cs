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
                prestamos.Detalles.Count();

                foreach (var item in prestamos.Detalles)
                {
                    string s = item.prestamos.NombreCuenta;

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

                foreach (var item in prestamos.Detalles)
                {
                    var estado = item.Cuota > 0 ? EntityState.Modified : EntityState.Added;
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




    }
}
