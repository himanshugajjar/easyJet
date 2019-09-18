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
            try
            {
                var record = _dataSet.FirstOrDefault(x => x.Id == id);

                if (record != null)
                {
                    _dataSet.Remove(record);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Flight Get(long id)
        {
            Flight result = null;

            try
            {
                var record = _dataSet.FirstOrDefault(x => x.Id == id);

                if (record != null)
                {
                    result = new Flight { Id = record.Id, Number = record.Number };
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public IEnumerable<Flight> GetAll()
        {
            return _dataSet.Select(x => new Flight { Id = x.Id, Number = x.Number });
        }

        public void Save(Flight flight)
        {
            if (flight != null && flight.Id != 0 && !string.IsNullOrEmpty(flight.Number))
            {
                var record = _dataSet.FirstOrDefault(x => x.Id == flight.Id);

                if (record == null)
                {
                    _dataSet.Add(flight);
                }
                else
                {
                    record.Number = flight.Number;
                }
            }
        }
    }
}