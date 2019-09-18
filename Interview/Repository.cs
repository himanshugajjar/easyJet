using System;
using System.Collections.Generic;
using System.Linq;

namespace Interview
{
    public class Repository : IRepository<Flight, long>
    {
        // TODO: I prefered this Inmemeory dataset should have its own implementation so 
        // I can inject is and mock this to test other method

        private readonly IList<Flight> _dataSet;

        public Repository()
        {
            _dataSet = new List<Flight>();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Flight Get(long id)
        {
            return new Flight { Id = 1, Number = "U2 2265" };
        }

        public IEnumerable<Flight> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save(Flight flight)
        {
            _dataSet.Add(flight);
        }
    }
}