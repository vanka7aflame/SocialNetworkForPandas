using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestPanda
{
    using Panda;
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidateEmail()
        {
            Panda panda = new Panda("Ivan", "asd@abv.bg", Panda.GenderType.Male);
            Assert.AreEqual(Panda.IsEmailValid("asd@abv.bg"), true );
        }

        [TestMethod]
        public void CheckingMale()
        {
            Panda panda = new Panda("Ivan", "asd@abv.bg", Panda.GenderType.Male);
            Assert.AreEqual(panda.IsFemale, false);
        }

        [TestMethod]
        public void CheckingFemale()
        {
            Panda panda = new Panda("Ivan", "asd@abv.bg", Panda.GenderType.Female);
            Assert.AreEqual(panda.IsMale, false);
        }

        [TestMethod]
        public void ValidateName()
        {
            Panda panda = new Panda("Ivan", "asd@abv.bg", Panda.GenderType.Female);
            Assert.AreEqual(Panda.IsNameValid(panda.Name), true);
        }
    }
}
