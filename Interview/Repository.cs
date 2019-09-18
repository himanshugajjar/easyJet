using System;
using System.Collections.Generic;
using System.Linq;

namespace Interview
{
    public class Repository : IRepository<Flight, long>
    {
        private readonly IList<Flight> _dataSet;

        public Repository(IList<Flight> dataSet)
        {
            if (dataSet == null || !dataSet.Any())
            {
                _dataSet = new List<Flight>();
            }
            else
            {
                _dataSet = dataSet;
            }
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