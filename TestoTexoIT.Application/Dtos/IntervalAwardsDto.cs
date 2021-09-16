namespace TestoTexoIT.Application.Dtos
{
    public class IntervalAwardsDto
    {
        public string Producer { get; set; }
        public int Interval { get; set; }
        public int PreviousWin { get; set; }
        public int FollowingWin { get; set; }
    }
}
