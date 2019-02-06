using System;
using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _1erParcial.Tests
{
    [TestClass]
    public class CuentaUnitTest
    {
        private CuentasBancarias GetCuentas()
        {
            CuentasBancarias cuentasbancarias = new CuentasBancarias();

            cuentasbancarias.CuentaId = 0;
            cuentasbancarias.Nombre = "Ventas de Software";
            cuentasbancarias.Fecha = DateTime.Now;
            cuentasbancarias.Balance = 4000;
            return cuentasbancarias;
        }
        Repositorio<CuentasBancarias> repositorio = new Repositorio<CuentasBancarias>();

        [TestMethod]
        public void Guardar()
        {
            
           Assert.IsTrue(repositorio.Guardar(GetCuentas()));
           
        }

        [TestMethod]
        public void Modificar()
        {
          
            Assert.IsTrue(repositorio.Modificar(GetCuentas()));

        }

        [TestMethod]
        public void Buscar()
        {
            Assert.IsNotNull(repositorio.Buscar(1));

        }

     
        [TestMethod]
        public void GetList()
        {
            var lista = repositorio.GetList(x => true);
            Assert.IsNotNull(lista);

        }

        [TestMethod]
        public void Eliminar()
        {
            Assert.IsNotNull(repositorio.Eliminar(1));
        }

    }
}
