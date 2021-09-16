using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TesteTexoIT.Domain.Context;
using TesteTexoIT.Domain.Entities;
using TestoTexoIT.Application.Dtos;

namespace TestoTexoIT.Application.Services
{
    public class AwardService
    {
        TexoContext _context;

        public AwardService(TexoContext context)
        {
            _context = context;
        }

        public void SaveAwardList(List<AwardListDto> awards)
        {
            foreach (var obj in awards)
            {
                var award = _context.Awards.FirstOrDefault(x => x.Year == obj.Year && x.Title == obj.Title);
                if (award == null)
                {
                    Add(MapperObj(obj));
                }
                else
                {
                    award.Producers = obj.Producers;
                    award.Studios = obj.Studios;
                    award.Winner = obj.Winner;
                    Update(award);
                }
            }
        }

        public void Add(Award award)
        {
            _context.Add(award);
            _context.SaveChanges();
        }

        public void Update(Award award)
        {
            _context.Update(award);
            _context.SaveChanges();
        }

        public Award Get(int id)
        {
            return _context.Awards.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public List<Award> GetAll()
        {
            return _context.Awards.AsNoTracking().ToList();
        }

        public List<Award> GetWinners()
        {
            return _context.Awards.AsNoTracking().Where(x => x.Winner).ToList();
        }

        public void Delete(int id)
        {
            var award = Get(id);
            if (award != null)
                _context.Awards.Remove(award);
            _context.SaveChanges();
        }

        public void DeleteAll()
        {
            _context.Awards.RemoveRange(GetAll());
            _context.SaveChanges();
        }

        private Award MapperObj(AwardListDto obj)
        {
            var award = new Award();
            award.Producers = obj.Producers;
            award.Studios = obj.Studios;
            award.Title = obj.Title;
            award.Winner = obj.Winner;
            award.Year = obj.Year;
            return award;
        }
    }
}
