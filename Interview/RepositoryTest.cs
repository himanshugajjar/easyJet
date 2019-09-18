using System;
using System.Collections.Generic;
using System.Linq;
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
            var repo = new Repository(null);

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
            var data = new List<Flight>() { new Flight { Id = 2, Number = "2Random" } };
            var repo = new Repository(data);

            //Action
            var flight = repo.Get(2);

            //Assert
            Assert.IsNotNull(flight);

            Assert.IsTrue(flight.Id == 2);

            Assert.IsTrue(flight.Number == "2Random");
        }

        [TestMethod]
        public void Repository_should_not_save_invalid_record()
        {
            //Arrange
            var data = new List<Flight>() { new Flight { Id = 3, Number = "3Random" } };
            var repo = new Repository(data);

            //Action
            var flight = repo.Get(3);

            flight.Number = null;

            repo.Save(flight);

            flight = repo.Get(3);

            //Assert
            Assert.IsNotNull(flight);

            Assert.IsTrue(flight.Id == 3);

            Assert.IsTrue(flight.Number == "3Random");
        }

        [TestMethod]
        public void Repository_should_update_existing_record()
        {
            //Arrange
            var data = new List<Flight>() { new Flight { Id = 3, Number = "3Random" } };
            var repo = new Repository(data);

            //Action
            var flight = repo.Get(3);

            flight.Number = "update_3random";

            repo.Save(flight);

            flight = repo.Get(3);

            //Assert
            Assert.IsNotNull(flight);

            Assert.IsTrue(flight.Id == 3);

            Assert.IsFalse(flight.Number == "3Random");

            Assert.IsTrue(flight.Number == "update_3random");
        }

        [TestMethod]
        public void Repository_delete_should_remove_correct_record()
        {
            //Arrange
            var data = new List<Flight>() {
                new Flight { Id = 1, Number = "1Random" },
                new Flight { Id = 2, Number = "2Random" },
                new Flight { Id = 3, Number = "3Random" },
                new Flight { Id = 4, Number = "4Random" },
            };
            var repo = new Repository(data);

            //Action
            repo.Delete(1);
            repo.Delete(3);

            var flight1 = repo.Get(1);
            var flight2 = repo.Get(2);
            var flight3 = repo.Get(3);
            var flight4 = repo.Get(4);

            //Assert
            Assert.IsNull(flight1);

            Assert.IsNull(flight3);

            Assert.IsNotNull(flight2);

            Assert.IsNotNull(flight4);

            Assert.IsTrue(flight2.Id == 2);

            Assert.IsTrue(flight2.Number == "2Random");

            Assert.IsTrue(flight4.Id == 4);

            Assert.IsTrue(flight4.Number == "4Random");

        }

        [TestMethod]
        public void Repository_GetAll_should_return_all_records()
        {

            //Arrange
            var data = new List<Flight>() {
                new Flight { Id = 1, Number = "1Random" },
                new Flight { Id = 2, Number = "2Random" },
                new Flight { Id = 3, Number = "3Random" },
                new Flight { Id = 4, Number = "4Random" },
            };
            var repo = new Repository(data);

            //Action
            var flights = repo.GetAll().ToList();

            //Assert
            Assert.IsTrue(flights.Count == data.Count);

            Assert.IsNotNull(flights.FirstOrDefault(x => x.Id == data[0].Id && x.Number == data[0].Number));

            Assert.IsNotNull(flights.FirstOrDefault(x => x.Id == data[1].Id && x.Number == data[1].Number));

            Assert.IsNotNull(flights.FirstOrDefault(x => x.Id == data[2].Id && x.Number == data[2].Number));

            Assert.IsNotNull(flights.FirstOrDefault(x => x.Id == data[3].Id && x.Number == data[3].Number));
        }

        [TestMethod]
        public void Repository_GetAll_should_return_records_in_default_order()
        {

            //Arrange
            var data = new List<Flight>() {
                new Flight { Id = 4, Number = "4Random" },
                new Flight { Id = 1, Number = "1Random" },
                new Flight { Id = 3, Number = "3Random" },
                new Flight { Id = 2, Number = "2Random" },
            };
            var repo = new Repository(data);

            //Action
            var flights = repo.GetAll().OrderBy(x => x.Id).ToList();

            //Assert
            Assert.IsTrue(flights.Count == data.Count);

            Assert.AreEqual(flights[0].Id, data[0].Id);

            Assert.AreEqual(flights[1].Id, data[1].Id);

            Assert.AreEqual(flights[2].Id, data[2].Id);

            Assert.AreEqual(flights[3].Id, data[3].Id);

        }

    }
}
