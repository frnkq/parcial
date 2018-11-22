using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
namespace Tests
{
    [TestClass]
    public class ClasesInstanciablesUniversidadTest
    {
        Universidad universidad;
        [TestMethod]
        public void TestUniversidadAlumnosNotNull()
        {
            universidad = new Universidad();

            Assert.IsNotNull(universidad.Alumnos);
        }
    }
}

