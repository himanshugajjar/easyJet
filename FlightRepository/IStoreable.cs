namespace FlightRepository
{
    public interface IStoreable<T>
    {
        T Id { get; set; }
    }

}