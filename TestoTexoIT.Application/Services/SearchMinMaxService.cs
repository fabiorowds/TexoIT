using System.Collections.Generic;
using System.Linq;
using TesteTexoIT.Domain.Entities;
using TestoTexoIT.Application.Dtos;

namespace TestoTexoIT.Application.Services
{
    public class SearchMinMaxService : ISearchMinMaxService
    {

        AwardService _awardService;

        public SearchMinMaxService(AwardService awardService)
        {
            _awardService = awardService;
        }

        public ResultMinMaxDto Search()
        {
            var awards = _awardService.GetWinners();

            return SearchMinMax(awards);

        }

        public ResultMinMaxDto SearchMinMax(List<Award> awards)
        {
            var intervals = SearchInterval(awards);

            var min = intervals.OrderBy(x => x.Interval).FirstOrDefault().Interval;
            var max = intervals.OrderByDescending(x => x.Interval).FirstOrDefault().Interval;

            return new ResultMinMaxDto()
            {
                Min = intervals.Where(x => x.Interval == min).ToList(),
                Max = intervals.Where(x => x.Interval == max).ToList()
            };
        }

        private List<IntervalAwardsDto> SearchInterval(List<Award> awards)
        {
            List<IntervalAwardsDto> result = new List<IntervalAwardsDto>();

            foreach (var award in awards)
            {
                if (result.FirstOrDefault(x => x.Producer.ToLower().Trim() == award.Producers.ToLower().Trim()) == null)
                {
                    var awardsProducer = awards.Where(x => x.Producers.ToLower().Trim() == award.Producers.ToLower().Trim()).OrderBy(x => x.Year).ToList();
                    for (int i = 0; i < awardsProducer.Count; i++)
                    {
                        if (awardsProducer.Count > i + 1)
                            result.Add(new IntervalAwardsDto()
                            {
                                Producer = awardsProducer[0].Producers,
                                Interval = awardsProducer[i + 1].Year - awardsProducer[i].Year,
                                FollowingWin = awardsProducer[i + 1].Year,
                                PreviousWin = awardsProducer[i].Year
                            });
                    }
                }
            }
            return result;
        }

    }
}
