using System.Collections.Generic;

namespace TestoTexoIT.Application.Dtos
{
    public class ResultMinMaxDto
    {
        public List<IntervalAwardsDto> Min { get; set; }
        public List<IntervalAwardsDto> Max { get; set; }
    }
}
