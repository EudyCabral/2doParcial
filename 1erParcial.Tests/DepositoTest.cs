using System;
using BLL;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _1erParcial.Tests
{
    [TestClass]
    public class DepositoTest
    {
        private Depositos GetDepositos()
        {
            Depositos depositos = new Depositos();

            depositos.DepositoId = 1;
            depositos.Concepto = "Ventas de SoftDrink";
            depositos.Fecha = DateTime.Now;
            depositos.CuentaId= 2;
            depositos.Monto = 1000;
            return depositos;
        }

        RepositorioDepositos repositorio = new RepositorioDepositos();

        [TestMethod]
        public void Guardar()
        {

            Assert.IsTrue(repositorio.Guardar(GetDepositos()));

        }

        [TestMethod]
        public void Modificar()
        {

            Assert.IsTrue(repositorio.Modificar(GetDepositos()));

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
