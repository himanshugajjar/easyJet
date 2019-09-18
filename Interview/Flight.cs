namespace Interview
{
    public class Flight : IStoreable<long>
    {
        public long Id { get; set; }
        public string Number { get; set; }
    }
}