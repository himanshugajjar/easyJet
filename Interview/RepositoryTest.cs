﻿using System;
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

        [TestMethod]
        public void Repository_get_should_retrun_valid_record()
        {
            //Arrange
            var data = new List<Flight>() { new Flight { Id = 2, Number = "2Rendom" } };
            var repo = new Repository(data);

            //Action
            var flight = repo.Get(2);

            //Assert
            Assert.IsNotNull(flight);

            Assert.IsTrue(flight.Id == 2);

            Assert.IsTrue(flight.Number == "2Random");
        }
    }
}
