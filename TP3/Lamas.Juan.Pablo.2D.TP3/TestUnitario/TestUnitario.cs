using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EntidadesInstanciables;
using EntidadesAbstractas;
using Excepciones;

namespace TestUnitario
{
    [TestClass]
    public class TestUnitario
    {
        [TestMethod]
        public void TestNacionalidadInvalida()
        {
            Assert.ThrowsException<NacionalidadInvalidaException>(() => new Alumno(1, "aaa", "bbb", "99999999", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio));
        }
        [TestMethod]
        public void TestDniInvalido()
        {
            Assert.ThrowsException<DniInvalidoException>(() => new Alumno(1, "aaa", "bbb", "-99999999", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio));
        }
        [TestMethod]
        public void TestColeccion() 
        {
            Universidad u = new Universidad();

            Assert.IsTrue(u.Alumnos != null);
        }
    }
}
