using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Interview
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void Repository_save_should_add_record_to_in_memory()
        {
            //Arrange
            var repo = new Repository();

            //Action
            repo.Save(new Flight()
            {
                Id = 1,
                Number = "U2 2265"
            });

            var flight = repo.Get(1);

            //Assert
            Assert.IsNotNull(flight);

            Assert.IsTrue(flight.Id == 1);

            Assert.IsTrue(flight.Number == "U2 2265");
        }

    }
}
