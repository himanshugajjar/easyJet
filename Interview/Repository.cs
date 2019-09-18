using System;
using System.Collections.Generic;

namespace Interview
{
    public class Repository : IRepository<Flight, long>
    {
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
        }
    }
}