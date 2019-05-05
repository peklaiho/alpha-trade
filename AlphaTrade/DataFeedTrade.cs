namespace AlphaTrade
{
    public class DataFeedTrade
    {
        public string Symbol;
        public long Time;
        public double Price { get; set; }
        public long Volume;
        public int Direction;

        public double VolumeThousands
        {
            get
            {
                return Volume / 1000;
            }
        }
    }
}
